using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace GXService.Utils
{
    public static class SerializeExtension
    {
        public static List<T> DeserializeList<T>(this byte[] objsData)
        {
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            ms.Write(objsData, 0, objsData.Length);
            ms.Seek(0, SeekOrigin.Begin);

            try
            {
                return bf.Deserialize(ms) as List<T>;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static byte[] Serialize<T>(this T obj)
        {
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        public static object Deserialize(this byte[] objsData)
        {
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            ms.Write(objsData, 0, objsData.Length);
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);

            try
            {
                return bf.Deserialize(ms);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

    public static class PermutationCombinationExtension
    {
        public static IEnumerable<IEnumerable<T>> Combination<T>(this IEnumerable<T> a, int choose)
        {
            var combination = a as IList<T> ?? a.ToList();
            var count = combination.Count();
            if (choose >= count)
            {
                yield return combination;
            }
            else if (choose <= 1)
            {
                foreach (var n in (from m in combination select m))
                {
                    yield return Enumerable.Repeat(n, 1);
                }
            }
            else
            {
                for (int i = 0; i + choose <= count; ++i)
                {
                    foreach (var m in combination.Skip(i + 1).Combination(choose - 1))
                    {
                        yield return combination.Skip(i).Take(1).Union(m);
                    }
                }
            }
        }

        public static IEnumerable<T> Combination<T>(this IEnumerable<T> a, int choose, Func<T, T, T> aggregate)
        {
            return (from e in a.Combination(choose)
                    select e.Aggregate(aggregate));
        }

        private static IEnumerable<IEnumerable<T>> FullPermutation<T>(this IEnumerable<T> a)
        {
            int count = a.Count();
            if (count <= 1)
            {
                yield return a;
            }
            else
            {
                for (int i = 0; i < count; ++i)
                {
                    var m = a.Skip(i).Take(1);
                    foreach (var n in a.Except(m).FullPermutation())
                    {
                        yield return m.Union(n);
                    }
                }
            }
        }

        public static IEnumerable<IEnumerable<T>> Permutation<T>(this IEnumerable<T> a, int choose)
        {
            if (choose >= a.Count()) return a.FullPermutation();
            return (from e in a.Combination(choose) select e.FullPermutation()).Aggregate((e1, e2) => e1.Union(e2));
        }

        public static IEnumerable<T> Permutation<T>(this IEnumerable<T> a, int choose, Func<T, T, T> aggregate)
        {
            return (from e in a.Permutation(choose)
                    select e.Aggregate(aggregate));
        }
    }

    public static class RectangleExtension
    {
        public static Point Center(this Rectangle rect)
        {
            return new Point((rect.Left + rect.Right)/2, (rect.Top + rect.Bottom)/2);
        }

        public static Rectangle ToRectangle(this User32Api.RectApi rect)
        {
            return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
        }

        public static User32Api.RectApi ToRectApi(this Rectangle rect)
        {
            return new User32Api.RectApi {left = rect.Left, right = rect.Right, top = rect.Top, bottom = rect.Bottom};
        }
    }

    public class ListValueComparer<T> : IEqualityComparer<List<T>>
    {
        private readonly IEqualityComparer<T> _valueComparer;
        public ListValueComparer(IEqualityComparer<T> valueComparer)
        {
            _valueComparer = valueComparer;
        }

        public bool Equals(List<T> x, List<T> y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.Count() == y.Count()
                && x.All(xc => y.Contains(xc, _valueComparer))
                && y.All(yc => x.Contains(yc, _valueComparer));
        }

        public int GetHashCode(List<T> x)
        {
            //Check whether the object is null
            if (ReferenceEquals(x, null)) return 0;

            //Calculate the hash code for the product.
            var hashCode = 0;
            foreach (var c in x)
            {
                if (hashCode == 0)
                {
                    hashCode = _valueComparer.GetHashCode(c);
                }
                else
                {
                    hashCode = hashCode ^ _valueComparer.GetHashCode(c);
                }
            }
            return hashCode;
        }
    }

    public class RectangleLeftComparer : IComparer<Rectangle>
    {
        public int Compare(Rectangle x, Rectangle y)
        {
            if (x.Left == y.Left)
            {
                return 0;
            }

            if (x.Left < y.Left)
            {
                return -1;
            }

            return 1;
        }
    }
}

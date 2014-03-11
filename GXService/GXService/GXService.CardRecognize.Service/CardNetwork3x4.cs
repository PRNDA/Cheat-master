using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AForge.Neuro;
using GXService.CardRecognize.Contract;

namespace GXService.CardRecognize.Service
{
    public class CardNetwork3x4 : IRecognizer
    {
        private readonly Network _network = Network.Load(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\network3x4.data");

        public KeyValuePair<CardNum, double> ComputeNum(Bitmap bmpNum)
        {
            return GetCardNum(_network.Compute(GetFeature(bmpNum).ToArray()));
        }

        public KeyValuePair<CardColor, double> ComputeColor(Bitmap bmpColor)
        {
            var result = new KeyValuePair<CardColor, double>();



            return result;
        }

        private List<double> GetFeature(Bitmap bmp)
        {
            var result = new List<double>();
            //特征点提取，用3x4的小块进行切分统计白点个数(黑色为背景色)，总共有16份数据作为输入
            for (var j = 1; j <= 4; j++)
            {
                for (var i = 1; i <= 4; i++)
                {
                    double count = 0;
                    for (var k = (i - 1) * 3; k < (i * 3 - 1); k++)
                    {
                        for (var l = (j - 1) * 4; l < (j * 4 - 1); l++)
                        {
                            if (bmp.GetPixel(k, l).R == 255)
                            {
                                count++;
                            }
                        }
                    }

                    result.Add(count / 100);
                }
            }

            return result;
        }

        private KeyValuePair<CardNum, double> GetCardNum(double[] computeResult)
        {
            if (null == computeResult)
            {
                return new KeyValuePair<CardNum, double>(CardNum.未知, 0);
            }

            var index = computeResult.Select(r => ((int)(r * 10)) / 10.0).ToList().FindIndex(r => r >= 0.9) + 1;
            if (index == 1)
            {
                //牌的大小顺序为:2,3,4,5,6,6,7,8,9,10,J,Q,K,A
                index = 14;
            }

            return new KeyValuePair<CardNum, double>((CardNum)index, computeResult[index - 1]);
        }
    }
}

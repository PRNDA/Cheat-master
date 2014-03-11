using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AForge.Neuro;
using GXService.CardRecognize.Contract;

namespace GXService.CardRecognize.Service
{
    public class CardNetwork2x2 : IRecognizer
    {
        private readonly Network _network = Network.Load(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\network2x2.data");

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
            //特征点提取，用2x2的小块进行切分统计白点个数(黑色为背景色)，总共有48份数据作为输入(原图为12x16)
            for (var j = 1; j <= 8; j++)
            {
                for (var i = 1; i <= 6; i++)
                {
                    double count = 0;
                    for (var k = (i - 1) * 2; k < (i * 2 - 1); k++)
                    {
                        for (var l = (j - 1) * 2; l < (j * 2 - 1); l++)
                        {
                            if (bmp.GetPixel(k, l).R == 255)
                            {
                                count++;
                            }
                        }
                    }

                    result.Add(count / 10);
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

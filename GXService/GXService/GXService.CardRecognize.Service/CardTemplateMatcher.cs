using System.Collections.Generic;
using System.Drawing;
using GXService.CardRecognize.Contract;

namespace GXService.CardRecognize.Service
{
    public class CardTemplateMatcher : IRecognizer
    {
        public KeyValuePair<CardNum, double> ComputeNum(Bitmap bmpNum)
        {
            var result = new KeyValuePair<CardNum, double>();



            return result;
        }

        public KeyValuePair<CardColor, double> ComputeColor(Bitmap bmpColor)
        {
            var result = new KeyValuePair<CardColor, double>();



            return result;
        }
    }
}

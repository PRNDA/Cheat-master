using System.Collections.Generic;
using GXService.CardRecognize.Contract;
using GXService.SSZGameServer.Contract;

namespace GXService.SSZGameServer.Service.CardTypeParsers
{
    public abstract class CardTypeParser
    {
        protected Dictionary<CardNum, List<Card>> CardsDic = new Dictionary<CardNum, List<Card>>
            {
                {CardNum._2, new List<Card>()},{CardNum._3, new List<Card>()},{CardNum._4, new List<Card>()},
                {CardNum._5, new List<Card>()},{CardNum._6, new List<Card>()},{CardNum._7, new List<Card>()},
                {CardNum._8, new List<Card>()},{CardNum._9, new List<Card>()},{CardNum._10, new List<Card>()},
                {CardNum._J, new List<Card>()},{CardNum._Q, new List<Card>()},{CardNum._K, new List<Card>()},
                {CardNum._A, new List<Card>()}
            };

        //同花顺>；炸弹>；葫芦>；同花>；顺子>；三条>；两对>；一对>5单张
        public abstract List<CardType> Recognize(List<Card> cards);
    }
}

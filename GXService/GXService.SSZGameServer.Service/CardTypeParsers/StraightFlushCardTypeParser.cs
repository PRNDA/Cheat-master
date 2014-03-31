using System.Collections.Generic;
using System.Linq;
using GXService.CardRecognize.Contract;
using GXService.SSZGameServer.Contract;

namespace GXService.SSZGameServer.Service.CardTypeParsers
{
    /// <summary>
    /// 同花顺
    /// </summary>
    public class StraightFlushCardTypeParser : StraightCardTypeParser
    {
        public override List<CardType> Recognize(List<Card> cards)
        {
            var result = new List<CardType>();
            CardsDic.Keys.ToList().ForEach(key => CardsDic[key].Clear());

            base.Recognize(cards)
                .ForEach(cardType =>
                {
                    if (cardType.GetCards().ToList().TrueForAll(card => card.Color == cardType.GetCards()[0].Color))
                    {
                        result.Add(new StraightFlushCardType(cardType.GetCards().ToList()));
                    }
                });

            return result;
        }
    }

}

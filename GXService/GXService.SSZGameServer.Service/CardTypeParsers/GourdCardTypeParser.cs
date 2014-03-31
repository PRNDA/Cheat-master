using System.Collections.Generic;
using System.Linq;
using GXService.CardRecognize.Contract;
using GXService.SSZGameServer.Contract;
using GXService.Utils;

namespace GXService.SSZGameServer.Service.CardTypeParsers
{
    /// <summary>
    /// 葫芦(3带2)
    /// </summary>
    public class GourdCardTypeParser : CardTypeParser
    {
        public override List<CardType> Recognize(List<Card> cards)
        {
            var result = new List<CardType>();
            CardsDic.Keys.ToList().ForEach(key => CardsDic[key].Clear());

            cards.ForEach(card => CardsDic[card.Num].Add(card));

            var keysMore2 = new List<CardNum>();
            var keysMore3 = new List<CardNum>();

            CardsDic.ToList()
                    .ForEach(dic =>
                    {
                        if (dic.Value.Count >= 2)
                        {
                            keysMore2.Add(dic.Key);
                            if (dic.Value.Count >= 3)
                            {
                                keysMore3.Add(dic.Key);
                            }
                        }
                    });

            keysMore3
                .ForEach(key3 =>
                         keysMore2
                             .Where(key2 => key2 != key3)
                             .ToList()
                             .ForEach(key2 =>
                                      CardsDic[key3]
                                          .Combination(3)
                                          .ToList()
                                          .ForEach(c3 =>
                                                   CardsDic[key2]
                                                       .Combination(2)
                                                       .ToList()
                                                       .ForEach(c2 => result.Add(new GourdCardType(c3.Concat(c2).ToList()))))));

            return result;
        }
    }

}

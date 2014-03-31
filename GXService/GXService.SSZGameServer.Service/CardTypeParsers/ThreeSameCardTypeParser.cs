using System.Collections.Generic;
using System.Linq;
using GXService.CardRecognize.Contract;
using GXService.SSZGameServer.Contract;
using GXService.Utils;

namespace GXService.SSZGameServer.Service.CardTypeParsers
{
    /// <summary>
    /// 三张(3带两个单张)
    /// </summary>
    public class ThreeSameCardTypeParser : CardTypeParser
    {
        public override List<CardType> Recognize(List<Card> cards)
        {
            var result = new List<CardType>();
            CardsDic.Keys.ToList().ForEach(key => CardsDic[key].Clear());

            cards.ForEach(card => CardsDic[card.Num].Add(card));

            var keysMore3 = new List<CardNum>();
            var keysMore1 = new List<CardNum>();

            CardsDic.ToList()
                .ForEach(dic =>
                {
                    if (dic.Value.Count < 1)
                    {
                        return;
                    }

                    keysMore1.Add(dic.Key);

                    if (dic.Value.Count >= 3)
                    {
                        keysMore3.Add(dic.Key);
                    }
                });

            keysMore3
                .ForEach(key3 =>
                         CardsDic[key3]
                             .Combination(3)
                             .ToList()
                             .ForEach(comb3 =>
                                      keysMore1
                                          .Combination(2)
                                          .ToList()
                                          .ForEach(comb2Keys =>
                                          {
                                              var enumerable = comb2Keys as IList<CardNum> ?? comb2Keys.ToList();
                                              if (enumerable.Contains(key3))
                                              {
                                                  return;
                                              }
                                              var cardNums = enumerable.ToList();
                                              CardsDic[cardNums[0]]
                                                  .ForEach(card1 =>
                                                           CardsDic[cardNums[1]]
                                                               .ForEach(card2 =>
                                                               {
                                                                   var cardType = comb3.ToList();
                                                                   cardType.Add(card1);
                                                                   cardType.Add(card2);
                                                                   result.Add(new ThreeSameCardType(cardType));
                                                               }));
                                          })));

            return result;
        }
    }
}

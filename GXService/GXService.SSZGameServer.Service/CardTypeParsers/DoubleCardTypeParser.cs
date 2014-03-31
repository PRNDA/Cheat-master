using System.Collections.Generic;
using System.Linq;
using GXService.CardRecognize.Contract;
using GXService.SSZGameServer.Contract;
using GXService.Utils;

namespace GXService.SSZGameServer.Service.CardTypeParsers
{
    public class DoubleCardTypeParser : CardTypeParser
    {
        public override List<CardType> Recognize(List<Card> cards)
        {
            var result = new List<CardType>();
            CardsDic.Keys.ToList().ForEach(key => CardsDic[key].Clear());

            cards.ForEach(card => CardsDic[card.Num].Add(card));

            var keysMore2 = new List<CardNum>();
            var keysMore1 = new List<CardNum>();

            CardsDic.ToList()
                    .ForEach(dic =>
                    {
                        if (dic.Value.Count <= 0)
                        {
                            return;
                        }

                        keysMore1.Add(dic.Key);

                        if (dic.Value.Count >= 2)
                        {
                            keysMore2.Add(dic.Key);
                        }
                    });

            keysMore2
                .ForEach(keyDouble =>
                         CardsDic[keyDouble]
                             .Combination(2)
                             .ToList()
                             .ForEach(cardDouble =>
                                      keysMore1
                                          .Combination(3)
                                          .Where(comb3 => !comb3.Contains(keyDouble))
                                          .ToList()
                                          .ForEach(comb3 =>
                                          {
                                              var cardNums = comb3 as IList<CardNum> ?? comb3.ToList();
                                              CardsDic[cardNums.ToList()[0]]
                                                  .ToList()
                                                  .ForEach(card3 =>
                                                           CardsDic[cardNums.ToList()[1]]
                                                               .ToList()
                                                               .ForEach(card4 =>
                                                                        CardsDic[cardNums.ToList()[2]]
                                                                            .ToList()
                                                                            .ForEach(card5 =>
                                                                            {
                                                                                var cardsType =
                                                                                    cardDouble.ToList();
                                                                                cardsType.AddRange(new List
                                                                                                       <Card>
                                                                                            {
                                                                                                card3,
                                                                                                card4,
                                                                                                card5
                                                                                            });
                                                                                result.Add(
                                                                                    new OnePairCardType(
                                                                                        cardsType));
                                                                            })));
                                          })));

            return result;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using GXService.CardRecognize.Contract;
using GXService.SSZGameServer.Contract;
using GXService.Utils;

namespace GXService.SSZGameServer.Service.CardTypeParsers
{
    public class TwoDoubleCardTypeParser : CardTypeParser
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
            if (keysMore2.Count < 2)
            {
                return result;
            }
            keysMore2.Combination(2)
                     .ToList()
                     .ForEach(comb2 =>
                     {
                         var cardNums = comb2 as CardNum[] ?? comb2.ToArray();
                         CardsDic[cardNums.ToList()[0]]
                             .Combination(2)
                             .ToList()
                             .ForEach(cards2First =>
                                      CardsDic[cardNums.ToList()[1]]
                                          .Combination(2)
                                          .ToList()
                                          .ForEach(cards2Second =>
                                                   keysMore1
                                                       .Where(key => !cardNums.Contains(key))
                                                       .ToList()
                                                       .ForEach(cardOneKey =>
                                                                CardsDic[cardOneKey]
                                                                    .ForEach(card =>
                                                                    {
                                                                        var cardsType = new List<Card>();
                                                                        var enumerable = cards2First as IList<Card> ?? cards2First.ToList();
                                                                        var collection = cards2Second as IList<Card> ?? cards2Second.ToList();
                                                                        if (enumerable.ToList()[0].Num >= collection.ToList()[0].Num)
                                                                        {
                                                                            cardsType.AddRange(enumerable);
                                                                            cardsType.AddRange(collection);
                                                                        }
                                                                        else
                                                                        {
                                                                            cardsType.AddRange(collection);
                                                                            cardsType.AddRange(enumerable);
                                                                        }
                                                                        cardsType.Add(card);
                                                                        result.Add(new DoublePairCardType
                                                                                       (
                                                                                       cardsType
                                                                                       ));
                                                                    }))));
                     });

            return result;
        }
    }
}

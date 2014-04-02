using System.Collections.Generic;
using System.Linq;
using GXService.CardRecognize.Contract;
using GXService.SSZGameServer.CardTypeParseService.Contract;
using GXService.Utils;

namespace GXService.SSZGameServer.CardTypeParseService.Service.CardTypeParsers
{
    public class OnePieceCardTypeParser : CardTypeParser
    {
        public override List<CardType> Recognize(List<Card> cards)
        {
            var result = new List<CardType>();
            CardsDic.Keys.ToList().ForEach(key => CardsDic[key].Clear());

            cards.ForEach(card => CardsDic[card.Num].Add(card));

            var keysMore1 = new List<CardNum>();

            CardsDic
                .ToList()
                .ForEach(dic =>
                {
                    if (dic.Value.Count > 0)
                    {
                        keysMore1.Add(dic.Key);
                    }
                });

            if (keysMore1.Count > 5)
            {
                keysMore1
                    .Combination(5)
                    .ToList()
                    .ForEach(comb5 =>
                    {
                        var cardNums = comb5 as IList<CardNum> ?? comb5.ToList();
                        CardsDic[cardNums.ToList()[0]]
                            .ToList()
                            .ForEach(card1 =>
                                     CardsDic[cardNums.ToList()[1]]
                                         .ToList()
                                         .ForEach(card2 =>
                                                  CardsDic[cardNums.ToList()[2]]
                                                      .ToList()
                                                      .ForEach(card3 =>
                                                               CardsDic[cardNums.ToList()[3]]
                                                                   .ToList()
                                                                   .ForEach(card4 =>
                                                                            CardsDic[cardNums.ToList()[4]]
                                                                                .ToList()
                                                                                .ForEach(card5 =>
                                                                                         result.Add(new NoTypeCardType
                                                                                                        (
                                                                                                        new List
                                                                                                            <Card>
                                                                                                                {
                                                                                                                    card1,
                                                                                                                    card2,
                                                                                                                    card3,
                                                                                                                    card4,
                                                                                                                    card5
                                                                                                                }
                                                                                                        )))))));
                    });
            }

            return result;
        }
    }
}

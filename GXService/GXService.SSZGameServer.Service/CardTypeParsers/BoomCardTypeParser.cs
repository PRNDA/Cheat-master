using System.Collections.Generic;
using System.Linq;
using GXService.CardRecognize.Contract;
using GXService.SSZGameServer.CardTypeParseService.Contract;

namespace GXService.SSZGameServer.CardTypeParseService.Service.CardTypeParsers
{
    /// <summary>
    /// 炸弹
    /// </summary>
    public class BoomCardTypeParser : CardTypeParser
    {
        public override List<CardType> Recognize(List<Card> cards)
        {
            var result = new List<CardType>();
            CardsDic.Keys.ToList().ForEach(key => CardsDic[key].Clear());

            cards.ForEach(card => CardsDic[card.Num].Add(card));

            var keysMore1 = new List<CardNum>();
            var keysMore4 = new List<CardNum>();

            CardsDic.ToList()
                    .ForEach(dic =>
                    {
                        if (dic.Value.Count <= 0)
                        {
                            return;
                        }

                        keysMore1.Add(dic.Key);

                        if (dic.Value.Count >= 4)
                        {
                            keysMore4.Add(dic.Key);
                        }
                    });

            keysMore4
                .ForEach(key4 =>
                         keysMore1
                             .Where(key1 => key1 != key4)
                             .ToList()
                             .ForEach(key1 =>
                                      CardsDic[key1]
                                          .ForEach(card1 =>
                                          {
                                              var cardsType = CardsDic[key4].ToList();
                                              cardsType.Add(card1);
                                              result.Add(new BoomCardType(cardsType));
                                          })));
            return result;
        }
    }

}

using System.Collections.Generic;
using System.Linq;
using GXService.CardRecognize.Contract;
using GXService.SSZGameServer.Contract;

namespace GXService.SSZGameServer.Service.CardTypeParsers
{
    /// <summary>
    /// 顺子
    /// </summary>
    public class StraightCardTypeParser : CardTypeParser
    {
        public override List<CardType> Recognize(List<Card> cards)
        {
            var result = new List<CardType>();
            CardsDic.Keys.ToList().ForEach(key => CardsDic[key].Clear());

            cards.ForEach(card => CardsDic[card.Num].Add(card));

            var keys = new List<CardNum>();

            CardsDic
                .Where(dic => dic.Key != CardNum._2).ToList()
                .ForEach(dic =>
                {
                    if (dic.Value.Count > 0)
                    {
                        keys.Add(dic.Key);
                    }

                    if (dic.Value.Count <= 0 || keys.Count >= 13)
                    {
                        while (keys.Count >= 5)
                        {
                            CardsDic[keys[0]]
                                .ForEach(
                                    card1 =>
                                    CardsDic[keys[1]]
                                        .ForEach(
                                            card2 =>
                                            CardsDic[keys[2]]
                                                .ForEach(
                                                    card3 =>
                                                    CardsDic[keys[3]]
                                                        .ForEach(
                                                            card4 =>
                                                            CardsDic[keys[4]]
                                                                .ForEach(
                                                                    card5 =>
                                                                    result.Add(new StraightCardType(new List<Card>
                                                                                    {
                                                                                        card1,
                                                                                        card2,
                                                                                        card3,
                                                                                        card4,
                                                                                        card5
                                                                                    }
                                                                        ))
                                                                )))));
                            keys.RemoveAt(0);
                        }

                        keys.Clear();
                    }
                });

            return result;
        }
    }
}

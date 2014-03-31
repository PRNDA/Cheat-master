using System.Collections.Generic;
using System.Linq;
using GXService.CardRecognize.Contract;
using GXService.SSZGameServer.Contract;
using GXService.Utils;

namespace GXService.SSZGameServer.Service.CardTypeParsers
{
    /// <summary>
    /// 同花
    /// </summary>
    public class FlushCardTypeParser : CardTypeParser
    {
        public override List<CardType> Recognize(List<Card> cards)
        {
            var result = new List<CardType>();
            CardsDic.Keys.ToList().ForEach(key => CardsDic[key].Clear());

            var flushDic = new Dictionary<CardColor, List<Card>>
                {
                    {CardColor.黑桃, new List<Card>()},
                    {CardColor.红桃, new List<Card>()},
                    {CardColor.梅花, new List<Card>()},
                    {CardColor.方块, new List<Card>()}
                };

            cards.ForEach(card => flushDic[card.Color].Add(card));

            flushDic.ToList()
                    .ForEach(dic =>
                    {
                        if (dic.Value.Count >= 5)
                        {
                            dic.Value
                               .Combination(5)
                               .ToList()
                               .ForEach(flush => result.Add(new FlushCardType(flush.ToList())));
                        }
                    });

            return result;
        }
    }
}

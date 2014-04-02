using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using GXService.CardRecognize.Contract;
using GXService.SSZGameServer.CardTypeParseService.Contract;
using GXService.SSZGameServer.CardTypeParseService.Service.CardTypeParsers;

namespace GXService.SSZGameServer.CardTypeParseService.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, IncludeExceptionDetailInFaults = true)]
    public class CardTypeParseService : ICardTypeParseService
    {
        private readonly List<CardTypeParser> _recognizers = new List<CardTypeParser>
        {
            new StraightFlushCardTypeParser(),
            new BoomCardTypeParser(),
            new GourdCardTypeParser(),
            new FlushCardTypeParser(),
            new StraightCardTypeParser(),
            new ThreeSameCardTypeParser(),
            new TwoDoubleCardTypeParser(),
            new DoubleCardTypeParser(),
            new OnePieceCardTypeParser()
        };

        public void Connect()
        {
            
        }

        public void Disconnect()
        {
            
        }

        /// <summary>
        /// 根据当前牌解析出最优牌型
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public CardTypeResult ParseCardType(List<Card> cards)
        {
            return GetBestResult(ParseCardTypeResult(cards));
        }

        /// <summary>
        /// 根据敌方牌解析出最优牌型
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="cardsEnemy"></param>
        /// <returns></returns>
        public CardTypeResult ParseCardTypeVsEnemy(List<Card> cards, List<Card> cardsEnemy)
        {
            return GetBestResult(ParseCardType(cards), ParseCardTypeResult(cards));
        }

        private List<CardTypeResult> ParseCardTypeResult(IEnumerable<Card> cards)
        {
            var result = new List<CardTypeResult>();
            var resultTmp = new List<CardType>();
            var tmp = cards.ToList();

            _recognizers.Where(rec => !(rec is OnePieceCardTypeParser))
                        .ToList()
                        .ForEach(rec => resultTmp.AddRange(rec.Recognize(tmp)));

            resultTmp.ForEach(bodyType =>
            {
                var tmpCards = tmp.FindAll(card => !bodyType.GetCards().Contains(card)).ToList();
                _recognizers
                    .ForEach(rec =>
                             rec.Recognize(tmpCards)
                                .ForEach(tailType =>
                                {
                                    var headType = HeadCardTypeFactory.GetSingleton()
                                                                      .GetHeadCardType(tmp.FindAll(
                                                                          card =>
                                                                          !bodyType.GetCards().Contains(card) &&
                                                                          !tailType.GetCards().Contains(card))
                                                                                          .ToList());
                                    if (tailType.Compare(bodyType, EmRegionCompare.Tail) >= 0 && bodyType.CompareTypeRule(headType) >= 0)
                                    {
                                        result.Add(new CardTypeResult(headType, bodyType, tailType));
                                    }
                                }));
            });

            return result;
        }

        private static CardTypeResult GetBestResult(List<CardTypeResult> results)
        {
            CardTypeResult best = null;
            results.ForEach(ctr =>
            {
                best = best == null
                    ? ctr
                    : (best.Compare(ctr) >= 0
                        ? best
                        : ctr);
            });
            return best;
        }

        private static CardTypeResult GetBestResult(CardTypeResult bestResult, List<CardTypeResult> resultsEnemy)
        {
            resultsEnemy.ForEach(res =>
            {
                bestResult = bestResult.Compare(res) >= 0
                    ? bestResult
                    : res;
            });
            return bestResult;
        }
    }
}

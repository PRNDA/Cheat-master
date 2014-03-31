using System.Collections.Generic;
using System.ServiceModel;
using GXService.CardRecognize.Contract;

namespace GXService.SSZGameServer.Contract
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ICardTypeParseService
    {
        [OperationContract(IsOneWay = true, IsInitiating = true, IsTerminating = false)]
        void Connect();

        [OperationContract]
        CardTypeResult ParseCardType(List<Card> cards);

        [OperationContract]
        CardTypeResult ParseCardTypeVsEnemy(List<Card> cards, List<Card> cardsEnemy);

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void Disconnect();
    }
}

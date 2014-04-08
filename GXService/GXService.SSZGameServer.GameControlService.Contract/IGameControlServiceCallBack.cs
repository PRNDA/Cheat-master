using System.ServiceModel;
using GXService.SSZGameServer.CardTypeParseService.Contract;
using GXService.GameServer;

namespace GXService.SSZGameServer.GameControlService.Contract
{
    public interface IGameControlServiceCallBack
    {
        /// <summary>
        /// 开始识别回调
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void OnStartRecognize();

        /// <summary>
        /// 有客户端的牌型解析完成回调
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="cardTypeResult"></param>
        [OperationContract(IsOneWay = true)]
        void OnRecognized(ClientInfo clientInfo, CardTypeResult cardTypeResult);
    }
}

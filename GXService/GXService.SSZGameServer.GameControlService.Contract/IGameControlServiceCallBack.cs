using System.ServiceModel;
using GXService.CardRecognize.Contract;
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
        /// 客户端的牌识别完成回调
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="recognizeResult"></param>
        [OperationContract(IsOneWay = true)]
        void OnRecognized(ClientInfo clientInfo, RecognizeResult recognizeResult);
    }
}

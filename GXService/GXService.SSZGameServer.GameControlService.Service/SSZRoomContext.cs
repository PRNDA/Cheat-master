using System.Linq;
using GXService.CardRecognize.Contract;
using GXService.GameServer;
using GXService.SSZGameServer.GameControlService.Contract;

namespace GXService.SSZGameServer.GameControlService.Service
{
    public class SSZRoomContext : RoomContext<IGameControlServiceCallBack>
    {
        public void StartRecognize()
        {
            //并行回调所有客户端的回调接口，将开始识别扑克牌动作广播到当前房间内的各个客户端
            ClientContexts.AsParallel().ForAll(c => c.GameServerCallBack.OnStartRecognize());
        }

        public void Recognized(ClientInfo clientInfo, RecognizeResult recognizeResult)
        {
            //并行回调所有客户端的回调接口，将数据广播到当前房间内的各个客户端
            ClientContexts.AsParallel().ForAll(c => c.GameServerCallBack.OnRecognized(clientInfo, recognizeResult));
        }
    }
}

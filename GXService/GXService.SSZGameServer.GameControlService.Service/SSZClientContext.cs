using GXService.GameServer;
using GXService.SSZGameServer.GameControlService.Contract;

namespace GXService.SSZGameServer.GameControlService.Service
{
    public class SSZClientContext : ClientContext<IGameControlServiceCallBack>
    {
        public SSZClientContext(string sessionId, IGameControlServiceCallBack gameServerCallBack, ClientInfo clientInfo, RoomContext<IGameControlServiceCallBack> roomContext = null)
            : base(sessionId, gameServerCallBack, clientInfo, roomContext)
        {}


        public override bool CreateRoom()
        {
            LeaveRoom();

            RoomContext = RoomFactory<SSZRoomContext, IGameControlServiceCallBack>.Singleton.CreateRoom();

            return null != RoomContext && RoomContext.Enter(this);
        }

        public override bool EnterRoom(string roomId)
        {
            LeaveRoom();

            RoomContext = RoomFactory<SSZRoomContext, IGameControlServiceCallBack>.Singleton.GetRoom(roomId);

            return null != RoomContext && RoomContext.Enter(this);
        }
    }
}

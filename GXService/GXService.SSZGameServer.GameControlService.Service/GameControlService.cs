using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using GXService.GameServer;
using GXService.SSZGameServer.GameControlService.Contract;

namespace GXService.SSZGameServer.GameControlService.Service
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, Namespace = "GXService.SSZGameServer.GameControlService.Service")]
    public class GameControlService : IGameControlService
    {
        private ClientContext<IGameControlServiceCallBack> _clientContext;

        public void Connect(ClientInfo clientInfo)
        {
            _clientContext = ClientFactory<SSZClientContext, IGameControlServiceCallBack>.Singleton.GetClient(clientInfo);

            OperationContext.Current.Channel.Closing += (sender, args) => Disconnect();
        }

        public bool CreateRoom()
        {
            return _clientContext.CreateRoom();
        }

        public bool EnterRoom(string roomId)
        {
            return _clientContext.EnterRoom(roomId);
        }

        public List<RoomInfo> GetRoomInfos()
        {
            return RoomFactory<SSZRoomContext, IGameControlServiceCallBack>.Singleton.GetAllRoom().Select(r => r.GetRoomInfo()).ToList();
        }

        public void Execute(Command cmd)
        {
            _clientContext.Execute(cmd);
        }

        public void Disconnect()
        {
            _clientContext.LeaveRoom();
            ClientFactory<SSZClientContext, IGameControlServiceCallBack>.Singleton.RemoveClient(_clientContext);
        }

    }
}

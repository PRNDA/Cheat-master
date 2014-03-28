using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using GXService.Broadcast.Contract;
using GXService.Broadcast.Service.Models;

namespace GXService.Broadcast.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, Namespace = "GXService.Broadcast")]
    public class BroadcastService : IBroadcast
    {
        private ClientInfo _clientInfo;

        private RoomContext _currentRoomContext;

        public bool CreateRoom(ClientInfo clientInfo)
        {
            //如果当前在房间内，则退出房间
            if (null != _currentRoomContext)
            {
                _currentRoomContext.Leave(GetClientContext());
            }

            //创建房间
            _currentRoomContext = RoomFactory.Singleton.CreateRoom();
            if (null == _currentRoomContext)
            {
                return false;
            }

            _clientInfo = clientInfo;

            //进入房间
            return _currentRoomContext.Enter(GetClientContext());
        }

        public bool EnterRoom(RoomInfo roomInfo, ClientInfo clientInfo)
        {
            if (null != _currentRoomContext)
            {
                _currentRoomContext.Leave(GetClientContext());
            }

            _currentRoomContext = RoomFactory.Singleton.GetRoom(roomInfo.RoomId);
            if (null == _currentRoomContext)
            {
                return false;
            }

            _clientInfo = clientInfo;

            return _currentRoomContext.Enter(GetClientContext());
        }

        public List<RoomInfo> GetRoomInfos()
        {
            return RoomFactory.Singleton.GetAllRoom().Select(r => r.GetRoomInfo()).ToList();
        }

        public void Broadcast(byte[] data)
        {
            _currentRoomContext.Broadcast(data);
        }

        public void Disconnect()
        {
            if (null != _currentRoomContext)
            {
                _currentRoomContext.Leave(GetClientContext());
            }
        }

        private ClientContext GetClientContext()
        {
            var currentSessionId = OperationContext.Current.SessionId;
            var clientContext = ClientFactory.Singleton.GetClient(currentSessionId);
            if (clientContext != null)
            {
                return clientContext;
            }

            var callBack = OperationContext.Current.GetCallbackChannel<IBroadcastCallBack>();
            if (callBack != null && !string.IsNullOrEmpty(currentSessionId))
            {
                clientContext = new ClientContext
                {
                    SessionId = currentSessionId,
                    BroadcastCallBack = callBack,
                    ClientInfo = _clientInfo
                };

                OperationContext.Current.Channel.Closing += (sender, args) => Disconnect();

                ClientFactory.Singleton.AddClient(clientContext);

                return clientContext;
            }

            return null;
        }
    }
}

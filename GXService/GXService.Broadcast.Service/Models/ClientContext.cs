using System;
using GXService.Broadcast.Contract;

namespace GXService.Broadcast.Service.Models
{
    public class ClientContext : IEquatable<ClientContext>
    {
        public string SessionId { get; private set; }

        public IBroadcastCallBack BroadcastCallBack { get; private set; }

        public ClientInfo ClientInfo { get; private set; }

        public RoomContext RoomContext { get; private set; }

        public ClientContext(string sessionId, IBroadcastCallBack broadcastCallBack, ClientInfo clientInfo, RoomContext roomContext = null)
        {
            SessionId = sessionId;
            BroadcastCallBack = broadcastCallBack;
            ClientInfo = clientInfo;
            RoomContext = roomContext;
        }

        public bool CreateRoom()
        {
            LeaveRoom();

            RoomContext = RoomFactory.Singleton.CreateRoom();
            
            return null != RoomContext && RoomContext.Enter(this);
        }

        public bool EnterRoom(string roomId)
        {
            LeaveRoom();

            RoomContext = RoomFactory.Singleton.GetRoom(roomId);

            return null != RoomContext && RoomContext.Enter(this);
        }

        public void LeaveRoom()
        {
            if (RoomContext != null)
            {
                RoomContext.Leave(this);
                RoomContext = null;
            }   
        }

        public void Execute(Command cmd)
        {
            if (RoomContext != null)
            {
                RoomContext.Execute(cmd);
            }
        }

        #region IEquatable接口实现
        public bool Equals(ClientContext clientContext)
        {
            if (clientContext == null)
            {
                return false;
            }

            if (ReferenceEquals(this, clientContext))
            {
                return true;
            }

            return SessionId == clientContext.SessionId
                   && BroadcastCallBack == clientContext.BroadcastCallBack
                   && ClientInfo == clientContext.ClientInfo;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ClientContext);
        }

        public override int GetHashCode()
        {
            return SessionId.GetHashCode() ^ BroadcastCallBack.GetHashCode() ^ ClientInfo.GetHashCode();
        }

        public static bool operator ==(ClientContext clientContext1, ClientContext clientContext2)
        {
            if ((object)clientContext1 == null && (object)clientContext2 == null)
            {
                return true;
            }

            return null != (object)clientContext1 && clientContext1.Equals(clientContext2);
        }

        public static bool operator !=(ClientContext clientContext1, ClientContext clientContext2)
        {
            if ((object)clientContext1 == null && (object)clientContext2 == null)
            {
                return false;
            }

            return !(null != (object)clientContext1 && clientContext1.Equals(clientContext2));
        }
        #endregion
    }
}

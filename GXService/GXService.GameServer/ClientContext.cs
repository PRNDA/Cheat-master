using System;

namespace GXService.GameServer
{
    public abstract class ClientContext<TI> : IEquatable<ClientContext<TI>> where TI : class
    {
        public string SessionId { get; protected set; }

        public TI GameServerCallBack { get; protected set; }

        public ClientInfo ClientInfo { get; protected set; }

        public RoomContext<TI> RoomContext { get; protected set; }

        protected ClientContext(string sessionId, TI gameServerCallBack, ClientInfo clientInfo, RoomContext<TI> roomContext = null)
        {
            SessionId = sessionId;
            GameServerCallBack = gameServerCallBack;
            ClientInfo = clientInfo;
            RoomContext = roomContext;
        }

        public abstract bool CreateRoom();

        public abstract bool EnterRoom(string roomId);

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
        public bool Equals(ClientContext<TI> clientContext)
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
                   && GameServerCallBack.Equals(clientContext.GameServerCallBack)
                   && ClientInfo == clientContext.ClientInfo;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ClientContext<TI>);
        }

        public override int GetHashCode()
        {
            return SessionId.GetHashCode() ^ GameServerCallBack.GetHashCode() ^ ClientInfo.GetHashCode();
        }

        public static bool operator ==(ClientContext<TI> clientContext1, ClientContext<TI> clientContext2)
        {
            if ((object)clientContext1 == null && (object)clientContext2 == null)
            {
                return true;
            }

            return null != (object)clientContext1 && clientContext1.Equals(clientContext2);
        }

        public static bool operator !=(ClientContext<TI> clientContext1, ClientContext<TI> clientContext2)
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

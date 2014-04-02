using System;
using System.Collections.Generic;
using System.Linq;
using GXService.Utils;

namespace GXService.GameServer
{
    public abstract class RoomContext<TI> where TI : class 
    {
        public string RoomId { get; private set; }

        protected readonly List<ClientContext<TI>> ClientContexts = new List<ClientContext<TI>>();

        protected const int MaxClient = 3;

        protected RoomContext()
        {
            RoomId = Guid.NewGuid().ToString("N");
        }

        public bool Enter(ClientContext<TI> clientContext)
        {
            if (null == clientContext || ClientContexts.Count >= MaxClient)
            {
                return false;
            }

            ClientContexts.Add(clientContext);

            return true;
        }

        public void Leave(ClientContext<TI> clientContext)
        {
            if (null == clientContext)
            {
                return;
            }

            ClientContexts.Remove(clientContext);
        }

        public abstract void Execute(Command cmd);

        public RoomInfo GetRoomInfo()
        {
            return new RoomInfo
            {
                RoomId = RoomId,
                ClientInfos = ClientContexts.Select(c => c.ClientInfo).ToList()
            };
        }

        public List<ClientContext<TI>> GetAllClientContexts()
        {
            return ClientContexts.ToList();
        }

        #region IEquatable接口实现
        private readonly ListValueComparer<ClientContext<TI>> _clientContextListValueComparer = new ListValueComparer<ClientContext<TI>>();
        public bool Equals(RoomContext<TI> roomContext)
        {
            if (roomContext == null)
            {
                return false;
            }

            if (ReferenceEquals(this, roomContext))
            {
                return true;
            }

            return RoomId == roomContext.RoomId
                   && _clientContextListValueComparer.Equals(ClientContexts, roomContext.ClientContexts);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RoomContext<TI>);
        }

        public override int GetHashCode()
        {
            return RoomId.GetHashCode() ^ _clientContextListValueComparer.GetHashCode(ClientContexts.ToList());
        }

        public static bool operator ==(RoomContext<TI> roomContext1, RoomContext<TI> roomContext2)
        {
            if ((object)roomContext1 == null && (object)roomContext2 == null)
            {
                return true;
            }

            return null != (object)roomContext1 && roomContext1.Equals(roomContext2);
        }

        public static bool operator !=(RoomContext<TI> roomContext1, RoomContext<TI> roomContext2)
        {
            if ((object)roomContext1 == null && (object)roomContext2 == null)
            {
                return false;
            }

            return !(null != (object)roomContext1 && roomContext1.Equals(roomContext2));
        }
        #endregion
    }
}

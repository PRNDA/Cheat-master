using System;
using System.Collections.Generic;
using System.Linq;
using GXService.Broadcast.Contract;
using GXService.Utils;

namespace GXService.Broadcast.Service.Models
{
    public class RoomContext
    {
        public string RoomId { get; private set; }

        private readonly List<ClientContext> _clientContexts = new List<ClientContext>();

        private const int MaxClient = 3;

        public RoomContext()
        {
            RoomId = Guid.NewGuid().ToString("N");
        }

        public bool Enter(ClientContext clientContext)
        {
            if (null == clientContext || _clientContexts.Count >= MaxClient)
            {
                return false;
            }

            _clientContexts.Add(clientContext);

            return true;
        }

        public void Leave(ClientContext clientContext)
        {
            if (null == clientContext)
            {
                return;
            }

            _clientContexts.Remove(clientContext);
        }

        public void Broadcast(byte[] data)
        {
            //并行回调所有客户端的回调接口，将数据广播到当前房间内的各个客户端
            _clientContexts.AsParallel().ForAll(c => c.BroadcastCallBack.OnDataBroadcast(data));
        }

        public RoomInfo GetRoomInfo()
        {
            return new RoomInfo
            {
                RoomId = RoomId,
                ClientInfos = _clientContexts.Select(c => c.ClientInfo).ToList()
            };
        }



        #region IEquatable接口实现
        private readonly ListValueComparer<ClientContext> _clientContextListValueComparer = new ListValueComparer<ClientContext>();
        public bool Equals(RoomContext roomContext)
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
                   && _clientContextListValueComparer.Equals(_clientContexts, roomContext._clientContexts);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RoomContext);
        }

        public override int GetHashCode()
        {
            return RoomId.GetHashCode() ^ _clientContextListValueComparer.GetHashCode(_clientContexts.ToList());
        }

        public static bool operator ==(RoomContext roomContext1, RoomContext roomContext2)
        {
            if ((object)roomContext1 == null && (object)roomContext2 == null)
            {
                return true;
            }

            return null != (object)roomContext1 && roomContext1.Equals(roomContext2);
        }

        public static bool operator !=(RoomContext roomContext1, RoomContext roomContext2)
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

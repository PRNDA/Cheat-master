using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GXService.Utils;

namespace GXService.Broadcast.Contract
{
    [DataContract(Namespace = "GXService.Broadcast.Contract")]
    public class RoomInfo : IEquatable<RoomInfo>
    {
        [DataMember]
        public string RoomId { get; set; }

        [DataMember]
        public List<ClientInfo> ClientInfos { get; set; }

        #region IEquatable接口实现
        private readonly ListValueComparer<ClientInfo> _clientInfoListValueComparer = new ListValueComparer<ClientInfo>();

        public bool Equals(RoomInfo roomInfo)
        {
            if (roomInfo == null)
            {
                return false;
            }

            if (ReferenceEquals(this, roomInfo))
            {
                return true;
            }

            return RoomId == roomInfo.RoomId && _clientInfoListValueComparer.Equals(ClientInfos, roomInfo.ClientInfos);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RoomInfo);
        }

        public override int GetHashCode()
        {
            return RoomId.GetHashCode() ^ _clientInfoListValueComparer.GetHashCode(ClientInfos.ToList());
        }

        public static bool operator ==(RoomInfo roomInfo1, RoomInfo roomInfo2)
        {
            if ((object)roomInfo1 == null && (object)roomInfo2 == null)
            {
                return true;
            }

            return null != (object)roomInfo1 && roomInfo1.Equals(roomInfo2);
        }

        public static bool operator !=(RoomInfo roomInfo1, RoomInfo roomInfo2)
        {
            if ((object)roomInfo1 == null && (object)roomInfo2 == null)
            {
                return false;
            }

            return !(null != (object)roomInfo1 && roomInfo1.Equals(roomInfo2));
        }
        #endregion
    }
}

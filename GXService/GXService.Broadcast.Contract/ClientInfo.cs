using System;
using System.Runtime.Serialization;

namespace GXService.Broadcast.Contract
{
    [DataContract(Namespace = "GXService.Broadcast.Contract")]
    public class ClientInfo : IEquatable<ClientInfo>
    {
        [DataMember]
        public string PlayerName { get; set; }

        #region IEquatable接口实现
        public bool Equals(ClientInfo clientInfo)
        {
            if (clientInfo == null)
            {
                return false;
            }

            if (ReferenceEquals(this, clientInfo))
            {
                return true;
            }

            return PlayerName == clientInfo.PlayerName;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ClientInfo);
        }

        public override int GetHashCode()
        {
            return PlayerName.GetHashCode();
        }

        public static bool operator ==(ClientInfo clientInfo1, ClientInfo clientInfo2)
        {
            if ((object)clientInfo1 == null && (object)clientInfo2 == null)
            {
                return true;
            }

            return null != (object)clientInfo1 && clientInfo1.Equals(clientInfo2);
        }

        public static bool operator !=(ClientInfo clientInfo1, ClientInfo clientInfo2)
        {
            if ((object)clientInfo1 == null && (object)clientInfo2 == null)
            {
                return false;
            }

            return !(null != (object)clientInfo1 && clientInfo1.Equals(clientInfo2));
        }
        #endregion
    }
}

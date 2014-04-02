using System.Runtime.Serialization;

namespace GXService.GameServer
{
    [DataContract(Namespace = "GXService.GameServer")]
    public class Command
    {
        [DataMember]
        public int CommandType { get; set; }

        [DataMember]
        public byte[] Data { get; set; }
    }
}

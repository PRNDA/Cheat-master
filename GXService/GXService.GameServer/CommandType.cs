using System.Runtime.Serialization;

namespace GXService.GameServer
{
    [DataContract(Namespace = "GXService.GameServer")]
    public class CommandType
    {
        public const int 数据广播 = 0;
        public const int 开始识别 = 1;
    }
}

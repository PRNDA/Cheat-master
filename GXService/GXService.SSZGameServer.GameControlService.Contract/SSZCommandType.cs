using System.Runtime.Serialization;
using GXService.GameServer;

namespace GXService.SSZGameServer.GameControlService.Contract
{
    [DataContract(Namespace = "GXService.SSZGameServer.GameControlService.Contract")]
    public class SSZCommandType : CommandType
    {
        [DataMember] public const int 开始识别 = 0;
        [DataMember] public const int 识别完成 = 1;
    }
}

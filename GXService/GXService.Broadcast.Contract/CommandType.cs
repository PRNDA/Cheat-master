using System.Runtime.Serialization;

namespace GXService.Broadcast.Contract
{
    [DataContract(Namespace = "GXService.Broadcast.Contract")]
    public enum CommandType
    {
        数据广播,
        开始识别
    }
}

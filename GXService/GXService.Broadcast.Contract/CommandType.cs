﻿using System.Runtime.Serialization;

namespace GXService.Broadcast.Contract
{
    [DataContract(Namespace = "GXService.Broadcast.Contract")]
    public static class CommandType
    {
        public const int 数据广播 = 0;
        public const int 开始识别 = 1;
    }
}

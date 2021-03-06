﻿using System.Runtime.Serialization;

namespace GXService.Broadcast.Contract
{
    [DataContract(Namespace = "GXService.Broadcast.Contract")]
    public class Command
    {
        [DataMember]
        public int CommandType { get; set; }

        [DataMember]
        public byte[] Data { get; set; }
    }
}

﻿using System.Linq;
using GXService.GameServer;
using GXService.SSZGameServer.GameControlService.Contract;

namespace GXService.SSZGameServer.GameControlService.Service
{
    public class SSZRoomContext : RoomContext<IGameControlServiceCallBack>
    {
        public override void Execute(Command cmd)
        {
            switch (cmd.CommandType)
            {
                case CommandType.数据广播:
                    //并行回调所有客户端的回调接口，将数据广播到当前房间内的各个客户端
                    ClientContexts.AsParallel().ForAll(c => c.GameServerCallBack.OnDataBroadcast(cmd.Data));
                    break;

                case CommandType.开始识别:
                    //并行回调所有客户端的回调接口，将开始识别扑克牌动作广播到当前房间内的各个客户端
                    ClientContexts.AsParallel().ForAll(c => c.GameServerCallBack.OnStartRecognize());
                    break;
            }
        }
    }
}

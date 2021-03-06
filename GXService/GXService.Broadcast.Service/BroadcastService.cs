﻿using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using GXService.Broadcast.Contract;
using GXService.Broadcast.Service.Models;

namespace GXService.Broadcast.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, Namespace = "GXService.Broadcast")]
    public class BroadcastService : IBroadcast
    {
        private ClientContext _clientContext;

        public void Connect(ClientInfo clientInfo)
        {
            _clientContext = ClientFactory.Singleton.GetClient(clientInfo);

            OperationContext.Current.Channel.Closing += (sender, args) => Disconnect();
        }

        public bool CreateRoom()
        {
            return _clientContext.CreateRoom();
        }

        public bool EnterRoom(string roomId)
        {
            return _clientContext.EnterRoom(roomId);
        }

        public List<RoomInfo> GetRoomInfos()
        {
            return RoomFactory.Singleton.GetAllRoom().Select(r => r.GetRoomInfo()).ToList();
        }

        public void Execute(Command cmd)
        {
            _clientContext.Execute(cmd);
        }

        public void Disconnect()
        {
            _clientContext.LeaveRoom();
            ClientFactory.Singleton.RemoveClient(_clientContext);
        }

    }
}

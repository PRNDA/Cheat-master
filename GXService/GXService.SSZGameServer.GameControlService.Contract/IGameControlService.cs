using System.Collections.Generic;
using System.ServiceModel;
using GXService.GameServer;

namespace GXService.SSZGameServer.GameControlService.Contract
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IGameControlServiceCallBack))]
    public interface IGameControlService
    {
        [OperationContract(IsOneWay = true, IsInitiating = true, IsTerminating = false)]
        void Connect(ClientInfo clientInfo);

        [OperationContract]
        bool CreateRoom();

        [OperationContract]
        bool EnterRoom(string roomId);

        [OperationContract]
        List<RoomInfo> GetRoomInfos();

        [OperationContract]
        void Execute(Command cmd);

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void Disconnect();
    }
}

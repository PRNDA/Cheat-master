using System.Collections.Generic;
using System.ServiceModel;

namespace GXService.Broadcast.Contract
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IBroadcastCallBack))]
    public interface IBroadcast
    {
        [OperationContract(IsOneWay = true, IsInitiating = true, IsTerminating = false)]
        bool CreateRoom(ClientInfo clientInfo);

        [OperationContract(IsOneWay = true, IsInitiating = true, IsTerminating = false)]
        bool EnterRoom(RoomInfo roomInfo, ClientInfo clientInfo);

        [OperationContract]
        List<RoomInfo> GetRoomInfos();
        
        [OperationContract]
        void Broadcast(byte[] data);

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void Disconnect();
    }
}

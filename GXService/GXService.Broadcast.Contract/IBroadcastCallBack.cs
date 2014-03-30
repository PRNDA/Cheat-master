using System.ServiceModel;

namespace GXService.Broadcast.Contract
{
    public interface IBroadcastCallBack
    {
        /// <summary>
        /// 广播数据回调
        /// </summary>
        /// <param name="data"></param>
        [OperationContract(IsOneWay = true)]
        void OnDataBroadcast(byte[] data);

        /// <summary>
        /// 开始识别回调
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void OnStartRecognize();
    }
}

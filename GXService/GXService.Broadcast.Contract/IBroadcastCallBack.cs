using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GXService.Broadcast.Contract
{
    public interface IBroadcastCallBack
    {
        [OperationContract(IsOneWay = true)]
        void OnDataBroadcast(byte[] data);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace GXService.CardRecognize.Service
{
    public class GXServiceErrorHandler : IErrorHandler
    {
        private static ILog _log = LogManager.GetLogger("GXService");

        public bool HandleError(Exception ex)
        {
            return true;
        }

        public void ProvideFault(Exception ex, MessageVersion version, ref Message msg)
        {
            _log.Error(ex);

            var newEx = new FaultException((ex.InnerException ?? ex).ToString());
            var msgFault = newEx.CreateMessageFault();
            msg = Message.CreateMessage(version, msgFault, newEx.Action);
        }
    }
}

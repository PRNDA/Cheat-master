using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GXService.Broadcast.Contract;
using GXService.Broadcast.Service.Models;

namespace GXService.Broadcast.Service
{
    public class ClientFactory
    {
        private readonly List<ClientContext> _clientContexts = new List<ClientContext>();

        public static ClientFactory Singleton = new ClientFactory();

        private ClientFactory()
        {}

        public ClientContext GetCurrentClient()
        {
            return _clientContexts.FirstOrDefault(c => c.SessionId == OperationContext.Current.SessionId);
        }

        public List<ClientContext> GetAllClients()
        {
            return _clientContexts.ToList();
        }

        public void AddClient(ClientContext clientContext)
        {
            _clientContexts.Add(clientContext);
        }

        public void RemoveClient(ClientContext clientContext)
        {
            _clientContexts.Remove(clientContext);
        }

        public ClientContext GetClient(ClientInfo clientInfo)
        {
            var clientContext = GetCurrentClient();
            if (clientContext != null)
            {
                return clientContext;
            }

            var currentSessionId = OperationContext.Current.SessionId;
            var callBack = OperationContext.Current.GetCallbackChannel<IBroadcastCallBack>();
            if (callBack != null && !string.IsNullOrEmpty(currentSessionId))
            {
                clientContext = new ClientContext(currentSessionId, callBack, clientInfo);
                AddClient(clientContext);

                return clientContext;
            }

            return null;
        }
    }
}

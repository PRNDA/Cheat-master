using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace GXService.GameServer
{
    public class ClientFactory<T, TI> 
        where T : ClientContext<TI>
        where TI : class 
    {
        private readonly List<ClientContext<TI>> _clientContexts = new List<ClientContext<TI>>();

        public static ClientFactory<T, TI> Singleton = new ClientFactory<T, TI>();

        private ClientFactory()
        {}

        public ClientContext<TI> GetCurrentClient()
        {
            return _clientContexts.FirstOrDefault(c => c.SessionId == OperationContext.Current.SessionId);
        }

        public List<ClientContext<TI>> GetAllClients()
        {
            return _clientContexts.ToList();
        }

        public void AddClient(ClientContext<TI> clientContext)
        {
            _clientContexts.Add(clientContext);
        }

        public void RemoveClient(ClientContext<TI> clientContext)
        {
            _clientContexts.Remove(clientContext);
        }

        public ClientContext<TI> GetClient(ClientInfo clientInfo)
        {
            var clientContext = GetCurrentClient();
            if (clientContext != null)
            {
                return clientContext;
            }

            var currentSessionId = OperationContext.Current.SessionId;
            var callBack = OperationContext.Current.GetCallbackChannel<TI>();
            if (callBack != null && !string.IsNullOrEmpty(currentSessionId))
            {
                //获取构造函数
                var c = typeof(T).GetConstructor(new[] { typeof(string), typeof(TI), typeof(ClientInfo), typeof(RoomContext<TI>) });
                if (c == null)
                {
                    return null;
                }
                clientContext = c.Invoke(new object[] {currentSessionId, callBack, clientInfo}) as T;
                AddClient(clientContext);

                return clientContext;
            }

            return null;
        }
    }
}

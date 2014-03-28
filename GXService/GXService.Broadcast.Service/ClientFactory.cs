using System;
using System.Collections.Generic;
using System.Linq;
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

        public ClientContext GetClient(string sessionId)
        {
            return _clientContexts.FirstOrDefault(c => c.SessionId == sessionId);
        }

        public List<ClientContext> GetAllClients()
        {
            return _clientContexts.ToList();
        }

        public void AddClient(ClientContext clientContext)
        {
            _clientContexts.Add(clientContext);
        }
    }
}

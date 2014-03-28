using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace GXService.CardRecognize.Service
{
    public class GXServiceErrorHandlerBehaviorAttribute : Attribute, IServiceBehavior
    {
        private readonly Type _errorHandlerType;

        public GXServiceErrorHandlerBehaviorAttribute(Type errorHandlerType)
        {
            _errorHandlerType = errorHandlerType;
        }

        public void Validate(ServiceDescription description, ServiceHostBase serviceHostBase)
        {
            
        }

        public void AddBindingParameters(ServiceDescription description, ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints, BindingParameterCollection parameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase serviceHostBase)
        {
            var handler = (IErrorHandler) Activator.CreateInstance(_errorHandlerType);
            foreach (var channelDispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>())
            {
                channelDispatcher.ErrorHandlers.Add(handler);
            }
        }
    }
}

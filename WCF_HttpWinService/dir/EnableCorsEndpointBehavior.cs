using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace WCF_HttpsWinService {
    public class EnableCorsEndpointBehavior:IEndpointBehavior {
        public void AddBindingParameters(ServiceEndpoint endpoint,BindingParameterCollection bindingParameters) {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint,ClientRuntime clientRuntime) {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint,EndpointDispatcher endpointDispatcher) {
            List<OperationDescription> corsEnabledOperations = endpoint.Contract.Operations.Where(o => o.Behaviors.Find<OperationDescription>() != null).ToList();
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new CorsEnabledMessageInspector(corsEnabledOperations));
        }

        public void Validate(ServiceEndpoint endpoint) {
        }
    }
}
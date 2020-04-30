using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace WCF_HttpWinService {
    public class WcfCrosBehavior:BehaviorExtensionElement, IEndpointBehavior {
        public override Type BehaviorType => typeof(WcfCrosBehavior);

        public void AddBindingParameters(ServiceEndpoint endpoint,BindingParameterCollection bindingParameters) {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint,ClientRuntime clientRuntime) {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint,EndpointDispatcher endpointDispatcher) {
            var requiredHeaders = new Dictionary<string,string>();

            requiredHeaders.Add("Access-Control-Allow-Origin","*");
            requiredHeaders.Add("Access-Control-Request-Method","POST,GET,PUT,DELETE,OPTIONS");
            requiredHeaders.Add("Access-Control-Allow-Headers","X-Requested-With,Content-Type");

            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new WcfCorsHeaderMessageInspector(requiredHeaders));
        }

        public void Validate(ServiceEndpoint endpoint) {

        }


        protected override object CreateBehavior() {
            return new WcfCrosBehavior();
        }
    }
}
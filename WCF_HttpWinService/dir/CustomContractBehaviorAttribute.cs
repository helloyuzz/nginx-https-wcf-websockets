using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace WCF_HttpsWinService {
    public class CustomContractBehaviorAttribute:BehaviorExtensionElement, IEndpointBehavior,IServiceBehavior {
        public override Type BehaviorType => typeof(CustomContractBehaviorAttribute);

        public void AddBindingParameters(ServiceEndpoint endpoint,BindingParameterCollection bindingParameters) {
            
        }

        public void AddBindingParameters(ServiceDescription serviceDescription,ServiceHostBase serviceHostBase,Collection<ServiceEndpoint> endpoints,BindingParameterCollection bindingParameters) {
            throw new NotImplementedException();
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint,ClientRuntime clientRuntime) {
            
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint,EndpointDispatcher endpointDispatcher) {
            var requiredHeaders = new Dictionary<string,string>();

            requiredHeaders.Add("Access-Control-Allow-Origin","*");
            requiredHeaders.Add("Access-Control-Request-Method","POST,GET,PUT,DELETE,OPTIONS");
            requiredHeaders.Add("Access-Control-Allow-Headers","X-Requested-With,Content-Type");

            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new CustomHeaderMessageInspector(requiredHeaders));
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription,ServiceHostBase serviceHostBase) {
            throw new NotImplementedException();
        }

        public void Validate(ServiceEndpoint endpoint) {
            
        }

        public void Validate(ServiceDescription serviceDescription,ServiceHostBase serviceHostBase) {
            Trace.WriteLine(new NotImplementedException());
        }

        protected override object CreateBehavior() {
            return new CustomContractBehaviorAttribute();
        }
    }
}
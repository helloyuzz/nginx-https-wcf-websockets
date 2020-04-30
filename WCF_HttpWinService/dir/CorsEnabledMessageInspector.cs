using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;
using System.Collections;

namespace WCF_HttpsWinService {
    public class CorsEnabledMessageInspector:IDispatchMessageInspector {
        private IList corsEnabledOperationNames;

        public CorsEnabledMessageInspector(IList corsEnabledOperations) {
            this.corsEnabledOperationNames = corsEnabledOperations;// corsEnabledOperations.Select(o => o.Name).ToList();
        }

        public object AfterReceiveRequest(ref Message request,IClientChannel channel,InstanceContext instanceContext) {
            HttpRequestMessageProperty httpProp = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
            object operationName;
            request.Properties.TryGetValue(WebHttpDispatchOperationSelector.HttpOperationNamePropertyName,out operationName);
            if(httpProp != null && operationName != null && this.corsEnabledOperationNames.Contains((string)operationName)) {
                string origin = httpProp.Headers[CorsConstants.Origin];
                if(origin != null) {
                    return origin;
                }
            }

            return null;
        }

        public void BeforeSendReply(ref Message reply,object correlationState) {
            string origin = correlationState as string;
            if(origin != null) {
                HttpResponseMessageProperty httpProp = null;
                if(reply.Properties.ContainsKey(HttpResponseMessageProperty.Name)) {
                    httpProp = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
                } else {
                    httpProp = new HttpResponseMessageProperty();
                    reply.Properties.Add(HttpResponseMessageProperty.Name,httpProp);
                }

                httpProp.Headers.Add(CorsConstants.AccessControlAllowOrigin,origin);
            }
        }
    }
}
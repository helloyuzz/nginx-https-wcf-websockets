﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace WCF_HttpWinService {
    public class WcfCorsHeaderMessageInspector:IDispatchMessageInspector {
        Dictionary<string,string> requiredHeaders;
        public WcfCorsHeaderMessageInspector(Dictionary<string,string> headers) {
            requiredHeaders = headers ?? new Dictionary<string,string>();
        }
        public object AfterReceiveRequest(ref Message request,IClientChannel channel,InstanceContext instanceContext) {
            string displayText = $"Server has received the following message:\n{request}\n";
            Console.WriteLine(displayText);
            return null;
        }

        public void BeforeSendReply(ref Message reply,object correlationState) {
            var httpHeader = reply.Properties["httpResponse"] as HttpResponseMessageProperty;
            foreach(var item in requiredHeaders) {
                httpHeader.Headers.Add(item.Key,item.Value);
            }

            string displayText = $"Server has replied the following message:\n{reply}\n";
            Console.WriteLine(displayText);

        }
    }
}
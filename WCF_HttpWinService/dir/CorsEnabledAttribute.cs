﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace WCF_HttpsWinService {
    public class CorsEnabledAttribute:Attribute, IOperationBehavior {
        public void AddBindingParameters(OperationDescription operationDescription,BindingParameterCollection bindingParameters) {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription,ClientOperation clientOperation) {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription,DispatchOperation dispatchOperation) {
        }

        public void Validate(OperationDescription operationDescription) {
        }
    }
}
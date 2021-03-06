﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace WCF_HttpsWinService {
    public class PreflightOperationBehavior:IOperationBehavior {
        private OperationDescription preflightOperation;
        private List<string> allowedMethods;

        public PreflightOperationBehavior(OperationDescription preflightOperation) {
            this.preflightOperation = preflightOperation;
            this.allowedMethods = new List<string>();
        }

        public void AddAllowedMethod(string httpMethod) {
            this.allowedMethods.Add(httpMethod);
        }

        public void AddBindingParameters(OperationDescription operationDescription,BindingParameterCollection bindingParameters) {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription,ClientOperation clientOperation) {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription,DispatchOperation dispatchOperation) {
            dispatchOperation.Invoker = new PreflightOperationInvoker(operationDescription.Messages[1].Action,this.allowedMethods);
        }

        public void Validate(OperationDescription operationDescription) {
        }
    }
}
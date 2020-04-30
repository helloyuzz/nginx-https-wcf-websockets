using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using WCF_HttpsClient.WCF_HttpWinService;

namespace WCF_HttpsClient {
    public partial class Form_WCFHttpsClient:Form {
        public Form_WCFHttpsClient() {
            InitializeComponent();
        }

        private void btn_Call_Click(object sender,EventArgs e) {
            string result = "";
            WCF_HttpWinService.Service1Client client = new WCF_HttpWinService.Service1Client();
            result = client.GetDateTime("aa");
            MessageBox.Show(result);

            // Create the binding.  
            //var myBinding = new WSHttpBinding();
            //myBinding.Security.Mode = SecurityMode.Transport;
            //myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

            //// Create the endpoint address, used to authenticate the service.   
            //var ea = new EndpointAddress("https://localhost:10443/WCF_HttpsWinService/service1?singleWsdl");


            //// Create the client, for examples :
            //WCF_HttpsWinService.Service1Client cc = new WCF_HttpsWinService.Service1Client(myBinding,ea);
            //ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

            //// The client must specify a certificate trusted by the server.  
            //cc.ClientCredentials.ClientCertificate.SetCertificate(
            //                                                    StoreLocation.LocalMachine,
            //                                                    StoreName.My,
            //                                                    X509FindType.FindBySerialNumber,
            //                                                    "e50ac104bd00779e4bbd03e0724056fe");

            //// Begin using the client.  
            //string result = cc.GetData(new Random(10000).Next());
            ////result = cc.Ping(new Random(10000).ToString());

            //cc.Close();

            //MessageBox.Show(result);






            // Create the binding.  
            //var apiBinding = new WSHttpBinding();
            //apiBinding.Security.Mode = SecurityMode.Transport;
            //apiBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

            // Create the endpoint address, used to authenticate the service.   
            //var api_ea = new EndpointAddress("https://localhost:40113/API?singleWsdl");


            //API_HttpClient.APIServiceClient httpClient = new API_HttpClient.APIServiceClient();
            //API_HttpClient.ResponseEntity entity = httpClient.GetDateTime();
            //MessageBox.Show(entity.ToString());

            // Create the client, for examples :
            //APIClient.APIServiceClient apiClient = new APIClient.APIServiceClient(apiBinding,api_ea);
            //ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

            //// The client must specify a certificate trusted by the server.  
            //apiClient.ClientCredentials.ClientCertificate.SetCertificate(
            //                                                    StoreLocation.LocalMachine,
            //                                                    StoreName.My,
            //                                                    X509FindType.FindBySerialNumber,
            //                                                    "86aadc0630f73698417e25b0ca04ef50");
            //bool pingResult = apiClient.Ping();
            //MessageBox.Show(pingResult.ToString());

            //APIClient.ResponseEntity entity = apiClient.GetDateTime();
            //MessageBox.Show(entity.ToString());
        }

        private bool RemoteCertificateValidate(object sender,X509Certificate certificate,X509Chain chain,SslPolicyErrors sslPolicyErrors) {
            return true;
        }

        private void btnRestClient_Click(object sender,EventArgs e) {
            RestClient client = new RestClient("https://localhost:10443/WCF_HttpsWinService/service1?singleWsdl");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type","application/soap+xml;charset=utf-8");
            request.AddParameter("application/soap+xml;charset=utf-8","<s:Envelope xmlns:a=\"http://www.w3.org/2005/08/addressing\" xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\">\r\n  <s:Header>\r\n    <a:Action s:mustUnderstand=\"1\">http://tempuri.org/IService1/Ping</a:Action>\r\n    <a:MessageID>urn:uuid:a54449a2-7c4d-4471-b08f-4cd1206d0e78</a:MessageID>\r\n    <a:ReplyTo>\r\n      <a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address>\r\n    </a:ReplyTo>\r\n    <a:To s:mustUnderstand=\"1\" xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\">https://localhost:10443/WCF_HttpsWinService/service1</a:To>\r\n  </s:Header>\r\n  <s:Body>\r\n    <Ping xmlns=\"http://tempuri.org/\">\r\n      <clientValue>这是客户端提供的内容</clientValue>\r\n    </Ping>\r\n  </s:Body>\r\n</s:Envelope>",ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);

            //var client = new RestClient("https://localhost:40113/API?singleWsdl");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Content-Type","application/xml;charset=utf-8");
            //request.AddParameter("application/xml;charset=utf-8","<s:Envelope xmlns:a=\"http://www.w3.org/2005/08/addressing\" xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\">\n    <s:Header>\n        <a:Action s:mustUnderstand=\"1\">http://tempuri.org/IService1/Ping</a:Action>\n        <a:MessageID>urn:uuid:a54449a2-7c4d-4471-b08f-4cd1206d0e7a</a:MessageID>\n        <a:ReplyTo>\n            <a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address>\n        </a:ReplyTo>\n        <a:To s:mustUnderstand=\"1\" xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\">https://192.168.0.123:40113/API?singleWsdl</a:To>\n    </s:Header>\n    <s:Body>\n        <GetDateTime xmlns=\"http://tempuri.org/\"></GetDateTime>\n    </s:Body>\n</s:Envelope>",ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //MessageBox.Show(response.Content);
        }

        private void button1_Click(object sender,EventArgs e) {
            //string result = "";
            ////Service1Client client = new Service1Client();
            ////string result = client.Ping("aa");

            ////TempClient.Service1Client client = new TempClient.Service1Client();
            ////string result= client.GetData();

            //HttpClient.Service1Client client = new HttpClient.Service1Client();
            //result = client.Ping("aa");
            //MessageBox.Show(result);
        }
    }
}

using Fleck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Temp {
    class Program {
        static void Main(string[] args) {
            var ws = new WebSocketServer("ws://192.168.0.123:10011");
            ws.RestartAfterListenError = true;
            ws.Start(socket => {
                socket.OnOpen =() => {
                    Console.WriteLine(socket.ConnectionInfo.Id + " - ws OnOpen!");
                };
                socket.OnClose = () => {
                    Console.WriteLine(socket.ConnectionInfo.Id + " - ws OnClose!");
                };
                socket.OnMessage = message => {
                    Console.WriteLine(socket.ConnectionInfo.Id + " - OnMessage:" + message);

                    socket.Send("Server response message:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
                };
            });
            Console.WriteLine("Listen on:" + ws.Location);


            //var wss = new WebSocketServer("wss://192.168.0.123:10043");
            //wss.Certificate = new X509Certificate2(@"C:\\test.pfx","cssd123");
            //wss.EnabledSslProtocols = SslProtocols.Tls12 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Ssl2 | SslProtocols.Ssl3;
            //wss.Start(socket => {
            //    socket.OnOpen = () => Console.WriteLine("wss Open!");
            //    socket.OnClose = () => Console.WriteLine("wss Close!");
            //    socket.OnMessage = message => Console.WriteLine(message);
            //});

            //Console.WriteLine(wss.Location);

            Console.ReadLine();
        }
    }
}

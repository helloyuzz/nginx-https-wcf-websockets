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
            var wsSocketServer = new WebSocketServer("ws://192.168.0.123:10011");
            wsSocketServer.RestartAfterListenError = true;
            wsSocketServer.Start(socket => {
                socket.OnOpen = () => Console.WriteLine(socket.ConnectionInfo.Id + " - ws Open!");
                socket.OnClose = () => Console.WriteLine(socket.ConnectionInfo.Id + " - ws Close!");
                socket.OnMessage = message => {
                    Console.WriteLine(socket.ConnectionInfo.Id + " - " + message);
                    socket.Send(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
                };
            });

            //var wssSocketServer = new WebSocketServer("wss://192.168.0.123:10043");
            //wssSocketServer.Certificate = new X509Certificate2(@"C:\\test.pfx","cssd123");
            //wssSocketServer.EnabledSslProtocols = SslProtocols.Tls12 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Ssl2 | SslProtocols.Ssl3;
            //wssSocketServer.Start(socket =>
            //{
            //    socket.OnOpen = () => Console.WriteLine("wss Open!");
            //    socket.OnClose = () => Console.WriteLine("wss Close!");
            //    socket.OnMessage = message => Console.WriteLine(message);
            //});

            Console.WriteLine(wsSocketServer.Location);
            //Console.WriteLine(wssSocketServer.Location);

            Console.ReadLine();
        }
    }
}

using System;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace plainws
{
    class Program
    {
        static void Main(string[] args)
        {

            Task t = Task.Run( async () => {
                HttpListener httpListener = new HttpListener();
                httpListener.Prefixes.Add("http://localhost:7777/");
                httpListener.Start();
                Console.WriteLine("listener started");

                HttpListenerContext context = await httpListener.GetContextAsync();
                Console.WriteLine("context received");
                if (context.Request.IsWebSocketRequest)
                {
                    HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(null);
                    WebSocket webSocket = webSocketContext.WebSocket;
                    while (webSocket.State == WebSocketState.Open)
                    {
                        //await webSocket.SendAsync( );
                    }
                }
            });

            t.Wait();
            
        }
    }
}

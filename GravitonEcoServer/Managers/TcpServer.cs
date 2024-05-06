using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEcoServer.Managers
{
    public class TcpServer
    {
        public async void server()
        {
            var tcpListener = new TcpListener(IPAddress.Any, 8888);
            try
            {
                tcpListener.Start();    // запускаем сервер
                Console.WriteLine("Сервер запущен. Ожидание подключений... ");

                while (true)
                {
                    // получаем подключение в виде TcpClient
                    var tcpClient = await tcpListener.AcceptTcpClientAsync();
                    Console.WriteLine($"Входящее подключение: {tcpClient.Client.RemoteEndPoint}");
                }
            }
            finally
            {
                tcpListener.Stop(); // останавливаем сервер
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace GravitonEcoCoreService.Managers
{
    public class TcpServer
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public async void server()
        {
            var tcpListener = new TcpListener(IPAddress.Any, 8888);
            try
            {
                tcpListener.Start();    // запускаем сервер
                logger.Info("[" + DateTime.Now.ToString("DD.MM.g HH:mm:ss") + "]" + "Сервер запущен.");

                while (true)
                {
                    // получаем подключение в виде TcpClient
                    var tcpClient = await tcpListener.AcceptTcpClientAsync();
                    //Console.WriteLine($"Входящее подключение: {tcpClient.Client.RemoteEndPoint}");
                }
            }
            catch (Exception ex)
            {
                logger.Error("[" + DateTime.Now.ToString("DD.MM.g HH:mm:ss") + "]" + "Ошибка соединения  с сервером или клиентом: " + ex.Message);

            }
            finally
            {
                tcpListener.Stop(); // останавливаем сервер
            }
        }
    }
}

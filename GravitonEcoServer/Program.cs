using GravitonEcoServer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEcoServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            TcpServer server = new TcpServer();
            server.server();
            Console.ReadKey();
        }
    }
}

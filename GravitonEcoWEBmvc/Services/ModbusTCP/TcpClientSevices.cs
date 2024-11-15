using GravitonEcoWEBmvc.Models.DataBaseModel;
using GravitonEcoWEBmvc.Services.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;

namespace GravitonEcoWEBmvc.Services.ModbusTCP
{
    public class TcpClientServices
    {
        private readonly ILogger<TcpClientServices> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        private TcpClient _tcpClient;
        private string _ipAddress;
        private int _port;

        public TcpClientServices(ILogger<TcpClientServices> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            LoadConfig();
        }

        private void LoadConfig()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();

                var deviceConfig = context.DeviceConnectionModels.FirstOrDefault();
                if (deviceConfig != null)
                {
                    _ipAddress = deviceConfig.IpAddres;
                    _port = deviceConfig.Port;
                }
                else
                {
                    _logger.LogWarning("No device configurations found in the database.");
                }
            }
        }

        public bool Connect()
        {
            try
            {
                _tcpClient = new TcpClient
                {
                    ReceiveTimeout = 10000,
                    SendTimeout = 10000,
                    NoDelay = true,
                    ReceiveBufferSize = 8192,
                    SendBufferSize = 8192,
                    LingerState = new LingerOption(true, 10)
                };

                _tcpClient.Connect(_ipAddress, _port);
                return true;
            }
            catch (SocketException ex)
            {
                _logger.LogError(ex, "Не удалось подключиться к {IpAddress}:{Port}.", _ipAddress, _port);
                return false;
            }
        }

        public void Disconnect()
        {
            _tcpClient?.Close();
            _tcpClient = null;
        }

        public TcpClient GetTcpClient() => _tcpClient;
        public bool IsConnected => _tcpClient != null && _tcpClient.Connected;
    }
}

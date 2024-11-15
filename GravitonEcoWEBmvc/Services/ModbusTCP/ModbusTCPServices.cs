using NModbus;
using System.Net.Sockets;

namespace GravitonEcoWEBmvc.Services.ModbusTCP
{
    public class ModbusTCPServices
    {
        private readonly TcpClientServices _tcpClientSevices;
        private IModbusMaster _modbusMaster;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ModbusTCPServices> _logger;

        public ModbusTCPServices(IHttpContextAccessor httpContextAccessor, ILogger<ModbusTCPServices> logger, TcpClientServices tcpClientSevices)
        {
            _tcpClientSevices = tcpClientSevices;
        }


        public ushort[] ReadInputRegisters(byte startAddress, ushort numberOfPoints)
        {
            EnsureConnection();
            try
            {
                return _modbusMaster.ReadInputRegisters(startAddress, numberOfPoints, 1); // Чтение данных по ModbusTCP
            }
            catch (IOException ex) when (ex.Message.Contains("Response was not of expected transaction ID"))
            {
                Task.Delay(500).Wait(); // Задержка перед повтором
                return _modbusMaster.ReadInputRegisters(startAddress, numberOfPoints, 1);
            }
        }

        public ushort[] ReadHoldingRegisters(byte startAddress, ushort numberOfPoints)
        {
            // Если соединение было потеряно, пытаемся подключиться снова
            EnsureConnection();
            try
            {
                return _modbusMaster.ReadHoldingRegisters(startAddress, numberOfPoints, 1); // Чтение данных по ModbusTCP
            }
            catch (IOException ex) when (ex.Message.Contains("Response was not of expected transaction ID"))
            {
                Task.Delay(500).Wait(); // Короткая задержка перед повтором
                return _modbusMaster.ReadHoldingRegisters(startAddress, numberOfPoints, 1);
            }
        }

        public bool[] ReadDiscretRegisters(byte startAddress, ushort numberOfPoints)
        {
            // Если соединение было потеряно, пытаемся подключиться снова
            EnsureConnection();
            int maxAttempts = 3;
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                try
                {
                    return _modbusMaster.ReadInputs(startAddress, numberOfPoints, 1); // Чтение данных по ModbusTCP
                }
                catch (IOException ex) when (ex.Message.Contains("Response was not of expected transaction ID"))
                {
                    Console.WriteLine($"Transaction ID mismatch. Attempt {attempt + 1} of {maxAttempts}.");
                    Task.Delay(500).Wait(); // Короткая задержка перед повтором

                    if (attempt == maxAttempts - 1)
                    {
                        Console.WriteLine("Max attempts reached. Reinitializing connection.");
                        ReinitializeConnection();
                        throw;
                    }
                }
            }

            throw new IOException("Failed to read Modbus registers after multiple attempts.");
        }

        public void WriteSingleRegister(byte slaveAddress, ushort registerAddress, ushort value)
        {
            // Если соединение было потеряно, пытаемся подключиться снова
            EnsureConnection();
            try
            {
                _modbusMaster.WriteSingleRegister(slaveAddress, registerAddress, value); // Запись данных
            }
            catch (IOException ex) when (ex.Message.Contains("Response was not of expected transaction ID"))
            {
                Task.Delay(500).Wait(); // Короткая задержка перед повтором
            }
        }

        private void ReinitializeConnection()
        {
            _modbusMaster?.Dispose();
            InitializeModbusMaster();
        }

        private void EnsureConnection()
        {
            int maxAttempts = 3;
            int attempt = 0;

            while (!_tcpClientSevices.IsConnected && attempt < maxAttempts)
            {
                try
                {
                    attempt++;
                    InitializeModbusMaster();
                }
                catch (SocketException ex)
                {
                    if (attempt >= maxAttempts)
                    {
                        RedirectOnError();
                        throw; // Проброс ошибки после достижения максимального количества попыток
                    }

                    Task.Delay(1000).Wait(); // Задержка перед следующей попыткой
                }
            }
        }

        private void InitializeModbusMaster()
        {
            if (_tcpClientSevices.Connect())
            {
                var factory = new ModbusFactory();
                _modbusMaster = factory.CreateMaster(_tcpClientSevices.GetTcpClient());
                _modbusMaster.Transport.ReadTimeout = 3000;  // Таймаут чтения
                _modbusMaster.Transport.WriteTimeout = 3000; // Таймаут записи
            }
            else
            {
                RedirectOnError();
            }
        }

        private void RedirectOnError()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context != null)
            {
                context.Response.Redirect("/Admin");
            }
        }
    }
}

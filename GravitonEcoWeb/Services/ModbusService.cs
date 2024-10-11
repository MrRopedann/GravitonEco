using NModbus;
using System.Net.Sockets;

namespace GravitonEcoWeb.Services
{
    public class ModbusService
    {
        private TcpClient _tcpClient;
        private IModbusMaster _modbusMaster;
        private readonly string _ipAddress = "10.10.10.2"; // IP устройства
        private readonly int _port = 502; // Порт устройства

        public ModbusService()
        {
            Connect();
        }

        // Метод для подключения к устройству
        private void Connect()
        {
            if (_tcpClient != null && _tcpClient.Connected)
                return;

            _tcpClient = new TcpClient();
            _tcpClient.Connect(_ipAddress, _port); // Подключаемся к устройству

            var factory = new ModbusFactory();
            _modbusMaster = factory.CreateMaster(_tcpClient);
        }

        // Метод для получения времени с устройства
        public async Task<string> GetDeviceDateTimeAsync()
        {
            try
            {
                var secondsResult = await _modbusMaster.ReadHoldingRegistersAsync(251, 256, 1);
                var minutesResult = await _modbusMaster.ReadHoldingRegistersAsync(251, 257, 1);
                var hoursResult = await _modbusMaster.ReadHoldingRegistersAsync(251, 258, 1);
                var dayResult = await _modbusMaster.ReadHoldingRegistersAsync(251, 260, 1);
                var monthResult = await _modbusMaster.ReadHoldingRegistersAsync(251, 261, 1);
                var yearResult = await _modbusMaster.ReadHoldingRegistersAsync(251, 262, 1);

                if (secondsResult != null && minutesResult != null && hoursResult != null &&
                    dayResult != null && monthResult != null && yearResult != null)
                {
                    var seconds = BcdToDecimal(secondsResult[0]);
                    var minutes = BcdToDecimal(minutesResult[0]);
                    var hours = BcdToDecimal(hoursResult[0]);
                    var day = BcdToDecimal(dayResult[0]);
                    var month = BcdToDecimal(monthResult[0]);
                    var year = BcdToDecimal(yearResult[0]) + 2000;

                    return $"{day:D2}.{month:D2}.{year} {hours:D2}:{minutes:D2}:{seconds:D2}";
                }
            }
            catch
            {
                // Возвращаем пустую строку или ошибку в случае неудачи
                return "Ошибка чтения времени";
            }

            return "Ошибка";
        }

        // Метод для получения серийного номера устройства
        public async Task<string> GetDeviceSerialNumberAsync()
        {
            try
            {
                // Читаем каждый регистр по отдельности
                var register18 = await _modbusMaster.ReadHoldingRegistersAsync(251, 18, 1);
                var register19 = await _modbusMaster.ReadHoldingRegistersAsync(251, 19, 1);
                var register20 = await _modbusMaster.ReadHoldingRegistersAsync(251, 20, 1);
                var register21 = await _modbusMaster.ReadHoldingRegistersAsync(251, 21, 1);
                var register22 = await _modbusMaster.ReadHoldingRegistersAsync(251, 22, 1);
                var register23 = await _modbusMaster.ReadHoldingRegistersAsync(251, 23, 1);

                if (register18 != null && register19 != null && register20 != null &&
                    register21 != null && register22 != null && register23 != null)
                {
                    return $"SN-{register18[0]}{register19[0]}{register20[0]}{register21[0]}{register22[0]}{register23[0]}";
                }
            }
            catch
            {
                // Возвращаем сообщение об ошибке
                return "Ошибка чтения серийного номера";
            }

            return "Ошибка";
        }

        private int BcdToDecimal(ushort bcd)
        {
            return (bcd >> 4) * 10 + (bcd & 0x0F);
        }

        public ushort[] ReadRegisters(byte startAddress, ushort numberOfPoints)
        {
            // Если соединение было потеряно, пытаемся подключиться снова
            EnsureConnection();
            return _modbusMaster.ReadHoldingRegisters(startAddress, numberOfPoints, 1); // Чтение данных по ModbusTCP
        }

        public void WriteSingleRegister(ushort address, ushort value)
        {
            // Если соединение было потеряно, пытаемся подключиться снова
            EnsureConnection();
            _modbusMaster.WriteSingleRegister(1, address, value); // Запись данных
        }

        // Метод для проверки подключения и попытки восстановления соединения
        public bool CheckConnection()
        {
            try
            {
                EnsureConnection(); // Проверяем соединение и переподключаемся, если нужно
                var result = _modbusMaster.ReadHoldingRegisters(2, 5, 1); // Проверка подключения
                return result != null && result.Length > 0;
            }
            catch
            {
                return false; // Если произошла ошибка, считаем, что устройство не подключено
            }
        }

        // Метод для проверки соединения, если потеряно — переподключаемся
        private void EnsureConnection()
        {
            if (_tcpClient == null || !_tcpClient.Connected)
            {
                Connect(); // Если соединение было потеряно, пытаемся подключиться снова
            }
        }
    }
}

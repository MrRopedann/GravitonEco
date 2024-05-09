using GravitonEcoServer.Managers;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEcoServer.Updaters
{
    public class SensorUpdater
    {
        private readonly ModbusConnectionManager connectionManager;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly byte slaveAddress;
        private readonly ushort startAddress;
        private readonly ushort numberOfPoints;
        private int previousValue;
        public string Alias { get; }

        public SensorUpdater(ModbusConnectionManager connectionManager, string alias, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            this.connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager));
            Alias = alias;
            this.slaveAddress = slaveAddress;
            this.startAddress = startAddress;
            this.numberOfPoints = numberOfPoints;
            previousValue = 0;
        }

        public void StartMonitoring()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(TimeSpan.FromSeconds(30));
                    CheckSensorValue();
                }
            });
        }

        private async Task CheckSensorValue()
        {
            try
            {
                var modbusMaster = connectionManager.GetModbusMaster();
                if (modbusMaster != null && connectionManager.IsDeviceAvailable())
                {
                    ushort[] registers = await modbusMaster.ReadInputRegistersAsync(slaveAddress, startAddress, numberOfPoints);
                    if (registers != null && registers.Length > 0)
                    {
                        int value = registers[0];
                        if (value != previousValue)
                        {
                            previousValue = value;
                            OnValueChanged(value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error checking sensor value: {ex.Message}");
            }
        }
    }
}

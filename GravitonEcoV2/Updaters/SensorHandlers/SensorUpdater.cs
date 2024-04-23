using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using NModbus;

namespace GravitonEcoV2.Updaters
{
    public class SensorUpdater : ModbusUpdaterBase
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private byte _slaveAdress { get; set; }
        private ushort _startAdress { get; set; }
        private ushort _numberOfPoints { get; set; }

        public SensorUpdater(Control control, ModbusConnectionManager connectionManager, byte slaveAdress, ushort startAdress, ushort numberOfPoints)
            : base(control, connectionManager)
        {
            _slaveAdress = slaveAdress;
            _startAdress = startAdress;
            _numberOfPoints = numberOfPoints;
        }

        protected override async Task UpdateAsync()
        {
            while (true)
            {
                await UpdateRegistersAsync(async (modbusMaster) =>
                {
                    if (connectionManager.IsDeviceAvailable())
                    {
                        logger.Info("Получено новое значение: " + modbusMaster.ReadInputRegistersAsync(_slaveAdress, _startAdress, _numberOfPoints));
                        return await modbusMaster.ReadInputRegistersAsync(_slaveAdress, _startAdress, _numberOfPoints);
                    }
                    else return null;
                });
            }
        }
    }
}

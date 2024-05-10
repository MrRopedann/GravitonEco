using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravitonEcoV2.Updaters.PorogHandlers
{
    public class PorogUpdater : ModbusUpdaterBase
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private byte _slaveAdress { get; set; }
        private ushort _startAdress { get; set; }
        private ushort _numberOfPoints { get; set; }

        public PorogUpdater(Control control, ModbusConnectionManager connectionManager, byte slaveAdress, ushort startAdress, ushort numberOfPoints)
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
                        logger.Info("Получено новое значение: " + modbusMaster.ReadCoilsAsync(_slaveAdress, _startAdress, _numberOfPoints));
                        return await modbusMaster.ReadCoilsAsync(_slaveAdress, _startAdress, _numberOfPoints);
                    }
                    else return null;
                });
            }
        }
    }
}
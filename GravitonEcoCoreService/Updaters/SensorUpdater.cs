using GravitonEcoCoreService.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEcoCoreService.Updaters
{
    // Класс для асинхронного обновления температуры
    public class SensorUpdater : ModbusUpdaterBase
    {
        private byte _slaveAdress { get; set; }
        private ushort _startAdress { get; set; }
        private ushort _numberOfPoints { get; set; }
        public string Alias { get; }

        public SensorUpdater(string alias, ModbusConnectionManager connectionManager, byte slaveAdress, ushort startAdress, ushort numberOfPoints)
             : base(alias, connectionManager)
        {
            Alias = alias;
            _slaveAdress = slaveAdress;
            _startAdress = startAdress;
            _numberOfPoints = numberOfPoints;
        }

        protected override async Task UpdateAsync()
        {
            await UpdateRegistersAsync(async (modbusMaster) =>
            {
                // Ваш код для ReadInputRegistersAsync
                return await modbusMaster.ReadInputRegistersAsync(_slaveAdress, _startAdress, _numberOfPoints);
            });
        }
    }
}

using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravitonEcoV2.Communication
{
    public abstract class ModbusWritersBase
    {
        protected readonly ModbusConnectionManager connectionManager;

        public ModbusWritersBase(ModbusConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager));
        }

        protected async Task WritersRegistersAsync(Func<IModbusMaster, Task<ushort[]>> writeRegistersFunc, Action<object> initializeAction)
        {
            try
            {
                IModbusMaster modbusMaster = connectionManager.GetModbusMaster();
                ushort[] registers = await writeRegistersFunc(modbusMaster);
                object initialValue = registers[0];

                initializeAction.Invoke(initialValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка передачи данных: {ex.Message}");
            }
        }
    }
}

using NModbus;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;

public abstract class ModbusInitializeBase
{
    protected readonly ModbusConnectionManager connectionManager;
    protected readonly Control control;

    public ModbusInitializeBase(ModbusConnectionManager connectionManager, Control control)
    {
        this.control = control ?? throw new ArgumentNullException(nameof(control));
        this.connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager));
    }

    protected async Task InitializeRegistersAsync(Func<IModbusMaster, Task<ushort[]>> readRegistersFunc, Action<object> initializeAction)
    {
        try
        {
            IModbusMaster modbusMaster = connectionManager.GetModbusMaster();
            ushort[] registers = await readRegistersFunc(modbusMaster);
            object initialValue = registers[0];

            initializeAction.Invoke(initialValue);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка передачи данных: {ex.Message}");
        }
    }
}
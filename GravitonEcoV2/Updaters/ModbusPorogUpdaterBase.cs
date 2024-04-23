using NModbus;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public abstract class ModbusPorogUpdaterBase
{
    protected readonly Control control;
    protected readonly ModbusConnectionManager connectionManager;

    private CancellationTokenSource cancellationTokenSource;

    public ModbusPorogUpdaterBase(Control control, ModbusConnectionManager connectionManager)
    {
        this.control = control ?? throw new ArgumentNullException(nameof(control));
        this.connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager));
        this.cancellationTokenSource = new CancellationTokenSource();

        this.control.HandleCreated += (_, __) => StartUpdating();
        this.control.HandleDestroyed += (_, __) => StopUpdating();
    }

    protected abstract Task UpdateAsync();

    protected async Task UpdateControlAsync(object value)
    {
        if (control.IsHandleCreated && !control.IsDisposed)
        {
            await Task.Run(() =>
            {
                control.BeginInvoke(new Action(() =>
                {
                    if (control.IsHandleCreated && !control.IsDisposed)
                    {
                        // Обновление Text у Label или установка значения для TextBox
                        if (control is Label label)
                        {
                            label.Text = value.ToString();
                        }
                        else if (control is TextBox textBox)
                        {
                            textBox.ForeColor = Boolean.Parse(value.ToString()) ? Color.Red : Color.Green;
                        }
                    }
                }));
            });
        }
    }

    protected async Task UpdateRegistersAsync(Func<IModbusMaster, Task<ushort[]>> readRegistersFunc)
    {
        while (!cancellationTokenSource.Token.IsCancellationRequested)
        {
            try
            {
                IModbusMaster modbusMaster = connectionManager.GetModbusMaster();
                ushort[] registers = await readRegistersFunc(modbusMaster);
                string newValue = registers[0].ToString();

                await UpdateControlAsync(newValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка передачи данных: {ex.Message}");
            }

            await Task.Delay(100);
        }
    }

    protected async Task UpdateRegistersAsync(Func<IModbusMaster, Task<bool[]>> readRegistersFunc)
    {
        while (!cancellationTokenSource.Token.IsCancellationRequested)
        {
            try
            {
                IModbusMaster modbusMaster = connectionManager.GetModbusMaster();
                bool[] registers = await readRegistersFunc(modbusMaster);
                string newValue = registers[0].ToString();

                await UpdateControlAsync(newValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка передачи данных: {ex.Message}");
            }

            await Task.Delay(100);
        }
    }

    public void StartUpdating()
    {
        cancellationTokenSource = new CancellationTokenSource();
        Task.Run(() => UpdateAsync());
    }

    public void StopUpdating()
    {
        cancellationTokenSource.Cancel();
    }
}

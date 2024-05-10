using NLog;
using NModbus;
using System;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravitonEcoV2.Updaters
{
    public abstract class ModbusUpdaterBase
    {
        protected readonly Control control;
        protected readonly ModbusConnectionManager connectionManager;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public event EventHandler<string> ValueReceived;

        public ModbusUpdaterBase(Control control, ModbusConnectionManager connectionManager)
        {
            this.control = control ?? throw new ArgumentNullException(nameof(control));
            this.connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager));

            this.control.HandleCreated += (_, __) => StartUpdating();
            this.control.HandleDestroyed += (_, __) => StopUpdating();
        }

        protected abstract Task UpdateAsync();

        protected async Task UpdateRegistersAsync(Func<IModbusMaster, Task<ushort[]>> readRegistersFunc)
        {
            try
            {
                IModbusMaster modbusMaster = connectionManager.GetModbusMaster();
                if (modbusMaster != null && connectionManager.IsDeviceAvailable())
                {
                    ushort[] registers = await readRegistersFunc(modbusMaster);
                    if (registers != null && registers.Length > 0)
                    {
                        string newValue = registers[0].ToString();
                        await Task.Run(() =>
                        {
                            control.BeginInvoke(new Action(() =>
                            {
                                // Обновление Text у Label или установка значения для TextBox
                                if (control is Label label)
                                {
                                    label.Text = newValue.ToString();
                                }
                                else if (control is TextBox textBox)
                                {
                                    textBox.ForeColor = Boolean.Parse(newValue.ToString()) ? Color.Red : Color.Green;
                                }
                                
                            }));
                        });
                        OnValueReceived(newValue);
                    }
                    else
                    {
                        await HandleNoRegistersReceived();
                    }
                }
                else
                {
                    await HandleNoRegistersReceived();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Ошибка передачи данных [МЕТОД - UpdateRegistersAsync]: {ex.Message}");
            }
        }

        protected async Task UpdateRegistersAsync(Func<IModbusMaster, Task<bool[]>> readRegistersFunc)
        {
            try
            {
                IModbusMaster modbusMaster = connectionManager.GetModbusMaster();
                if (modbusMaster != null && connectionManager.IsDeviceAvailable())
                {
                    bool[] registers = await readRegistersFunc(modbusMaster);
                    if (registers != null && registers.Length > 0)
                    {
                        string newValue = registers[0].ToString();
                        await Task.Run(() =>
                        {
                            control.BeginInvoke(new Action(() =>
                            {
                                // Обновление Text у Label или установка значения для TextBox
                                if (control is Label label)
                                {
                                    label.Text = newValue.ToString();
                                }
                                else if (control is TextBox textBox)
                                {
                                    textBox.ForeColor = Boolean.Parse(newValue.ToString()) ? Color.Red : Color.Green;
                                }

                            }));
                        });
                        OnValueReceived(newValue);
                    }
                    else
                    {
                        await HandleNoRegistersReceived();
                    }
                }
                else
                {
                    await HandleNoRegistersReceived();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Ошибка передачи данных [МЕТОД - UpdateRegistersAsync]: {ex.Message}");
            }
        }

        protected async Task HandleNoRegistersReceived()
        {
            logger.Error("Не удалось получить значения регистров. Обработка ситуации...");
        }

        public void StartUpdating()
        {
            Task.Run(() => UpdateAsync());
        }

        public void StopUpdating()
        {
        }

        protected virtual void OnValueReceived(string newValue)
        {
            ValueReceived?.Invoke(this, newValue);
        }
    }
}


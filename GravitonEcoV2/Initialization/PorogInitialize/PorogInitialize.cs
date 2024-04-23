using NModbus;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public class PorogInitialize : ModbusInitializeBase
    {
        private byte _slaveAdress { get; set; }
        private ushort _startAdress { get; set; }
        private ushort _numberOfPoints { get; set; }

        public PorogInitialize(Control control, ModbusConnectionManager connectionManager, byte slaveAdress, ushort startAdress, ushort numberOfPoints)
             : base(connectionManager, control )
        {
            _slaveAdress = slaveAdress;
            _startAdress = startAdress;
            _numberOfPoints = numberOfPoints;
            Initialize();
        }

        public void Initialize()
        {
            // Вызываем метод базового класса, передавая функцию чтения регистров и действие инициализации
            base.InitializeRegistersAsync(ReadRegistersFunction, InitializeAction);
        }

        // Пример функции чтения регистров
        private async Task<ushort[]> ReadRegistersFunction(IModbusMaster modbusMaster)
        {
            // Здесь реализуйте свою логику чтения регистров
            // В данном примере просто возвращаем фиксированный массив
            return await modbusMaster.ReadHoldingRegistersAsync(_slaveAdress, _startAdress, _numberOfPoints);
        }

        // Действие для инициализации
        private void InitializeAction(object initialValue)
        {
            // Обновляем текст в TextBox при инициализации
            control.Text = initialValue.ToString();
        }
    }
}

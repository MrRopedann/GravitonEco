using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEcoV2.Events
{
    public class SensorValueChangedEventArgs : EventArgs
    {
        public string NewValue { get; }

        public SensorValueChangedEventArgs(string newValue)
        {
            NewValue = newValue;
        }
    }

    public class SensorValueTracker
    {
        private string _currentValue;
        public event EventHandler<SensorValueChangedEventArgs> ValueChanged;

        public SensorValueTracker()
        {
            // Предположим, что начальное значение датчика неизвестно
            _currentValue = null;
        }

        // Метод для обновления значения датчика
        public void UpdateValue(string newValue)
        {
            // Проверяем, изменилось ли значение
            if (newValue != _currentValue)
            {
                // Сохраняем новое значение
                _currentValue = newValue;
                // Вызываем событие, указывая новое значение
                OnValueChanged(newValue);
            }
        }

        protected virtual void OnValueChanged(string newValue)
        {
            // Проверяем, есть ли подписчики на событие
            ValueChanged?.Invoke(this, new SensorValueChangedEventArgs(newValue));
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GravitonEco.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.ViewModels
{
    public partial class SensorGroupViewModel : ObservableObject
    {
        public ObservableCollection<Sensor> Sensors { get; set; }
        public string GroupName { get; set; }

        public SensorGroupViewModel(string groupName)
        {
            GroupName = groupName;
            Sensors = new ObservableCollection<Sensor>();
        }

        [RelayCommand]
        public void AddSensor()
        {
            var newSensor = new Sensor
            {
                Name = "Новый датчик",
                SlaveId = 1,
                StartAddress = 0,
                NumberOfPoints = 10,
                Mode = "Default"
            };

            Sensors.Add(newSensor);
        }

        [RelayCommand]
        public void RemoveSensor(Sensor sensor)
        {
            if (sensor != null && Sensors.Contains(sensor))
            {
                Sensors.Remove(sensor);
            }
        }
    }
}

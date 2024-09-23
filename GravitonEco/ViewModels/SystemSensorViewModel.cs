using CommunityToolkit.Mvvm.ComponentModel;
using GravitonEco.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.ViewModels
{
    public class SystemSensorViewModel : ObservableObject
    {
        public ObservableCollection<SystemSensor> SystemSensors { get; set; }

        public SystemSensorViewModel()
        {
            SystemSensors = new ObservableCollection<SystemSensor>();
        }

        // Логика для добавления и удаления системных датчиков
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GravitonEco.Models;
using GravitonEco.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace GravitonEco.ViewModels.Pages
{
    public partial class SettingsViewModel : ObservableObject
    {
        public ModbusTcpClient ModbusConnection { get; set; }
        public ObservableCollection<SensorGroupViewModel> SensorGroups { get; set; }
        public ObservableCollection<SystemSensorViewModel> SystemSensors { get; set; }

        public SettingsViewModel()
        {
            ModbusConnection = ModbusTcpClient.GetInstance();
            SensorGroups = new ObservableCollection<SensorGroupViewModel>();
            SystemSensors = new ObservableCollection<SystemSensorViewModel>();
        }

        [RelayCommand]
        public void AddSensorGroup()
        {
            var newGroup = new SensorGroupViewModel("Новая группа");
            SensorGroups.Add(newGroup);
        }
    }
}

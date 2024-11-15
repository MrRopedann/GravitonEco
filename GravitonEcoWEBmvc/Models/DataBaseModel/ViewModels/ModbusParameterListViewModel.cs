namespace GravitonEcoWEBmvc.Models.DataBaseModel.ViewModels
{
    public class ModbusParameterListViewModel
    {
        public List<ModbusParameterViewModel> Parameters { get; set; }
        public List<GroupModel> AvailableGroups { get; set; }
        public List<GroupModel> AvailableCalibrationGroups { get; set; }
    }
}

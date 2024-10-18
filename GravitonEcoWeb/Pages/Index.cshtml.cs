using GravitonEcoWeb.Model;
using GravitonEcoWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

public class IndexModel : PageModel
{
    private readonly ModbusDataFactory _modbusDataFactory;
    private readonly ILogger<IndexModel> _logger;

    // Параметры для развернутых групп Modbus
    public Dictionary<string, bool> Groups { get; private set; }
    public Dictionary<string, bool> GroupsCalibration { get; private set; }
    public Dictionary<string, List<ModbusParameter>> GroupedParameters { get; private set; }
    public Dictionary<string, List<CalibrationParameter>> GasCalibrationParametersGrouped { get; private set; }

    public IndexModel(ModbusDataFactory modbusDataFactory, ILogger<IndexModel> logger)
    {
        _modbusDataFactory = modbusDataFactory;
        _logger = logger;
    }

    public void OnGet()
    {
        // Получаем состояния групп
        Groups = _modbusDataFactory.GetGroupStates();
        GroupsCalibration = _modbusDataFactory.GetCalibrationGroupStates();
        // Получаем параметры калибровки газоанализатора и группируем их
        var gasCalibrationParameters = _modbusDataFactory.GetGasCalibrationParametersGrouped();

        // Группируем параметры калибровки по свойству Group
        GasCalibrationParametersGrouped = gasCalibrationParameters
            .GroupBy(p => p.Group)
            .ToDictionary(g => g.Key, g => g.ToList());

        // Группируем параметры для развернутых групп
        var parameters = _modbusDataFactory.GetParametersForExpandedGroups();

        GroupedParameters = parameters
            .GroupBy(p => p.Group)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}

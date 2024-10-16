using GravitonEcoWeb.Model;
using GravitonEcoWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

public class IndexModel : PageModel
{
    private readonly ModbusDataFactory _modbusDataFactory;
    private readonly ILogger<IndexModel> _logger;

    public List<CalibrationParameter> GasCalibrationParameters { get; set; } // Используем CalibrationParameter, а не CalibrationConfig

    public IndexModel(ModbusDataFactory modbusDataFactory, ILogger<IndexModel> logger)
    {
        _modbusDataFactory = modbusDataFactory;
        _logger = logger;
    }

    public Dictionary<string, bool> Groups { get; private set; }
    public Dictionary<string, List<ModbusParameter>> GroupedParameters { get; private set; }

    public void OnGet()
    {
        // Получаем состояния групп
        Groups = _modbusDataFactory.GetGroupStates();

        // Получаем параметры для развернутых групп
        var parameters = _modbusDataFactory.GetParametersForExpandedGroups();

        // Получаем параметры калибровки газоанализатора
        GasCalibrationParameters = _modbusDataFactory.GetGasCalibrationParameters();

        // Логируем количество параметров для проверки
        _logger.LogInformation("Получено {ParameterCount} параметров для развернутых групп", parameters.Count);

        // Группируем параметры по ключу группы
        GroupedParameters = parameters
            .GroupBy(p => p.Group)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}

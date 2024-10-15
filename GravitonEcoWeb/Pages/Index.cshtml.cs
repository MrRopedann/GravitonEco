using GravitonEcoWeb.Model;
using GravitonEcoWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly ModbusDataFactory _modbusDataFactory;
    private readonly ILogger<ModbusDataFactory> _logger;
    public List<CalibrationParameter> GasCalibrationParameters { get; set; }

    public IndexModel(ModbusDataFactory modbusDataFactory)
    {
        _modbusDataFactory = modbusDataFactory;
    }

    public Dictionary<string, bool> Groups { get; private set; }
    public Dictionary<string, List<ModbusParameter>> GroupedParameters { get; private set; }

    public void OnGet()
    {
        // Получаем состояния групп
        Groups = _modbusDataFactory.GetGroupStates();

        // Получаем параметры только для развернутых групп
        var parameters = _modbusDataFactory.GetParametersForExpandedGroups();
        // Получаем параметры калибровки газоанализатора
        GasCalibrationParameters = _modbusDataFactory.GetGasCalibrationParameters();

        // Логируем количество параметров для проверки
        //_logger.LogInformation("Получено {ParameterCount} параметров для развернутых групп", parameters.Count);

        // Группируем параметры по ключу группы
        GroupedParameters = parameters
            .GroupBy(p => p.Group) // Группируем параметры по группам
            .ToDictionary(g => g.Key, g => g.ToList()); // Преобразуем в словарь
    }
}

public class ParameterWithIndex
{
    public ModbusParameter Value { get; set; }
    public int Index { get; set; }
}

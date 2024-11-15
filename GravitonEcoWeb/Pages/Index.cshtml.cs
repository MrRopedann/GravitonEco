using GravitonEcoWeb.Model;
using GravitonEcoWeb.Services.Factorys;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly ModbusDataFactory _modbusDataFactory;
    private readonly ModbusCalibrationFactory _modbusCalibrationFactory;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ModbusDataFactory modbusDataFactory, ModbusCalibrationFactory modbusCalibrationFactory, ILogger<IndexModel> logger)
    {
        _modbusDataFactory = modbusDataFactory;
        _modbusCalibrationFactory = modbusCalibrationFactory;
        _logger = logger;
    }

    public Dictionary<string, bool> GroupsData { get; private set; }
    public Dictionary<string, List<ModbusParameter>> GroupedParameters { get; private set; }

    public Dictionary<string, bool> GroupsCalibration { get; private set; }
    public Dictionary<string, List<CalibrationParameter>> GroupedCalibration { get; private set; }

    public void OnGet()
    {
        // Получаем состояния групп
        GroupsData = _modbusDataFactory.GetGroupStates();
        GroupsCalibration = _modbusCalibrationFactory.GetGroupCalibrationStates();

        // Получаем параметры для развернутых групп
        var parametersData = _modbusDataFactory.GetParametersForExpandedGroups();
        var parametersCalibration = _modbusCalibrationFactory.GetCalibrationParametersGroups();

        // Логируем количество параметров для проверки
        _logger.LogInformation("Получено {ParameterCount} параметров для развернутых групп", parametersData.Count);
        _logger.LogInformation("Получено {ParameterCount} параметров для развернутых групп", parametersCalibration.Count);

        // Группируем параметры по ключу группы
        GroupedParameters = parametersData
            .GroupBy(p => p.Group)
            .ToDictionary(g => g.Key, g => g.ToList());

        GroupedCalibration = parametersCalibration
            .GroupBy(p => p.Group)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Метод для получения заголовков для определенной группы
    public List<string> GetColumnsForGroup(string groupName)
    {
        var config = _modbusCalibrationFactory.GetConfigForGroup(groupName);
        return config?.ColumnNames ?? new List<string> { "Параметр", "Текущее значение", "Уст. Нуля", "Конц-я ПГС", "Знач-е АЦП", "Расчетный '0'" };
    }
}

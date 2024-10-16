using GravitonEcoWeb.Model;
using GravitonEcoWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

public class IndexModel : PageModel
{
    private readonly ModbusDataFactory _modbusDataFactory;
    private readonly ILogger<IndexModel> _logger;

    public List<CalibrationParameter> GasCalibrationParameters { get; set; } // ���������� CalibrationParameter, � �� CalibrationConfig

    public IndexModel(ModbusDataFactory modbusDataFactory, ILogger<IndexModel> logger)
    {
        _modbusDataFactory = modbusDataFactory;
        _logger = logger;
    }

    public Dictionary<string, bool> Groups { get; private set; }
    public Dictionary<string, List<ModbusParameter>> GroupedParameters { get; private set; }

    public void OnGet()
    {
        // �������� ��������� �����
        Groups = _modbusDataFactory.GetGroupStates();

        // �������� ��������� ��� ����������� �����
        var parameters = _modbusDataFactory.GetParametersForExpandedGroups();

        // �������� ��������� ���������� ���������������
        GasCalibrationParameters = _modbusDataFactory.GetGasCalibrationParameters();

        // �������� ���������� ���������� ��� ��������
        _logger.LogInformation("�������� {ParameterCount} ���������� ��� ����������� �����", parameters.Count);

        // ���������� ��������� �� ����� ������
        GroupedParameters = parameters
            .GroupBy(p => p.Group)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}

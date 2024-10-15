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
        // �������� ��������� �����
        Groups = _modbusDataFactory.GetGroupStates();

        // �������� ��������� ������ ��� ����������� �����
        var parameters = _modbusDataFactory.GetParametersForExpandedGroups();
        // �������� ��������� ���������� ���������������
        GasCalibrationParameters = _modbusDataFactory.GetGasCalibrationParameters();

        // �������� ���������� ���������� ��� ��������
        //_logger.LogInformation("�������� {ParameterCount} ���������� ��� ����������� �����", parameters.Count);

        // ���������� ��������� �� ����� ������
        GroupedParameters = parameters
            .GroupBy(p => p.Group) // ���������� ��������� �� �������
            .ToDictionary(g => g.Key, g => g.ToList()); // ����������� � �������
    }
}

public class ParameterWithIndex
{
    public ModbusParameter Value { get; set; }
    public int Index { get; set; }
}

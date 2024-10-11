using GravitonEcoWeb.Model;
using GravitonEcoWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GravitonEcoWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ModbusDataFactory _modbusDataFactory;

        public IndexModel(ModbusDataFactory modbusDataFactory)
        {
            _modbusDataFactory = modbusDataFactory;
        }

        public List<ModbusParameter> Parameters { get; private set; }

        public void OnGet()
        {
            // �������� ��������� ����� �������
            Parameters = _modbusDataFactory.GetParameters();
        }
    }
}

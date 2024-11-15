using GravitonEcoWEBmvc.Models;
using GravitonEcoWEBmvc.Services.BackgroundServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GravitonEcoWEBmvc.Controllers.Device
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModbusBackgroundService _modbusBackgroundService;

        public HomeController(ILogger<HomeController> logger, ModbusBackgroundService modbusBackgroundService)
        {
            _logger = logger;
            _modbusBackgroundService = modbusBackgroundService;
        }

        public IActionResult Index()
        {
            // ѕолучение списка устройств из фонового сервиса
            var devices = _modbusBackgroundService.GetDevices();

            // ѕередача данных в представление
            return View(devices);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public JsonResult GetUpdatedDevices()
        {
            var devices = _modbusBackgroundService.GetDevices();
            return Json(devices);
        }
    }
}

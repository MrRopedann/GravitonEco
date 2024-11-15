using GravitonEcoWEBmvc.Models.DataBaseModel;
using GravitonEcoWEBmvc.Services.DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GravitonEcoWEBmvc.Models.DataBaseModel.ViewModels;

[Authorize(Roles = "Admin")] // Доступ только для администраторов
public class AdminController : Controller
{
    private readonly SqliteDbContext _dbContext;

     public AdminController(SqliteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult AdminPanel()
    {
        return View();
    }
    // Страница управления подключениями устройств
    // Метод для отображения и редактирования текущего подключения
    public async Task<IActionResult> DeviceConnection()
    {
        // Получение единственного подключения, если оно есть
        var connection = await _dbContext.DeviceConnectionModels.FirstOrDefaultAsync();

        // Если записи нет, создаем ее с начальными значениями
        if (connection == null)
        {
            connection = new DeviceConnectionModel { IpAddres = "127.0.0.1", Port = 502 };
            _dbContext.DeviceConnectionModels.Add(connection);
            await _dbContext.SaveChangesAsync();
        }

        return View(connection);
    }

    [HttpPost]
    public async Task<IActionResult> SaveDeviceConnection(DeviceConnectionModel model)
    {
        // Проверка наличия существующего подключения
        var connection = await _dbContext.DeviceConnectionModels.FirstOrDefaultAsync();
        if (connection != null)
        {
            // Обновление существующего подключения
            connection.IpAddres = model.IpAddres;
            connection.Port = model.Port;
        }
        else
        {
            // Добавление нового подключения, если оно еще не существует
            _dbContext.DeviceConnectionModels.Add(model);
        }

        await _dbContext.SaveChangesAsync();
        return RedirectToAction("DeviceConnection");
    }

    public IActionResult ManageGroups()
    {
        var groups = _dbContext.GroupModels.ToList();
        return View(groups);
    }

    [HttpPost]
    public async Task<IActionResult> SaveGroup(GroupModel group)
    {
        if (group.Id == 0) // Если ID равен 0, добавляем новую группу
        {
            _dbContext.GroupModels.Add(group);
        }
        else // В противном случае обновляем существующую группу
        {
            var existingGroup = _dbContext.GroupModels.FirstOrDefault(g => g.Id == group.Id);
            if (existingGroup != null)
            {
                existingGroup.GroupName = group.GroupName;
                existingGroup.DisplayFormat = group.DisplayFormat;
            }
        }

        await _dbContext.SaveChangesAsync();
        return RedirectToAction("ManageGroups");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteGroup(int id)
    {
        var group = _dbContext.GroupModels.FirstOrDefault(g => g.Id == id);
        if (group != null)
        {
            _dbContext.GroupModels.Remove(group);
            await _dbContext.SaveChangesAsync();
        }
        return RedirectToAction("ManageGroups");
    }
}

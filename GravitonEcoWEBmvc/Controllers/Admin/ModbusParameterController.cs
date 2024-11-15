using GravitonEcoWEBmvc.Models.DataBaseModel;
using GravitonEcoWEBmvc.Models.DataBaseModel.ViewModels;
using GravitonEcoWEBmvc.Services.DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")]
public class ModbusParameterController : Controller
{
    private readonly SqliteDbContext _dbContext;

    public ModbusParameterController(SqliteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Метод для отображения страницы параметров Modbus
    public async Task<IActionResult> Index()
    {
        var parameters = await _dbContext.ModbusParametrs
            .Include(p => p.Group)
            .Include(p => p.CalibrationGroup)
            .Select(p => new ModbusParameterViewModel
            {
                Id = p.Id,
                ParametrName = p.ParametrName,
                GroupId = p.GroupId,
                GroupName = p.Group.GroupName,
                CalibrationGroupId = p.CalibrationGroupId,
                CalibrationGroupName = p.CalibrationGroup.GroupName,
                IsCalibration = p.IsCalibration,

                // Адреса и регистры устройства
                DeviceAddress = p.DeviceAddress,
                RegisterCurrentValue = p.RegisterCurrentValue,
                RegisterPorog1 = p.RegisterPorog1,
                RegisterPorog2 = p.RegisterPorog2,
                RegisterIncrement = p.RegisterIncrement,
                RegisterPeriod = p.RegisterPeriod,
                RegisterAlarm1 = p.RegisterAlarm1,
                RegisterAlarm2 = p.RegisterAlarm2,
                RegisterAlarm3 = p.RegisterAlarm3,

                // Калибровочные параметры
                CalibrationOffset = p.RegisterOffset,
                CalibrationConstant = p.RegisterConstant,
                CalibrationValue = p.RegisterValue,
                CalibrationPeriod = p.RegisterCalibrationPeriod
            })
            .ToListAsync();

        var viewModel = new ModbusParameterListViewModel
        {
            Parameters = parameters,
            AvailableGroups = await _dbContext.GroupModels.ToListAsync(),
            AvailableCalibrationGroups = await _dbContext.GroupModels.ToListAsync()
        };

        return View("/Views/Admin/ManageModbusParameters.cshtml", viewModel);
    }


    // Метод для сохранения одного параметра
    [HttpPost]
    public async Task<IActionResult> SaveParameter([FromBody] ModbusParameterViewModel model)
    {
        if (model == null) return BadRequest("Неверные данные параметра.");

        await SaveParameterInternal(model);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    // Метод для массового сохранения параметров
    [HttpPost]
    public async Task<IActionResult> SaveAllParameters([FromBody] List<ModbusParameterViewModel> parameters)
    {
        if (parameters == null || !parameters.Any()) return BadRequest("Нет данных для сохранения.");

        foreach (var model in parameters)
        {
            await SaveParameterInternal(model);
        }

        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    // Внутренний метод для сохранения параметра в базе данных
    private async Task SaveParameterInternal(ModbusParameterViewModel model)
    {
        // Получаем существующую запись или создаем новую, если Id == 0
        var modbusParam = model.Id == 0 ? new ModbusParametrModel() :
            await _dbContext.ModbusParametrs
                .FirstOrDefaultAsync(p => p.Id == model.Id);

        if (modbusParam == null) return;

        // Обновляем основные свойства параметра, только если они были переданы
        if (!string.IsNullOrEmpty(model.ParametrName))
            modbusParam.ParametrName = model.ParametrName;

        if (model.GroupId != 0)
            modbusParam.GroupId = model.GroupId;

        if (model.CalibrationGroupId.HasValue)
            modbusParam.CalibrationGroupId = model.CalibrationGroupId;

        modbusParam.IsCalibration = model.IsCalibration;

        // Обновляем основные регистры и адреса устройства, только если они были переданы
        if (model.DeviceAddress != 0)
            modbusParam.DeviceAddress = model.DeviceAddress;

        if (model.RegisterCurrentValue != 0)
            modbusParam.RegisterCurrentValue = model.RegisterCurrentValue;

        if (model.RegisterPorog1 != 0)
            modbusParam.RegisterPorog1 = model.RegisterPorog1;

        if (model.RegisterPorog2 != 0)
            modbusParam.RegisterPorog2 = model.RegisterPorog2;

        if (model.RegisterIncrement != 0)
            modbusParam.RegisterIncrement = model.RegisterIncrement;

        if (model.RegisterPeriod != 0)
            modbusParam.RegisterPeriod = model.RegisterPeriod;

        if (model.RegisterAlarm1 != 0)
            modbusParam.RegisterAlarm1 = model.RegisterAlarm1;

        if (model.RegisterAlarm2 != 0)
            modbusParam.RegisterAlarm2 = model.RegisterAlarm2;

        if (model.RegisterAlarm3 != 0)
            modbusParam.RegisterAlarm3 = model.RegisterAlarm3;

        // Обновляем калибровочные параметры, только если они были переданы
        if (model.CalibrationOffset.HasValue)
            modbusParam.RegisterOffset = model.CalibrationOffset;

        if (model.CalibrationConstant.HasValue)
            modbusParam.RegisterConstant = model.CalibrationConstant;

        if (model.CalibrationValue.HasValue)
            modbusParam.RegisterValue = model.CalibrationValue;

        if (model.CalibrationPeriod.HasValue)
            modbusParam.RegisterCalibrationPeriod = model.CalibrationPeriod;

        // Если это новая запись, добавляем ее в контекст
        if (model.Id == 0)
        {
            _dbContext.ModbusParametrs.Add(modbusParam);
        }
    }




}

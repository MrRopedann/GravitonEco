﻿// Функция для сворачивания/разворачивания группы
function toggleGroup(groupId) {
    const group = document.getElementById(groupId);
    group.style.display = (group.style.display === 'none' || group.style.display === '') ? 'block' : 'none';
}

// Загрузка конфигурации
function loadConfig(configName, targetElementId) {
    fetch(`/api/config/get-config/${configName}`)
        .then(response => response.json())
        .then(data => {
            const container = document.getElementById(targetElementId).querySelector('tbody');
            container.innerHTML = ''; // Очищаем перед загрузкой
            data.forEach((item, index) => {
                container.innerHTML += generateConfigRow(item, index, configName);
            });
        })
        .catch(error => console.error('Ошибка загрузки конфигурации:', error));
}

// Генерация HTML для строки конфигурации с кнопкой удаления
//function generateConfigRow(item, index, configName) {
//    let html = '<tr>';
//    Object.keys(item).forEach(key => {
//        html += `<td><input type="text" value="${item[key]}" name="${key}" class="form-control"/></td>`;
//    });
//    html += `<td><button class="btn btn-danger" onclick="deleteConfigRow(${index}, '${configName}')">Удалить</button></td>`;
//    html += '</tr>';
//    return html;
//}

function addModbusConfig() {
    const container = document.getElementById('modbus-config').querySelector('tbody');
    const newIndex = container.querySelectorAll('tr').length;
    container.innerHTML += generateConfigRow({
        Name: '',
        SlaveAddress: '',
        CurrentValueAddress: '',
        Porog1Address: '',
        Porog2Address: '',
        IncrementAddress: '',
        PeriodAddress: '',
        AlarmPorog1Address: '',
        AlarmPorog2Address: '',
        AlarmPorog3Address: '',
        Group: ''
    }, newIndex, 'modbusConfig.json');
}
// Функция для добавления новой строки в Газовую калибровку
function addGasConfig() {
    const container = document.getElementById('gas-config').querySelector('tbody');
    const newIndex = container.querySelectorAll('tr').length;
    container.innerHTML += generateConfigRow({
        Name: '',
        SlaveAddress: '',
        CurrentValueAddress: '',
        SettingZero: '',
        PGSConcentration: '',
        ADCValue: '',
        CalculatedZero: '',
        Group: '',
        ModbusDeviseID: ''
    }, newIndex, 'modbusColibrationGasConfig.json');
}

function generateConfigRow(item, index, configName) {
    let html = '<tr>';
    Object.keys(item).forEach(key => {
        if (key === "ConverGasType") return;
        if (key === "IsCalibration") {
            const checked = item[key] ? 'checked' : '';
            html += `<td><input type="checkbox" ${checked} name="${key}" class="form-check-input"/></td>`;
        } else {
            html += `<td><input type="text" value="${item[key]}" name="${key}" class="form-control"/></td>`;
        }
    });
    html += `<td><button class="btn btn-danger" onclick="deleteConfigRow(${index}, '${configName}')">Удалить</button></td>`;
    html += '</tr>';
    return html;
}

// Функция для удаления строки
function deleteConfigRow(index, configName) {
    const container = document.getElementById(configName === 'DeviseConnection.json' ? 'device-config' :
        configName === 'modbusConfig.json' ? 'modbus-config' : 'gas-config');
    const row = container.querySelector(`tbody tr:nth-child(${index + 1})`);
    row.remove();
}

// Функция для преобразования строк в числа
function parseIfNumeric(value) {
    const parsedValue = parseInt(value, 10);
    return isNaN(parsedValue) ? value : parsedValue;  // Возвращаем число или оригинальную строку
}

// Функция для преобразования строк в логическое значение
function parseIfBool(value) {
    const normalizedInput = value.trim().toLowerCase();
    if (normalizedInput === 'true') {
        return true;
    } else if (normalizedInput === 'false') {
        return false;
    } else {
        console.warn(`Ошибка преобразования строки '${value}' в логическое значение. Устанавливается значение по умолчанию.`);
        return false;  // По умолчанию false
    }
}

// Универсальная функция для сохранения конфигурации
function saveConfig(configName) {
    let container;

    // Определяем, какое имя конфигурации сохраняется
    if (configName === 'DeviseConnection.json') {
        container = document.getElementById('device-config');
    } else if (configName === 'modbusConfig.json') {
        container = document.getElementById('modbus-config');
    } else if (configName === 'modbusColibrationGasConfig.json') {
        container = document.getElementById('gas-config');
    } else {
        console.error('Неизвестное имя конфигурации:', configName);
        return;
    }

    // Формируем массив данных конфигурации
    const config = [];
    container.querySelectorAll('tbody tr').forEach(row => {
        const item = {};
        row.querySelectorAll('input').forEach(input => {
            let value = input.value.trim();

            // Преобразование значений в нужные типы данных
            if (['SlaveAddress', 'CurrentValueAddress', 'Porog1Address', 'Porog2Address',
                'IncrementAddress', 'PeriodAddress', 'AlarmPorog1Address', 'AlarmPorog2Address', 'AlarmPorog3Address', 'ModbusDeviseID'].includes(input.name)) {
                value = parseIfNumeric(value);
            } else if (input.name === 'IsCalibration') {
                //value = parseIfBool(value);
                value = input.checked;
            }

            item[input.name] = value;
        });
        config.push(item);
    });

    // Преобразуем конфигурацию в JSON
    const jsonConfig = JSON.stringify(config);

    // Отправляем POST-запрос для сохранения конфигурации
    fetch(`/api/config/save-config/${configName}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: jsonConfig
    })
        .then(response => response.text())
        .then(result => {
            alert(`Конфигурация ${configName} сохранена.`);
        })
        .catch(error => {
            console.error(`Ошибка сохранения конфигурации ${configName}:`, error);
            alert(`Ошибка сохранения конфигурации ${configName}.`);
        });
}

// Загрузка всех конфигураций при загрузке страницы
document.addEventListener('DOMContentLoaded', () => {
    loadConfig('DeviseConnection.json', 'device-config');
    loadConfig('modbusConfig.json', 'modbus-config');
    loadConfig('modbusColibrationGasConfig.json', 'gas-config');
});

// Функция, которая открывает выбранную секцию, закрывает остальные и обновляет активную кнопку
function toggleGroup(targetId) {
    const allContent = document.querySelectorAll('.collapse-content');
    const allButtons = document.querySelectorAll('.tab-button');

    allContent.forEach(content => {
        content.classList.remove('open');
    });

    allButtons.forEach(button => {
        button.classList.remove('active');
    });

    const target = document.getElementById(targetId);
    if (target) {
        target.classList.add('open');
    }

    const clickedButton = document.querySelector(`.tab-button[onclick="toggleGroup('${targetId}')"]`);
    if (clickedButton) {
        clickedButton.classList.add('active');
    }
}

// Изначально показываем только первый блок и делаем первую кнопку активной
document.addEventListener('DOMContentLoaded', function () {
    toggleGroup('log-changes'); // Открываем первый блок по умолчанию
});

document.querySelector('.setting').addEventListener('click', function (event) {
    if (sessionStorage.getItem('isPincodeCorrect') !== 'true') {
        event.preventDefault(); // Блокируем переход на страницу
        alert("Требуется ввести корректный пинкод для доступа к настройкам.");
    }
});
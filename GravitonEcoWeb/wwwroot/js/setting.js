// Функция для сворачивания/разворачивания группы
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
function generateConfigRow(item, index, configName) {
    let html = '<tr>';
    Object.keys(item).forEach(key => {
        html += `<td><input type="text" value="${item[key]}" name="${key}" class="form-control"/></td>`;
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

// Функция для добавления новой строки в Modbus конфигурацию
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
        Group: ''
    }, newIndex, 'modbusColibrationGasConfig.json');
}

// Функция для преобразования строк в числа, если это возможно
function parseIfNumeric(value) {
    const parsedValue = parseInt(value, 10);
    return isNaN(parsedValue) ? value : parsedValue;  // Возвращаем число или оригинальную строку
}

// Сохранение конфигурации для Modbus
function saveModbusConfig() {
    const container = document.getElementById('modbus-config');

    const config = [];
    container.querySelectorAll('tbody tr').forEach(row => {
        const item = {};
        row.querySelectorAll('input').forEach(input => {
            let value = input.value.trim();

            // Преобразование значений в нужные типы данных
            if (['SlaveAddress', 'CurrentValueAddress', 'Porog1Address', 'Porog2Address',
                'IncrementAddress', 'PeriodAddress', 'AlarmPorog1Address',
                'AlarmPorog2Address', 'AlarmPorog3Address'].includes(input.name)) {
                value = parseIfNumeric(value);
            }

            item[input.name] = value;
        });
        config.push(item);
    });

    // Преобразуем конфигурацию в JSON
    const jsonConfig = JSON.stringify(config);

    fetch(`/api/config/save-config/modbusConfig.json`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: jsonConfig
    })
        .then(response => response.text())
        .then(result => {
            alert(result);
        })
        .catch(error => console.error('Ошибка сохранения конфигурации:', error));
}


function saveGasConfig() {
    const container = document.getElementById('gas-config');

    const config = [];
    container.querySelectorAll('tbody tr').forEach(row => {
        const item = {};
        row.querySelectorAll('input').forEach(input => {
            let value = input.value.trim();

            // Преобразование значений в нужные типы данных
            if (['SlaveAddress', 'CurrentValueAddress', 'SettingZero',
                'PGSConcentration', 'ADCValue', 'CalculatedZero'].includes(input.name)) {
                value = parseIfNumeric(value);
            }

            item[input.name] = value;
        });
        config.push(item);
    });

    // Преобразуем конфигурацию в JSON
    const jsonConfig = JSON.stringify(config);

    fetch(`/api/config/save-config/modbusColibrationGasConfig.json`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: jsonConfig
    })
        .then(response => response.text())
        .then(result => {
            alert(result);
        })
        .catch(error => console.error('Ошибка сохранения конфигурации:', error));
}

// Загрузка всех конфигураций при загрузке страницы
document.addEventListener('DOMContentLoaded', () => {
    loadConfig('DeviseConnection.json', 'device-config');
    loadConfig('modbusConfig.json', 'modbus-config');
    loadConfig('modbusColibrationGasConfig.json', 'gas-config');
});

// Функция, которая открывает выбранную секцию, закрывает остальные и обновляет активную кнопку
function toggleGroup(targetId) {
    // Найти все элементы с классом collapse-content
    const allContent = document.querySelectorAll('.collapse-content');
    const allButtons = document.querySelectorAll('.tab-button');

    // Закрыть все блоки и убрать активные кнопки
    allContent.forEach(content => {
        content.classList.remove('open');
    });

    allButtons.forEach(button => {
        button.classList.remove('active');
    });

    // Открыть выбранный блок
    const target = document.getElementById(targetId);
    if (target) {
        target.classList.add('open');
    }

    // Найти кнопку, которая была нажата, и добавить ей класс active
    const clickedButton = document.querySelector(`.tab-button[onclick="toggleGroup('${targetId}')"]`);
    if (clickedButton) {
        clickedButton.classList.add('active');
    }
}

// Изначально показываем только первый блок и делаем первую кнопку активной
document.addEventListener('DOMContentLoaded', function () {
    toggleGroup('log-changes'); // Открываем первый блок по умолчанию
});
// Функция для сворачивания/разворачивания группы
function toggleGroup(groupId) {
    const group = document.getElementById(groupId);
    if (group.style.display === 'none' || group.style.display === '') {
        group.style.display = 'block';
    } else {
        group.style.display = 'none';
    }
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
        Group: ''
    }, newIndex, 'modbusColibrationGasConfig.json');
}

// Сохранение конфигурации с правильной типизацией данных
function saveConfig(configName) {
    const container = document.getElementById(configName === 'DeviseConnection.json' ? 'device-config' :
        configName === 'modbusConfig.json' ? 'modbus-config' : 'gas-config');

    const config = [];
    container.querySelectorAll('tbody tr').forEach(row => {
        const item = {};
        row.querySelectorAll('input').forEach(input => {
            let value = input.value;

            // Преобразование значений в нужные типы данных
            if (input.name === 'SlaveAddress') value = parseInt(value, 10);    // byte
            else if (['CurrentValueAddress', 'Porog1Address', 'Porog2Address',
                'IncrementAddress', 'PeriodAddress', 'AlarmPorog1Address',
                'AlarmPorog2Address', 'AlarmPorog3Address'].includes(input.name)) {
                value = parseInt(value, 10);  // ushort
            }

            item[input.name] = value;
        });
        config.push(item);
    });

    // Кастомное JSON.stringify для избежания Unicode кодирования
    const jsonConfig = JSON.stringify(config, (key, value) =>
        typeof value === 'string' ? value : value
    );

    fetch(`/api/config/save-config/${configName}`, {
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

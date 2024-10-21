let isEditing = false; // Флаг для блокировки обновления во время редактирования
let currentIntervalId = null; // Переменная для хранения ID текущего интервала
let currentCalibrationIntervalId = null; // Переменная для хранения ID текущего интервала

// Функция для проверки соединения
function checkConnection() {
    fetch('/api/modbus/check-connection')
        .then(response => response.json())
        .then(isConnected => {
            const connectionIcon = document.getElementById('connection-icon');
            connectionIcon.src = isConnected
                ? '/images/mobile_connection_green.png'
                : '/images/mobile_connection_red.png';
        })
        .catch(error => {
            console.error('Error checking connection:', error);
        });
}

function toggleGroup(groupName) {
    const isExpanded = document.querySelector(`h3[group-name="${groupName}"]`).textContent.includes("Развернуто");

    fetch('/api/modbus/toggle-group', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ groupName, isExpanded: !isExpanded }) // Переключаем состояние
    })
        .then(response => response.text())
        .then(data => {
            location.reload(); // Перезагрузка страницы для обновления данных
        })
        .catch(error => {
            console.error('Ошибка при изменении состояния группы:', error);
        });
}

function toggleCalibrationGroup(groupName) {
    const isExpanded = document.querySelector(`h3[group-name="${groupName}"]`).textContent.includes("Развернуто");

    fetch('/api/modbus/toggle-calibration-group', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ groupName, isExpanded: !isExpanded }) // Переключаем состояние
    })
        .then(response => response.text())
        .then(data => {
            location.reload(); // Перезагрузка страницы для обновления данных
        })
        .catch(error => {
            console.error('Ошибка при изменении состояния группы:', error);
        });
}

// Функция для обновления времени устройства
function updateDeviceTime() {
    fetch('/api/modbus/get-device-time')
        .then(response => response.text())
        .then(deviceTime => {
            const dateTimeElement = document.querySelector('.date-time');
            dateTimeElement.textContent = deviceTime;
        })
        .catch(error => {
            console.error('Error fetching device time:', error);
        });
}

// Функция для обновления серийного номера устройства
function updateDeviceSerialNumber() {
    fetch('/api/modbus/get-device-serialnumber')
        .then(response => response.text())
        .then(deviceSerialNumber => {
            const serialNumberElement = document.querySelector('.serial-number');
            serialNumberElement.textContent = deviceSerialNumber;
        })
        .catch(error => {
            console.error('Error fetching device serial number:', error);
        });
}

// Функция для обновления данных с сервера
function updateCurrentData() {
    if (!isEditing) { // Обновляем данные только если не редактируем поля
        fetch('/api/modbus/get-parameters')
            .then(response => response.json())
            .then(parameters => {
                parameters.forEach((param, index) => {
                    const currentCell = document.querySelector(`#current-data-${index}`);
                    if (currentCell) {
                        currentCell.textContent = param.current; // Обновляем текущее значение
                    }

                    // Обновление порогов и сигнализаций
                    const threshold1Cell = document.querySelector(`#threshold1-data-${index}`);
                    const threshold2Cell = document.querySelector(`#threshold2-data-${index}`);
                    const growthCell = document.querySelector(`#growth-data-${index}`);
                    const periodCell = document.querySelector(`#period-data-${index}`);

                    if (threshold1Cell) {
                        threshold1Cell.value = param.threshold1;
                        toggleWarning(threshold1Cell, param.alarmPorog1);
                    }

                    if (threshold2Cell) {
                        threshold2Cell.value = param.threshold2;
                        toggleWarning(threshold2Cell, param.alarmPorog2);
                    }

                    if (growthCell) {
                        growthCell.value = param.growth;
                        toggleWarning(growthCell, param.alarmPorog3);
                    }

                    if (periodCell) {
                        periodCell.value = param.period;
                        toggleWarning(periodCell, param.alarmPorog3);
                    }
                });
            })
            .catch(error => {
                console.error('Error fetching current data:', error);
            });
    }
}

function updateCalibrationData() {
    fetch('/api/modbus/get-calibration-parameters')
        .then(response => response.json())
        .then(parameters => {
            parameters.forEach((param, index) => {
                // Обновляем всегда значение #current-calibration-data, независимо от isEditing
                document.querySelector(`#current-calibration-data-${index}`).textContent = param.currentValue;

                // Обновляем остальные поля только если не происходит редактирование
                if (!isEditing) {
                    const settingZeroCell = document.querySelector(`#setting-zero-data-${index}`);
                    const pgsConcentrationCell = document.querySelector(`#pgs-concentration-data-${index}`);
                    const adcValueCell = document.querySelector(`#adc-value-data-${index}`);
                    const calculatedZeroCell = document.querySelector(`#calculated-zero-data-${index}`);

                    if (settingZeroCell) {
                        settingZeroCell.value = param.settingZero;
                    }
                    if (pgsConcentrationCell) {
                        pgsConcentrationCell.value = param.pgsConcentration;
                    }
                    if (adcValueCell) {
                        adcValueCell.value = param.adcValue;
                    }
                    if (calculatedZeroCell) {
                        calculatedZeroCell.value = param.calculatedZero;
                    }
                }
            });
        })
        .catch(error => console.error('Ошибка при обновлении данных калибровки:', error));
}


// Функция для добавления или удаления класса "warning"
function toggleWarning(element, isWarning) {
    if (isWarning) {
        element.classList.add('warning');
    } else {
        element.classList.remove('warning');
    }
}

// Функция для отправки данных на устройство
function submitValue(event, paramName, fieldName, value) {
    if (event.keyCode === 13) { // Enter
        event.target.disabled = true;

        fetch('/api/modbus/write', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                paramName: paramName,
                fieldName: fieldName,
                value: value
            })
        })
            .then(response => {
                event.target.disabled = false;
                if (response.ok) {
                    alert('Значение успешно записано');
                } else {
                    alert('Ошибка записи');
                }
            })
            .catch(error => {
                console.error('Ошибка при записи:', error);
                alert('Ошибка при записи');
            });
    }
}

function submitCalibrationGasValue(event, paramName, fieldName, value) {
    if (event.keyCode === 13) { // Enter
        event.target.disabled = true;

        fetch('/api/modbus/write-calibration-gas', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                paramName: paramName,
                fieldName: fieldName,
                value: value
            })
        })
            .then(response => {
                event.target.disabled = false;
                if (response.ok) {
                    alert('Значение успешно записано');
                } else {
                    alert('Ошибка записи');
                }
            })
            .catch(error => {
                console.error('Ошибка при записи:', error);
                alert('Ошибка при записи');
            });
    }
}

// Остановка обновления данных при редактировании
function startEditing() {
    isEditing = true;
}

// Возобновление обновления данных после завершения редактирования
function stopEditing() {
    isEditing = false;
}

// Функция для изменения интервала опроса данных в зависимости от выбора
function updatePollingInterval() {
    const dropdown = document.getElementById('update-interval-dropdown');
    const interval = parseInt(dropdown.value, 10); // Получаем выбранное значение

    // Если есть активный интервал, сбрасываем его
    if (currentIntervalId) {
        clearInterval(currentIntervalId);
    }

    // Устанавливаем новый интервал опроса
    currentIntervalId = setInterval(updateCurrentData, interval * 1000);
    currentCalibrationIntervalId = setInterval(updateCalibrationData, interval * 1000);
}

function syncTableColumns() {
    // Получаем все таблицы
    const tables = document.querySelectorAll('table');
    const columnWidths = [];

    // Перебираем все строки первой таблицы, чтобы получить максимальные ширины колонок
    tables.forEach(table => {
        const headers = table.querySelectorAll('th');
        headers.forEach((th, index) => {
            const thWidth = th.offsetWidth;
            columnWidths[index] = Math.max(columnWidths[index] || 0, thWidth);
        });
    });

    // Применяем максимальную ширину ко всем колонкам всех таблиц
    tables.forEach(table => {
        const headers = table.querySelectorAll('th');
        const cells = table.querySelectorAll('td');

        headers.forEach((th, index) => {
            th.style.width = `${columnWidths[index]}px`;
        });

        cells.forEach((td, index) => {
            td.style.width = `${columnWidths[index % headers.length]}px`;
        });
    });
}

// Вызываем функцию после рендеринга таблиц
document.addEventListener('DOMContentLoaded', syncTableColumns);

// Функция для отображения ошибок
function showError(message) {
    const errorMessage = document.getElementById('error-message');
    errorMessage.textContent = message;
    errorMessage.style.display = 'block';
}

// Скрытие ошибок
function hideError() {
    const errorMessage = document.getElementById('error-message');
    errorMessage.style.display = 'none';
}


// Запуск всех функций при загрузке страницы
document.addEventListener('DOMContentLoaded', () => {
    // Запуск начального интервала опроса
    updatePollingInterval();

    // Добавляем обработчик на изменение выпадающего списка для смены интервала
    const dropdown = document.getElementById('update-interval-dropdown');
    dropdown.addEventListener('change', updatePollingInterval); // Смена интервала при изменении значения

    setInterval(updateDeviceTime, 1000); // Обновляем время каждую секунду
    setInterval(updateDeviceSerialNumber, 100000); // Обновляем серийный номер каждые 100 секунд
    setInterval(checkConnection, 5000); // Проверка соединения каждые 5 секунд

    updateDeviceTime(); // Обновляем время сразу при загрузке
    updateDeviceSerialNumber(); // Обновляем серийный номер сразу при загрузке
    checkConnection(); // Проверка соединения сразу при загрузке
});



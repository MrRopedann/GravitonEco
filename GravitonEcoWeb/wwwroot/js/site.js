function checkConnection() {
    fetch('/api/modbus/check-connection')
        .then(response => response.json())
        .then(isConnected => {
            const connectionIcon = document.getElementById('connection-icon');
            if (isConnected) {
                connectionIcon.src = '/images/mobile_connection_green.png';
            } else {
                connectionIcon.src = '/images/mobile_connection_red.png';
            }
        })
        .catch(error => {
            console.error('Error checking connection:', error);
        });
}

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

function updateDeviceSerialNumber() {
    fetch('/api/modbus/get-device-serialnumber') // Исправлено
        .then(response => response.text())
        .then(deviceSerialNumber => {
            const serialNumberElement = document.querySelector('.serial-number');
            serialNumberElement.textContent = deviceSerialNumber;
        })
        .catch(error => {
            console.error('Error fetching device serial number:', error); // Исправлено сообщение об ошибке
        });
}

// Функция обновления данных с сервера
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

                    // Обновление порогов и сработок
                    const threshold1Cell = document.querySelector(`#threshold1-data-${index}`);
                    const threshold2Cell = document.querySelector(`#threshold2-data-${index}`);
                    const growthCell = document.querySelector(`#growth-data-${index}`);
                    const periodCell = document.querySelector(`#period-data-${index}`);

                    if (threshold1Cell) {
                        threshold1Cell.value = param.threshold1;
                        if (param.alarmPorog1) {
                            threshold1Cell.classList.add('warning');
                        } else {
                            threshold1Cell.classList.remove('warning');
                        }
                    }

                    if (threshold2Cell) {
                        threshold2Cell.value = param.threshold2;
                        if (param.alarmPorog2) {
                            threshold2Cell.classList.add('warning');
                        } else {
                            threshold2Cell.classList.remove('warning');
                        }
                    }

                    if (growthCell) {
                        growthCell.value = param.growth;
                        if (param.alarmPorog3) {
                            growthCell.classList.add('warning');
                        } else {
                            growthCell.classList.remove('warning');
                        }
                    }

                    if (periodCell) {
                        periodCell.value = param.period;
                        if (param.alarmPorog3) {
                            periodCell.classList.add('warning');
                        } else {
                            periodCell.classList.remove('warning');
                        }
                    }
                });
            })
            .catch(error => {
                console.error('Error fetching current data:', error);
            });
    }
}


let isEditing = false;

function submitValue(event, paramName, fieldName, value) {
    if (event.keyCode === 13) { // Enter
        isEditing = false; // Сбрасываем флаг после отправки данных
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
                if (response.ok) {
                    alert('Значение успешно записано на устройство');
                } else {
                    alert('Ошибка записи на устройство');
                }
            })
            .catch(error => {
                console.error('Ошибка при отправке данных:', error);
                alert('Ошибка при отправке данных');
            });
    }
}

// Остановка обновления данных при взаимодействии с полем ввода
function startEditing() {
    isEditing = true;
}

// Возобновление обновления данных при потере фокуса
function stopEditing() {
    isEditing = false;
}

// Запуск функции для обновления данных каждые 5 секунд
setInterval(updateCurrentData, 1000);

// Периодическое обновление времени каждые 1 секунд
setInterval(updateDeviceTime, 1000);

// Обновление времени при загрузке страницы
document.addEventListener('DOMContentLoaded', updateDeviceTime);

// Периодическое обновление времени каждые 1 секунд
setInterval(updateDeviceSerialNumber, 100000);

// Обновление времени при загрузке страницы
document.addEventListener('DOMContentLoaded', updateDeviceSerialNumber);

// Периодическая проверка каждые 5 секунд
setInterval(checkConnection, 5000);

// Вызов функции сразу при загрузке страницы
document.addEventListener('DOMContentLoaded', checkConnection);

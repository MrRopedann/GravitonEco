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

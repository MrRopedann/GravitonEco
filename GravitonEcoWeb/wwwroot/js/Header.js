// Инициализируем событие клика только для элемента с id="auth"
document.getElementById("auth").addEventListener("click", showPasswordModal);

// Функция для показа модального окна
function showPasswordModal() {
    const lockIcon = document.getElementById("lockIcon");
    const passwordModal = document.getElementById("passwordModal");

    // Если замок зеленый, не открываем модальное окно
    if (lockIcon.src.includes("unlocked.svg")) {
        return;
    }

    // Показываем модальное окно для ввода пароля
    passwordModal.style.display = "flex";
}

// Функция для закрытия модального окна
function closeModal() {
    document.getElementById("passwordModal").style.display = "none";
}

async function checkPassword() {
    const passwordInput = document.getElementById("passwordInput");
    const lockIcon = document.getElementById("lockIcon");

    try {
        const response = await fetch('/api/Header/get-device-pincode');
        if (!response.ok) throw new Error("Ошибка при получении пинкода");

        const devicePincode = (await response.json()).toString().trim();
        const inputPincode = passwordInput.value.trim();

        if (inputPincode === devicePincode) {
            lockIcon.src = "/images/icons/unlocked.svg";
            closeModal();
            localStorage.setItem('isPincodeCorrect', 'true'); // Сохраняем состояние пинкода
        } else {
            alert(`Неверный пинкод! Ожидаемый пинкод: ${devicePincode}`);
            localStorage.setItem('isPincodeCorrect', 'false'); // Пинкод неверен
        }
    } catch (error) {
        console.error("Ошибка при проверке пинкода:", error);
        alert("Произошла ошибка. Попробуйте позже.");
    }
}

function updatePeriodDataBase() {
    const selectElement = document.getElementById("periodDataBaseSelect");
    const selectedPeriod = selectElement.value;

    // Формируем объект для отправки
    const data = {
        period: selectedPeriod
    };

    // Отправляем POST-запрос с использованием fetch
    fetch("/api/Header/set-polling-period", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                console.log("Период опроса успешно обновлен.");
            } else {
                console.error("Ошибка при установке периода опроса.");
            }
        })
        .catch(error => {
            console.error("Произошла ошибка:", error);
        });
}


function checkSettingsAccess() {
    const isPincodeCorrect = localStorage.getItem('isPincodeCorrect') === 'true';

    if (isPincodeCorrect) {
        // Пинкод корректен, перенаправляем на страницу настроек
        window.location.href = "/Settings";
    } else {
        // Пинкод некорректен или отсутствует, показываем уведомление
        alert("Требуется ввести корректный пинкод для доступа к настройкам.");
    }
}


// Функция для обновления иконки при загрузке страницы
function updateLockIcon() {
    const lockIcon = document.getElementById("lockIcon");
    const isPincodeCorrect = localStorage.getItem('isPincodeCorrect') === 'true';

    if (isPincodeCorrect) {
        lockIcon.src = "/images/icons/unlocked.svg"; // Устанавливаем зелёную иконку при корректном пинкоде
    } else {
        lockIcon.src = "/images/icons/locked.svg"; // Вернуть иконку в заблокированное состояние
    }
}

function toggleLockIcon() {
    const authIcon = document.getElementById("auth");
    const isPincodeCorrect = localStorage.getItem('isPincodeCorrect') === 'true';

    if (isPincodeCorrect) {
        // Сбросить состояние при повторном нажатии
        authIcon.src = "/images/icons/locked.svg";
        localStorage.setItem('isPincodeCorrect', 'false');
    } else {
        // Открыть модальное окно для ввода пароля
        showPasswordModal();
    }
}


// Функция для проверки соединения
function checkConnection() {
    fetch('/api/Header/check-connection')
        .then(response => response.json())
        .then(isConnected => {
            const connectionIcon = document.getElementById('connection-icon');
            connectionIcon.src = isConnected
                ? '/images/icons/db_on.svg'
                : '/images/icons/db_off.svg';
        })
        .catch(error => {
            //console.error('Error checking connection:', error);
        });
}

function checkInternetConnection() {
    fetch('/api/Header/check-internet-connection')
        .then(response => response.json())
        .then(isConnected => {
            const connectionIcon = document.getElementById('connection-inernet-icon');
            connectionIcon.src = isConnected
                ? '/images/icons/connect_on.svg'
                : '/images/icons/connect_off.svg';
            console.info('Состояние соединения с интернетом:', isConnected)
        })
        .catch(error => {
            console.error('Error checking connection:', error);
        });
}

// Функция для обновления времени устройства
function updateDeviceTime() {
    fetch('/api/Header/get-device-time')
        .then(response => response.text())
        .then(deviceTime => {
            const dateTimeElement = document.querySelector('.date-time');
            dateTimeElement.textContent = deviceTime;
        })
        .catch(error => {
            //console.error('Error fetching device time:', error);
        });
}

// Функция для обновления серийного номера устройства
function updateDeviceSerialNumber() {
    fetch('/api/Header/get-device-serialnumber')
        .then(response => response.text())
        .then(deviceSerialNumber => {
            const serialNumberElement = document.querySelector('.serial-number');
            serialNumberElement.textContent = deviceSerialNumber;
        })
        .catch(error => {
           // console.error('Error fetching device serial number:', error);
        });
}

function updateVersionProgram() {
    fetch('/api/Header/get-device-versionprogram')
        .then(response => response.text())
        .then(deviceSerialNumber => {
            const VersionProgramm = document.querySelector('.version-programm-info');
            VersionProgramm.textContent += deviceSerialNumber;
        })
        .catch(error => {
            // console.error('Error fetching device serial number:', error);
        });
}

function updateCheckSumProgram() {
    fetch('/api/Header/get-checksumm-programm')
        .then(response => response.text())
        .then(deviceSerialNumber => {
            const checksummProgramm = document.querySelector('.check-sum-program');
            checksummProgramm.textContent += deviceSerialNumber;
        })
        .catch(error => {
            // console.error('Error fetching device serial number:', error);
        });
}

//setInterval(updateDeviceTime, 5000); // Обновляем время каждую секунду
//setInterval(updateDeviceSerialNumber, 100000); // Обновляем серийный номер каждые 100 секунд
setInterval(checkConnection, 5000); // Проверка соединения каждые 5 секунд
setInterval(checkInternetConnection, 5000); // Проверка соединения каждые 5 секунд

updateDeviceTime(); // Обновляем время сразу при загрузке
updateDeviceSerialNumber(); // Обновляем серийный номер сразу при загрузке
updateVersionProgram();
updateCheckSumProgram();
checkConnection(); // Проверка соединения сразу при загрузке
checkInternetConnection();

document.addEventListener('DOMContentLoaded', () => {
    updateLockIcon(); // Обновляем иконку при загрузке
    const authIcon = document.getElementById("auth");
    authIcon.addEventListener('click', toggleLockIcon); // Обработчик для сброса состояния
});

// Функция для получения текущего установленного значения периода
async function fetchCurrentPollingPeriod() {
    try {
        const response = await fetch('/api/Header/get-polling-period'); // Путь к вашему контроллеру
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const interval = await response.text(); // Или response.json(), если возвращается JSON
        return interval;
    } catch (error) {
        console.error('Ошибка при получении текущего периода:', error);
        return null;
    }
}

// Установить значение по умолчанию после загрузки текущего периода
document.addEventListener("DOMContentLoaded", async function () {
    const currentPeriod = await fetchCurrentPollingPeriod();
    if (currentPeriod) {
        const selectElement = document.getElementById('periodDataBaseSelect');
        selectElement.value = currentPeriod; // Устанавливаем значение по умолчанию
    }
});

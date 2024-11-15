currentCalibrationIntervalId = null; // Переменная для хранения ID текущего интервала
isCalibrationEditing = false;
function updateCalibrationData() {
    if (!isCalibrationEditing) {
        fetch('/api/Calibration/get-calibration-parameters')
            .then(response => response.json())
            .then(parameters => {
                parameters.forEach((param, index) => {
                    const currentCell = document.querySelector(`#current-calibration-data-${index}`);
                    if (currentCell) {
                        
                        currentCell.textContent = (param.currentValue !== undefined && param.currentValue !== null) ? param.currentValue : ''; // Обновляем текущее значение, включая 0
                        
                    }

                    // Обновление порогов и сигнализаций
                    const settingZeroCell = document.querySelector(`#setting-zero-data-${index}`);
                    if (settingZeroCell) {
                        settingZeroCell.value =  param.settingZero; // Обрабатываем значение 0 корректно
                    }

                    const pgsConcentrationCell = document.querySelector(`#pgs-concentration-data-${index}`);
                    if (pgsConcentrationCell) {
                        pgsConcentrationCell.value = (param.pgsConcentration !== undefined && param.pgsConcentration !== null) ? param.pgsConcentration : ''; // Обрабатываем значение 0 корректно
                    }

                    const adcValueCell = document.querySelector(`#adc-value-data-${index}`);
                    if (adcValueCell) {
                        adcValueCell.value = (param.adcValue !== undefined && param.adcValue !== null) ? param.adcValue : ''; // Обрабатываем значение 0 корректно
                    }

                    const calculatedZeroCell = document.querySelector(`#calculated-zero-data-${index}`);
                    if (calculatedZeroCell) {
                        calculatedZeroCell.value = (param.calculatedZero !== undefined && param.calculatedZero !== null) ? param.calculatedZero : ''; // Обрабатываем значение 0 корректно
                    }
                });
            })
            .catch(error => {
                //console.error('Error fetching calibration data:', error);
            });
    }
}




function updatePollingCalibrationInterval() {
    const dropdown = document.getElementById('update-interval-dropdown');
    const interval = parseInt(dropdown.value, 10); // Получаем выбранное значение

    // Если есть активный интервал, сбрасываем его
    if (currentCalibrationIntervalId) {
        clearInterval(currentCalibrationIntervalId);
    }
    currentCalibrationIntervalId = setInterval(async () => await updateCalibrationData(), interval * 1000);
}

function submitCalibrationGasValue(event, paramName, fieldName, value) {
    if (event.keyCode === 13) { // Enter
        event.target.disabled = true;

        fetch('/api/Calibration/write-calibration-parametr', {
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

function toggleCalibrationGroup(groupName) {
    const isPincodeCorrect = localStorage.getItem('isPincodeCorrect') === 'true';

    if (!isPincodeCorrect) {
        alert("Введите корректный пинкод для выполнения этого действия.");
        return; // Останавливаем выполнение, если пинкод неверен
    }

    const IsExpandedCalibraton = document.querySelector(`h3[group-name="${groupName}"]`).textContent.includes("Развернуто");

    fetch('/api/Calibration/toggle-calibration-group', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ groupName, IsExpandedCalibraton: !IsExpandedCalibraton })
    })
        .then(response => response.text())
        .then(data => {
            location.reload();
        })
        .catch(error => {
            console.error('Ошибка при изменении состояния группы:', error);
        });
}

// Запуск всех функций при загрузке страницы
document.addEventListener('DOMContentLoaded', () => {
    // Запуск начального интервала опроса
    updatePollingCalibrationInterval();

    // Добавляем обработчик на изменение выпадающего списка для смены интервала
    const dropdown = document.getElementById('update-interval-dropdown');
    dropdown.addEventListener('change', updatePollingCalibrationInterval); // Смена интервала при изменении значения
});

function startCalibrationEditing() {
    isCalibrationEditing = true;
}

// Возобновление обновления данных после завершения редактирования
function stopCalibrationEditing() {
    isCalibrationEditing = false;
}
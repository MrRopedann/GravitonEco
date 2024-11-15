// Функция для запроса пороговых параметров при загрузке страницы
async function requestCalibrationParameters() {
    try {
        const response = await fetch('/api/Modbus/read-calibration-parameters');
        if (response.ok) {
            const calibrationParameters = await response.json();
            updateCalibrationParameterValues(calibrationParameters);
        }
    } catch (error) {
        console.error("Ошибка:", error);
    }
}

function updateCalibrationParameterValues(calibrationParameters) {
    calibrationParameters.forEach(param => {
        // Находим строки, соответствующие calibrationGroupId и id
        const row = document.querySelector(`tr[data-group-id="${param.calibrationGroupId}"][data-id="${param.id}"]`);

        if (row) {
            

            // Обновляем значения полей
            row.querySelector('.setting-zero-value').value = param.calibrationOffset;
            row.querySelector('.pgs-concentration-value').value = param.calibrationConstant;
            row.querySelector('.adc-value').value = param.calibrationValue;
            row.querySelector('.calculated-zero-value').value = param.calibrationPeriod;
        }
    });
}



// Запрос пороговых параметров при загрузке страницы
document.addEventListener("DOMContentLoaded", () => {
    setTimeout(requestCalibrationParameters, 1000); // Отложите вызов на секунду
});

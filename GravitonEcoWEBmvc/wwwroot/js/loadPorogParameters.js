// Функция для запроса пороговых параметров при загрузке страницы
async function requestPorogParameters() {
    try {
        const response = await fetch('/api/Modbus/read-porog-parameters');
        if (response.ok) {
            const porogParameters = await response.json();
            updatePorogParameterValues(porogParameters);
        } else {
            console.error("Ошибка при запросе пороговых параметров.");
        }
    } catch (error) {
        console.error("Ошибка:", error);
    }
}

// Обновление пороговых параметров на странице
function updatePorogParameterValues(porogParameters) {
    porogParameters.forEach(param => {
        const row = document.querySelector(`tr[data-id="${param.id}"]`);
        if (row) {
            row.querySelector('.porog1-value').value = param.porog1Value;
            row.querySelector('.porog2-value').value = param.porog2Value;
            row.querySelector('.increment-value').value = param.incrementValue;
            row.querySelector('.period-value').value = param.periodValue;
        }
    });
}

// Запрос пороговых параметров при загрузке страницы
document.addEventListener("DOMContentLoaded", () => {
    requestPorogParameters();
});
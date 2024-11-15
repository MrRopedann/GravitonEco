isEditing = false;
currentIntervalId = null;

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
                // console.error('Error fetching current data:', error);
            });
    }
}



// Функция для изменения интервала опроса данных в зависимости от выбора
function updatePollingInterval() {
    const dropdown = document.getElementById('update-interval-dropdown');
    if (!dropdown) {
        console.error("Dropdown для интервала не найден");
        return;
    }

    const interval = parseInt(dropdown.value, 10);

    if (currentIntervalId) {
        clearInterval(currentIntervalId);
    }

    currentIntervalId = setInterval(async () => {
        await updateCurrentData();
    }, interval * 1000);
}


// Функция для добавления или удаления класса "warning"
function toggleWarning(element, isWarning) {
    if (isWarning) {
        element.classList.add('warning');
    } else {
        element.classList.remove('warning');
    }
}

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

function startEditing() {
    isEditing = true;
}

// Возобновление обновления данных после завершения редактирования
function stopEditing() {
    isEditing = false;
}


// Запуск всех функций при загрузке страницы
document.addEventListener('DOMContentLoaded', () => {
    // Запуск начального интервала опроса
    updatePollingInterval();

    // Добавляем обработчик на изменение выпадающего списка для смены интервала
    const dropdown = document.getElementById('update-interval-dropdown');
    dropdown.addEventListener('change', updatePollingInterval); // Смена интервала при изменении значения
});
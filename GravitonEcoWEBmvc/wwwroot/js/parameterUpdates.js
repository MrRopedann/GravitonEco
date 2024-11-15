// parameterUpdates.js

const porogParams = {};

// Функция для отслеживания изменений параметров в input полях
function updatePorogParam(input, id, field) {
    if (!porogParams[id]) porogParams[id] = {};
    porogParams[id][field] = parseInt(input.value);
}

// Функция для отправки изменений параметров на сервер
async function submitPorogChanges(id) {
    if (porogParams[id]) {
        const updatedParam = { id, ...porogParams[id] };

        try {
            const response = await fetch('/api/Modbus/update-porog-parameters', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(updatedParam)
            });

            if (response.ok) {
                //alert('Данные успешно записаны!');
                delete porogParams[id]; // Очищаем изменения для данного устройства после успешной записи
            } else {
                alert('Ошибка записи данных.');
            }
        } catch (error) {
            console.error('Ошибка:', error);
            alert('Ошибка при отправке данных.');
        }
    }
}


async function handleEnterKey(event, id, field) {
    if (event.key === 'Enter') {
        event.preventDefault();

        const newValue = parseInt(event.target.value);
        const updatedParam = { id, field, value: newValue };
        try {
            // Выполняем запрос на запись значения
            const response = await fetch('/api/Modbus/write-parameter', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(updatedParam)
            });
        } catch (error) {
            console.error('Ошибка:', error);
            alert('Ошибка при записи данных.');
        }
    }
}



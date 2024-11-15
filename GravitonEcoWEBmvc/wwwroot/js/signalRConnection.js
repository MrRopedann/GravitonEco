const connection = new signalR.HubConnectionBuilder()
    .withUrl("/deviceHub")
    .build();

// Обработка события получения данных через SignalR для обновления `CurrentValue` и значений алармов
connection.on("ReceiveDeviceUpdates", function (devices) {
    const isAlarmEnabled = document.getElementById("alarm-toggle").checked; // Проверяем состояние галочки

    devices.forEach(device => {
        const row = document.querySelector(`tr[data-id="${device.id}"]`);
        if (row) {
            const valueCell = row.querySelector('.current-value');
            if (valueCell) {
                valueCell.textContent = device.currentValue;
            }
                const alarm1Input = row.querySelector('.porog1-value');
                const alarm2Input = row.querySelector('.porog2-value');
                const alarm3Input = row.querySelector('.increment-value');
                const periodInput = row.querySelector('.period-value');

                if (alarm1Input) alarm1Input.style.color = device.alarm1Value ? "red" : "black";
                if (alarm2Input) alarm2Input.style.color = device.alarm2Value ? "red" : "black";
                if (alarm3Input) alarm3Input.style.color = device.alarm3Value ? "red" : "black";
                if (periodInput) periodInput.style.color = device.alarm3Value ? "red" : "black";
        }
    });
});



// Начинаем соединение и обрабатываем ошибки подключения
connection.start().catch(err => console.error("Ошибка подключения:", err));

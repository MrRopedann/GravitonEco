// alarmPolling.js

async function toggleAlarmPolling() {
    const isEnabled = document.getElementById("alarm-toggle").checked;

    try {
        await fetch("/api/Modbus/update-alarm-polling-status", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(isEnabled)
        });
    } catch (error) {
        console.error("Ошибка при отправке статуса опроса алармов:", error);
    }
}

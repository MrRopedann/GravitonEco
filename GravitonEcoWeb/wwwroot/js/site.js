function syncTableColumns() {
    // Получаем все таблицы
    const tables = document.querySelectorAll('table');
    const columnWidths = [];

    // Перебираем все строки первой таблицы, чтобы получить максимальные ширины колонок
    tables.forEach(table => {
        const headers = table.querySelectorAll('th');
        headers.forEach((th, index) => {
            const thWidth = th.offsetWidth;
            columnWidths[index] = Math.max(columnWidths[index] || 0, thWidth);
        });
    });

    // Применяем максимальную ширину ко всем колонкам всех таблиц
    tables.forEach(table => {
        const headers = table.querySelectorAll('th');
        const cells = table.querySelectorAll('td');

        headers.forEach((th, index) => {
            th.style.width = `${columnWidths[index]}px`;
        });

        cells.forEach((td, index) => {
            td.style.width = `${columnWidths[index % headers.length]}px`;
        });
    });
}

// Вызываем функцию после рендеринга таблиц
document.addEventListener('DOMContentLoaded', syncTableColumns);

// Функция для отображения ошибок
function showError(message) {
    const errorMessage = document.getElementById('error-message');
    errorMessage.textContent = message;
    errorMessage.style.display = 'block';
}

// Скрытие ошибок
function hideError() {
    const errorMessage = document.getElementById('error-message');
    errorMessage.style.display = 'none';
}




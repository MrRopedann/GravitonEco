// Добавляем обработчик для всех кнопок с классом "tab-button"
document.querySelectorAll('.tab-button').forEach(button => {
    button.addEventListener('click', function() {
        const target = document.querySelector(this.getAttribute('data-target'));

        // Убираем активное состояние у всех кнопок
        document.querySelectorAll('.tab-button').forEach(btn => btn.classList.remove('active'));

        // Добавляем активное состояние только на нажатую кнопку
        this.classList.add('active');

        // Закрываем все открытые блоки перед тем, как открыть новый
        document.querySelectorAll('.collapse-content').forEach(content => {
            content.classList.remove('open');
            content.style.maxHeight = '0';
        });

        // Открываем соответствующий контент
        target.classList.add('open');
        target.style.maxHeight = target.scrollHeight + 'px';
    });
});
// deviceTableToggle.js

function toggleTable(groupId) {
    const table = document.getElementById('table-' + groupId);
    if (table) {
        table.style.display = table.style.display === 'none' ? 'table' : 'none';
    }
}

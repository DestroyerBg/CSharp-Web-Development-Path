function deleteByEmail() {
    const tbody = document.querySelector('#customers tbody');
    const input = document.querySelector('input[type = text]');
    const result = document.getElementById('result');

    const emails = Array.from(tbody.children);

    for (const row of emails) {
        const getEmail = row.querySelector('td:nth-child(2)');
        if (getEmail.textContent == input.value) {
            tbody.removeChild(row);
            result.textContent = 'Deleted';
            input.value = '';
            return;
        }
    }

    result.textContent = 'Not found.';
    input.value = '';


}
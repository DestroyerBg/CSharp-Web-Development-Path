function sumTable() {
    const rows = document.querySelectorAll('table tbody tr td:nth-child(even)');
    const total = document.getElementById('sum')
    let result = 0;
    for (const number of rows) {
        result += Number(number.textContent);
    }
    total.textContent = result;

}
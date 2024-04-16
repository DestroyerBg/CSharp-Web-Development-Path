function generateReport() {
    const thElements = Array.from(document.querySelectorAll('table thead th input'));
    const tbodyElements = Array.from(document.querySelectorAll('table tbody tr'));
    const output = document.getElementById('output');

    const resultArray = [];
    
    for (const tbodyElement of tbodyElements) {
        const cells = Array.from(tbodyElement.children);
        const rowObject = {};
        for (let i = 0; i < thElements.length; i++) {
            if (thElements[i].checked) {
                const attribute = thElements[i].getAttribute('name');
                rowObject[attribute] = cells[i].textContent;
            }

        }
        resultArray.push(rowObject);

        output.value = JSON.stringify(resultArray,null,2);
    }
}
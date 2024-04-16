function addItem() {
    const ulElements = document.getElementById('items');
    const input = document.getElementById('newItemText');
    const element = document.createElement('li');
    element.textContent = input.value;
    ulElements.appendChild(element);
    input.value = '';
}



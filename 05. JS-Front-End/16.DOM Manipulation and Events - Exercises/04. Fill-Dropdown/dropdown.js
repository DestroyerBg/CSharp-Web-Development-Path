function addItem() {
    const inputText = document.getElementById('newItemText');
    const inputValue = document.getElementById('newItemValue');
    const menu = document.getElementById('menu');

    const newOption = document.createElement('option');
    newOption.textContent = inputText.value;
    newOption.value = inputValue.value;

    menu.appendChild(newOption);

    inputText.value = '';
    inputValue.value = '';
}
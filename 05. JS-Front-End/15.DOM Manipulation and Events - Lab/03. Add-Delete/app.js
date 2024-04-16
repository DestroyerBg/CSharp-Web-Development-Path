function addItem() {
    const ulElements = document.getElementById('items')
    const input = document.getElementById('newItemText');

    const listItem = document.createElement('li');
    listItem.textContent = input.value;

    const deleteElement = document.createElement('a');
    deleteElement.href = '#';
    deleteElement.textContent = '[Delete]';

    listItem.appendChild(deleteElement);

    ulElements.appendChild(listItem);

    deleteElement.addEventListener('click', () => {
        ulElements.removeChild(listItem);
    });

    input.value = '';
}
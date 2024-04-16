function create(words) {
    const element = document.getElementById('content');
    for (const word of words) {
        const paragraph = document.createElement('p');
        paragraph.textContent = word;
        paragraph.style.display = 'none';
        const div = document.createElement('div');
        div.appendChild(paragraph);
        div.addEventListener('click', () => {
            paragraph.style.display = 'block';
        });
        element.appendChild(div);
    }

    
}
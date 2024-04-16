function colorize() {
    const liElements = document.querySelectorAll('table tr:nth-child(even)');
    for (const element of liElements) {
        element.style.background = 'Teal';
    }
}
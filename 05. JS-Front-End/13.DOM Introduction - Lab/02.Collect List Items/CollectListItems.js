function extractText() {
    const elements = Array.from(document.getElementById('items').children)
    const textArea = document.getElementById('result');
    let text = []
    for (const element of elements) {
        text.push(element.textContent);
    }
    textArea.textContent = text.join('\n');
}
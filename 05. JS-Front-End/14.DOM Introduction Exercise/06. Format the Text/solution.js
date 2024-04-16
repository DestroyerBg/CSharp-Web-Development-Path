function solve() {
    const input = document.getElementById('input');
    const output = document.getElementById('output');

    let allSentences = input.value.split('.');
    allSentences =  allSentences.filter(s => s !== ''
    && s !== ' ')
    .map(s => s.trim())
    .map(s => s = s +'.');
    
    let htmlResult = [];
    for (const sentence of allSentences) {

        htmlResult.push(sentence);

        if (htmlResult.length == 3) {
            let element = document.createElement('p');
            element.textContent = htmlResult.join('.');
            output.appendChild(element);
            htmlResult = [];
        }
    }

    if (htmlResult.length != 0) {
        let element = document.createElement('p');
        element.textContent = htmlResult.join('.');
        output.appendChild(element);
    }

    input.value = '';
    
}
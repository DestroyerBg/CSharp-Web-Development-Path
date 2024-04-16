function solve() {
    function transformToCamelCase(input) {
        let text = input.split(' ')
        .map(word => word.toLowerCase())
        .map(word => {
            return word.charAt(0).toUpperCase() + word.slice(1);
        });

        text[0] = text[0].charAt(0).toLowerCase() + text[0].slice(1);

        return text.join('');
    }

    function transfortToPascalCase(input) {
        let text = input.split(' ')
        .map(word => word.toLowerCase())
        .map(word => {
            return word.charAt(0).toUpperCase() + word.slice(1);
        });

        return text.join('');
    }
    
    let input = document.getElementById('text').value;
    let namingConvension = document.getElementById('naming-convention').value;
    let output = document.getElementById('result');
    let result = '';
    if (namingConvension == 'Camel Case') {
        result = transformToCamelCase(input);
    } else if (namingConvension == 'Pascal Case') {
        result = transfortToPascalCase(input);
    } else {
        result = 'Error!';
    }

    output.textContent = result;
}
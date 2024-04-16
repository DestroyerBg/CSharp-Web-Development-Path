function solve(input) {
    let arr = input.split(' ');
    let occurences = {};
    for (const word of arr) {
        if (!occurences.hasOwnProperty(word.toLowerCase())) {
            occurences[word.toLowerCase()] = 0;
        }
        occurences[word.toLowerCase()]++;
    }

    let result = [];

    for (const key in occurences) {
        if (occurences[key] % 2 == 1) {
            result.push(key);
        }
    }
    console.log(result.join(' '));
    
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
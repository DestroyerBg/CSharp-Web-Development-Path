function solve(text) {
    let result = text.toUpperCase().split(/[\W]+/).filter(e => e.length > 0).join(', ');
    console.log(result);
}

solve('Hi, how are you?');
solve('hello')
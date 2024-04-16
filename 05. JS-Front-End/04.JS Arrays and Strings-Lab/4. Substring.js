function solve(text, start, end) {
    const result = text.substring(start,start+end);
    console.log(result);
}

solve('ASentence', 1, 8);
solve('SkipWord', 4, 7);
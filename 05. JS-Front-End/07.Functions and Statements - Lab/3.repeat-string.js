function solve(text,timesToRepeat) {
    function repeatString(text, timesToRepeat) {
        let result = '';
        for (let index = 0; index < timesToRepeat; index++) {
            result = result + text;
        }
        return result;
    }
    return repeatString(text,timesToRepeat);
}
console.log(solve("abc", 3));
console.log(solve("String", 2));
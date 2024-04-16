function solve(start,end) {
    function getRangeOfCharacters(params) {
        let result = [];
        let startIndex = start.charCodeAt(0);
        let endIndex = end.charCodeAt(0);
        for (let index = Math.min(startIndex,endIndex) + 1; index <= Math.max(startIndex,endIndex) -1; index++) {
            result.push(String.fromCharCode(index));
        }
        return result;
    }
    function printResult(input) {
        console.log(input.join(' '));
    }

    let range = getRangeOfCharacters(start,end);
    printResult(range);
}

solve('a',
'd'
)
solve('#',
':'
)

solve('C',
'#'
)
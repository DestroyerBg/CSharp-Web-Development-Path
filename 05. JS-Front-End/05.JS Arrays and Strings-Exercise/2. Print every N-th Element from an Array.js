function solve(numbers, step) {
    let result = [];
    for (let index = 0; index < numbers.length; index+=step) {
        result.push(numbers[index]);
    }
    return result;
}

console.log(solve(['5','20','31','4','20'],2));
console.log(solve(['dsa','asd','test','tset'],2));
console.log(solve(['dsa','asd','test','tset'],2));
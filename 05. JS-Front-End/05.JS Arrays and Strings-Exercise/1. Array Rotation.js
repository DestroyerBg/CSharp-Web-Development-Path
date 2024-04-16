function solve(numbers, numberOfRotations) {
    for (let index = 0; index < numberOfRotations; index++) {
       let currNum = numbers.shift();
       numbers.push(currNum);
    }
    console.log(numbers.join(' '));
}

solve([51, 47, 32, 61, 21], 2);
solve([32, 21, 61, 1], 4);
solve([2, 4, 15, 31], 5);
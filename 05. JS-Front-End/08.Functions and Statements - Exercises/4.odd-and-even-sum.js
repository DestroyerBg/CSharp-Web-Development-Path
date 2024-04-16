function solve(number) {
    function getSumOfDigits(numbers, filter) {
        let filteredNumbers = numbers.filter(filter);
        let sum = filteredNumbers.reduce((a, b) => a + b, 0);
        return sum;
    }
    function printResult(oddSum, evenSum) {
        console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
    }
    let numbers = number
        .toString()
        .split('')
        .map(Number);
    let oddSum = getSumOfDigits(numbers, x => x % 2 != 0);
    let evenSum = getSumOfDigits(numbers, x => x % 2 == 0);
    printResult(oddSum,evenSum);
}

solve(1000435);
solve(3495892137259234)
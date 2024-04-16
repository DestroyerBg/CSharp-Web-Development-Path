function solve(number, power) {
    function raiseToPower(number,power) {
        return Math.pow(number,power);
    }
    function printResult(input) {
        console.log(input);
    }
    const result = raiseToPower(number,power);
    printResult(result);
}
solve(2,8);
solve(3,4);
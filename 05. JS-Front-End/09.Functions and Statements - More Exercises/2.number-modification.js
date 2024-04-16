function solve(number) {
    function calculateAverage(numbersArray) {
        let sum = numbersArray.reduce((a,b) => a + b ,0);
        return sum/numbersArray.length;
    }

    let numbersArray = number.toString().split('').map(Number);
    while (calculateAverage(numbersArray) <= 5) {
        numbersArray.push(9);
    }
    console.log(numbersArray.join(''));
}

solve(101);
solve(5835);
solve(0);
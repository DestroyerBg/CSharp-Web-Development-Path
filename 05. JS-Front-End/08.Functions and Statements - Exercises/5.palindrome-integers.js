function solve(numbers) {
    function checkNumber(number) {
        let reversedNumberString = number
            .toString()
            .split('')
            .map(Number)
            .reverse()
            .join('');
        let reversed = parseInt(reversedNumberString);
        if (reversed == number) {
            console.log(true);
            return;
        }
        console.log(false);
    }

    for (const number of numbers) {
        checkNumber(number);
    }
}

// solve([123,323,421,121]);
solve([32,2,232,1010])
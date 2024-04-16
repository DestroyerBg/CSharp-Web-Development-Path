function solve(number) {
    function getAllDivisors(number) {
        let rangeOfDivisors = [];
        for (let index = 1; index < number; index++) {
            if (number % index == 0) {
                rangeOfDivisors.push(index);
            }
        }
        return rangeOfDivisors;
    }

    function getSum(divisors) {
        return divisors.reduce((a,b) => a + b, 0) 
    }


    let rangeOfDivisors = getAllDivisors(number);
    let sum = getSum(rangeOfDivisors);
    const isPerfect = (sum,number) => sum === number;
    
    

    if (isPerfect(sum,number)) {
        console.log(`We have a perfect number!`);
        return;
    }
    console.log(`It's not so perfect.`);
}

solve(28);
solve(6);
solve(1236498);
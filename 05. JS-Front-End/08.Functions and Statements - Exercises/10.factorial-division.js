function solve(n1,n2) {
    function calculateFactorial(number) {
        if (number == 1 || number == 0) {
            return 1;
        }
        return  number * calculateFactorial(number - 1);
    }

    const firstNumberFactoriel = calculateFactorial(n1);
    const secondNumberFactoriel = calculateFactorial(n2);
    console.log((firstNumberFactoriel/secondNumberFactoriel).toFixed(2));
}

solve(5,2);
solve(6,2);
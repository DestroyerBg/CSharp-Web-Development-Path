function solve(...numbers) {
    function getSmallestNumber(numbers) {
        numbers.sort((a,b) => a - b);
        return numbers[0] 
    }
    console.log(getSmallestNumber(numbers));
}

solve(2,5,3);
solve(600,
    342,
    123
    )
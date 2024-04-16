function solve(numbers) {
    let result = [];
    let copy = numbers.slice();
    for (let index = 0; index < numbers.length; index++) {
        let currNum = 0;
        if (index % 2 == 0) {
           currNum = Math.min(...copy);  
        }else{
            currNum = Math.max(...copy)
        }
        result.push(currNum);
        copy.splice(copy.findIndex(number => number == currNum),1);
        
    }
    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
function solve(numberOfElements, input) {
   return input.splice(0,numberOfElements).reverse().join(' ');
}

console.log(solve(3, [10, 20, 30, 40, 50]));
console.log(solve(4, [-1, 20, 99, 5]));
console.log(solve(2, [66, 43, 75, 89, 47]));
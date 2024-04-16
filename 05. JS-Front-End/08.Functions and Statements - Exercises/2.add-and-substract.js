function solve(n1,n2,n3) {
    const sum = (a,b) => a + b;
    const substract = (a,b) => a - b;
    console.log(substract(sum(n1,n2),n3));
}
solve(23,6,10);
solve(1,17,30);
solve(42,58,100);
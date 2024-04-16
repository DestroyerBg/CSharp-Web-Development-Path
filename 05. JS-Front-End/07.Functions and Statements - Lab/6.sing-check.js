function solve(n1,n2,n3) {
    const multiply = (n1,n2) => n1*n2;
    if (multiply(multiply(n1,n2),n3) >= 0){
        return 'Positive';
    }
    return 'Negative'
}
// console.log(solve(5,
//     12,
//    -15
//    ));

   console.log(solve(-6,
    -12,
     14
    ));
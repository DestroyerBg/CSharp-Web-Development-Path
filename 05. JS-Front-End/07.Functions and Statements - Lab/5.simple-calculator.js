function solve(numberOne, numberTwo, operation) {
    function getOperation(operation) {
        if (operation == 'multiply') {
            return (n1,n2) => n1*n2;
        }else if(operation == 'divide'){
            return (n1,n2) => n1/n2;
        }else if(operation == 'add'){
            return (n1,n2) => n1+n2;
        }else if(operation == 'subtract'){
            return (n1,n2) => n1-n2;
        }
    }

    const operator = getOperation(operation);
    const result = operator(numberOne,numberTwo);
    console.log(result);
}
solve(5,5,'multiply');
solve(40,
    8,
    'divide'
    )
function solve(numberOne, operator, numberTwo) {
    let result = 0;
    if (operator == '+') {
        result = numberOne + numberTwo;
    }
    else if(operator == '-'){
        result = numberOne - numberTwo;
    }
    else if(operator == '/'){
        result = numberOne / numberTwo;
    }
    else if(operator == '*'){
        result = numberOne * numberTwo;
    }
    console.log(result.toFixed(2));
}

solve(5,'+',10);
solve(25.5,'-',3);
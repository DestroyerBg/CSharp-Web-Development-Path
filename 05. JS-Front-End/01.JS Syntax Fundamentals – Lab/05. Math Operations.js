function calculator(numberOne, numberTwo, operator) {
    if (operator == '+') {
        console.log(`${numberOne + numberTwo}`);
    } else if (operator == '-') {
        console.log(`${numberOne - numberTwo}`);
    }
    else if (operator == '*') {
        console.log(`${numberOne * numberTwo}`);
    }
    else if (operator == '/') {
        console.log(`${numberOne / numberTwo}`);
    }
    else if (operator == '%') {
        console.log(`${numberOne % numberTwo}`);
    }
    else if (operator == '**') {
        console.log(`${numberOne ** numberTwo}`);
    }
}

calculator(5, 6, '+');
calculator(3, 5.5, '*');
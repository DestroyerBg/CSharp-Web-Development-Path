function cook(number, ...operations) {
    number = parseInt(number);
    for (let index = 0; index < operations.length; index++) {
        let currOperation = operations[index];
        if (currOperation == 'chop') {
            number/=2;
            console.log(number);
        }else if (currOperation == 'dice') {
            number = Math.sqrt(number);
            console.log(number);
        }else if (currOperation == 'spice') {
            number++;
            console.log(number);
        }else if (currOperation == 'bake') {
            number*=3;
            console.log(number);
        }else if (currOperation == 'fillet') {
            number-= number*0.20;
            console.log(number);
        }

    }
}

// cook('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cook('9', 'dice', 'spice', 'chop', 'bake', 'fillet');
function solve(password) {
    function validateLenght(password) {
        if (password.length >= 6 && password.length <= 10) {
            return true;
        }
        return false;
    }
    
    function passwordShouldContainOnlyLettersAndDigits(password) {
        let pattern = /^[A-Za-z0-9]+$/gm;
        if (pattern.test(password)) {
            return true;
        }
        return false;
    }
    function passwordShouldContainAtLeastTwoDigits(password) {
        let pattern = /[0-9]{2,}/gm;
        if (pattern.test(password)) {
            return true;
        }
        return false;
    }

    let errors = [];
    if (!validateLenght(password)) {
        errors.push('Password must be between 6 and 10 characters');
    }

    if (!passwordShouldContainOnlyLettersAndDigits(password)) {
        errors.push('Password must consist only of letters and digits');
    }

    if (!passwordShouldContainAtLeastTwoDigits(password)) {
        errors.push('Password must have at least 2 digits');
    }
    
    if (errors.length != 0) {
        for (const error of errors) {
            console.log(error);
        }
        return;
    }
    console.log(`Password is valid`);
}

solve('parola1');
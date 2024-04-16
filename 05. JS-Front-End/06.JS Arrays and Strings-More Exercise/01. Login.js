function solve(arguments) {
    function getPassword(username) {
        let arr = username.split('');
        arr = arr.reverse();
        return arr.join('');
    }
    let username = arguments.shift();
    let password = getPassword(username);
    for (let index = 0; index < arguments.length; index++) {
        let currTry = arguments[index];
        if (currTry == password) {
            console.log(`User ${username} logged in.`);
            return;
        }

        if (index != 3) {
            console.log(`Incorrect password. Try again.`);
            continue;
        }

        console.log(`User ${username} blocked!`);
        return;
    }
}

solve(['Acer','login','go','let me in','recA']);
solve(['momo','omom']);
solve(['sunny','rainy','cloudy','sunny','not sunny'])
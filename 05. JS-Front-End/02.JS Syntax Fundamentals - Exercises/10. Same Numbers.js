function sameNumberChecker(number) {
    let numArr = number.toString();
    let arr = [];
    let sum = 0;
    for (let index = 0; index < numArr.length; index++) {
        arr[index] = numArr[index];
        sum += parseInt(numArr[index]);
    }
    let sameNum =  arr.every(e => e === arr[0]);
    if (sameNum == true) {
        console.log('true');
    }
    else{
        console.log('false');
    }
    console.log(sum);
}

sameNumberChecker(2222222);
sameNumberChecker(1234);
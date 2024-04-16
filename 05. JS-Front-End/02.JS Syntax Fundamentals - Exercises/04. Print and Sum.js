function printAndSum(startNum, endNum) {
    let allNums = '';
    let sum = 0;
    for (let index = startNum; index <= endNum; index++) {
        allNums = allNums+ `${index} `;
        sum+=index;
    }
    console.log(allNums);
    console.log(`Sum: ${sum}`);
}

printAndSum(5,10);
printAndSum(0,26);
printAndSum(50,60);
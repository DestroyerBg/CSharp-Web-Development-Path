function solve(startingYield) {
    let daysCount = 0;
    let totalSpice = 0;
    if (startingYield < 100) {
        console.log(daysCount);
        console.log(totalSpice);
        return;
    }
    while (startingYield >= 100) {
        daysCount++;
        totalSpice+=startingYield;
        startingYield-=10;
        totalSpice-=26;
    }
    totalSpice-=26;
    console.log(daysCount);
    console.log(totalSpice);
}

solve(111);
solve(450);
solve(85);
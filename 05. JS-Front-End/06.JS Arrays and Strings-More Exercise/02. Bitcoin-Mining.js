function solve(gold) {
    function exchange(goldMinedForCurrentDayInGrams) {
        let oneGramGoldPrice = 67.51;
        return goldMinedForCurrentDayInGrams * oneGramGoldPrice;
    }
    let daysCounter = 0;
    let amountOfMoney = 0;
    let bitcoinPrice = 11949.16;
    let bitcoinCounter = 0;
    let firstDayBitcoinBought = -1;
    for (let index = 0; index < gold.length; index++) {
        daysCounter++;
        if (daysCounter % 3 == 0) {
            let goldAfterSteal = gold[index] - gold[index] * 0.30;
            amountOfMoney+= exchange(goldAfterSteal);
        }
        else{
            amountOfMoney+= exchange(gold[index]);
        }
        
        if (amountOfMoney >= bitcoinPrice) {
            bitcoinCounter++;
            amountOfMoney-=bitcoinPrice;
            if (firstDayBitcoinBought == -1) {
                firstDayBitcoinBought = daysCounter;
            }
        }

    }
    while (amountOfMoney >= bitcoinPrice) {
        bitcoinCounter++;
        amountOfMoney-=bitcoinPrice;
    }
    console.log(`Bought bitcoins: ${bitcoinCounter}`);
    if (bitcoinCounter > 0) {
        console.log(`Day of the first purchased bitcoin: ${firstDayBitcoinBought}`);
    }
    console.log(`Left money: ${amountOfMoney.toFixed(2)} lv.`);
}

solve([100, 200, 300]);
solve([50, 100]);
solve([3124.15, 504.212, 2511.124]);
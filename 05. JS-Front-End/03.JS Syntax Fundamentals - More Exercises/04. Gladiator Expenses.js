function solve(lostFightsCount, helmetPrice, swordPrice, shieldPrice, armorPrice){
    let price = 0;
    let totalShieldTrashed = 0;
    for (let index = 1; index <= lostFightsCount; index++) {
        if (index % 2 == 0) {
            price+=helmetPrice;
        }
        if(index % 3 == 0){
            price+=swordPrice;
        }

        if (index % 2 == 0 && index % 3 == 0) {
            price+=shieldPrice;
            totalShieldTrashed++;
        }

        if (totalShieldTrashed % 2 == 0 && totalShieldTrashed != 0) {
            price+=armorPrice;
            totalShieldTrashed = 0;
        }
    }
    console.log(`Gladiator expenses: ${Math.round(price).toFixed(2)} aureus`);
}

solve(7,2,3,4,5);
solve(23,12.50,21.50,40,200);

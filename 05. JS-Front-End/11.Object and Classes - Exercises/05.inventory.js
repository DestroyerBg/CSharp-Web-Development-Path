function solve(input) {
    let heroes = [];
    for (let index = 0; index < input.length; index++) {
        let currLine = input[index];
        let [heroName, level, items] = currLine.split(' / ');
        const hero = {
            hero: heroName,
            level: Number(level),
            items: items.split(', '),
        };
        heroes.push(hero); 
    }

    heroes.sort((a,b) => a.level - b.level).forEach(h => {
        console.log(`Hero: ${h.hero}`);
        console.log(`level => ${h.level}`);
        console.log(`items => ${h.items.join(', ')}`);
    });
}

solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]
    )
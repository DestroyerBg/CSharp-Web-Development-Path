function solve(commands) {
    const operations = {
        soap: (n) => n+=10,
        water: (n) => n+= n*0.20,
        'vacuum cleaner': (n) => n+= n*0.25,
        mud: (n) => n-= n*0.10,
    }

    let percentCleaned = 0;
    for (let index = 0; index < commands.length; index++) {
        percentCleaned = operations[commands[index]](percentCleaned);
    }
    console.log(`The car is ${percentCleaned.toFixed(2)}% clean.`);
}

solve(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);
solve(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);
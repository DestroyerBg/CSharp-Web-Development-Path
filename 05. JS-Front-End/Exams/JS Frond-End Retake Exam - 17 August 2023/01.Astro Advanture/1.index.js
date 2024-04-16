function solve(input) {
    const astrounatsCount = Number(input.shift());
    const team = {};

    for (let i = 0; i < astrounatsCount; i++) {
        const line = input.shift();
        const tokens = line.split(' ');
        const name = tokens[0];
        const oxygenLevel = Number(tokens[1]);
        const energyReserves = Number(tokens[2]);
        team[name] = {
            oxygenLevel,
            energyReserves,
        };
    }

    let currLine = input.shift();
    while (currLine != 'End') {
        const tokens = currLine.split(' - ');
        const command = tokens[0];
        const name = tokens[1];
        const amount = Number(tokens[2]);
        if (command == 'Explore') {
            const astrounat = team[name];
            if (astrounat.energyReserves >= amount) {
                astrounat.energyReserves-= amount;
                console.log(`${name} has successfully explored a new area and now has ${astrounat.energyReserves} energy!`);
            }else{
                console.log(`${name} does not have enough energy to explore!`);
            }
        }
        else if (command == 'Refuel') {
            const astrounat = team[name];
            const currEnergy = astrounat.energyReserves;
            if (currEnergy + amount > 200) {
                astrounat.energyReserves = 200;
                console.log(`${name} refueled their energy by ${200 - currEnergy}!`);
            }else{
                astrounat.energyReserves += amount;
                console.log(`${name} refueled their energy by ${astrounat.energyReserves - currEnergy}!`);
            }
        }
        else if(command == 'Breathe'){
            const astrounat = team[name];
            const currBreathe = astrounat.oxygenLevel;
            if (currBreathe + amount > 100) {
                astrounat.oxygenLevel = 100;
                console.log(`${name} took a breath and recovered ${100 - currBreathe} oxygen!`);
            }else{
                astrounat.oxygenLevel+= amount;
                console.log(`${name} took a breath and recovered ${astrounat.oxygenLevel - currBreathe} oxygen!`);
            }
        }


        currLine = input.shift();
    }

    for (const astrounat in team) {
        console.log(`Astronaut: ${astrounat}, Oxygen: ${team[astrounat].oxygenLevel}, Energy: ${team[astrounat].energyReserves}`);
    }
}

solve([  '4',
'Alice 60 100',
'Bob 40 80',
'Charlie 70 150',
'Dave 80 180',
'Explore - Bob - 60',
'Refuel - Alice - 30',
'Breathe - Charlie - 50',
'Refuel - Dave - 40',
'Explore - Bob - 40',
'Breathe - Charlie - 30',
'Explore - Alice - 40',
'End'

]
);
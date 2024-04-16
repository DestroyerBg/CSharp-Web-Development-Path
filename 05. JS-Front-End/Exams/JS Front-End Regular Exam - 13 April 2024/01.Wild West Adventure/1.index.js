function solve(input) {
    const numberOfCharacters = Number(input.shift());
    const team = {};

    for (let i = 0; i < numberOfCharacters; i++) {
        const currLine = input.shift();
        const tokens = currLine.split(' ');
        const heroName = tokens[0];
        const HP = Math.min(Number(tokens[1],100));
        const bullets = Math.min(Number(tokens[2],6));
        team[heroName] = {};
        team[heroName].HP = HP;
        team[heroName].bullets = bullets;
    }
    
    let currLine = input.shift();
    while (currLine != 'Ride Off Into Sunset') {
        const tokens = currLine.split(' - ');
        const command = tokens[0];
        if (command == 'FireShot') {
            const characterName = tokens[1];
            const target = tokens[2];
            const character = team[characterName];
            if (character.bullets > 0 ) {
                character.bullets--;
                console.log(`${characterName} has successfully hit ${target} and now has ${character.bullets} bullets!`);
            }else {
                console.log(`${characterName} doesn't have enough bullets to shoot at ${target}!`);
            }
        }else if(command == 'TakeHit'){
            const characterName = tokens[1];
            const damage = Number(tokens[2]);
            const attacker = tokens[3];
            const character = team[characterName];
            character.HP -= damage;
            if (character.HP > 0) {
                console.log(`${characterName} took a hit for ${damage} HP from ${attacker} and now has ${character.HP} HP!`);
            }else {
                delete team[characterName];
                console.log(`${characterName} was gunned down by ${attacker}!`);
            }
        }else if(command == 'Reload'){
            const characterName = tokens[1];
            const character = team[characterName];
            if (character.bullets < 6) {
                const currBullets = character.bullets;
                character.bullets = 6;
                console.log(`${characterName} reloaded ${6 - currBullets} bullets!`);
            }else{
                console.log(`${characterName}'s pistol is fully loaded!`);
            }
        }else if(command == 'PatchUp'){
            const characterName = tokens[1];
            const character = team[characterName];
            const amount = Number(tokens[2]);
            if (character.HP < 100) {
                const currHp = character.HP;
                character.HP +=amount;
                if (character.HP > 100) {
                    character.HP = 100;
                }
                console.log(`${characterName} patched up and recovered ${character.HP - currHp} HP!`);
            }else {
                console.log(`${characterName} is in full health!`);
            }
        }

        currLine = input.shift();
    }

    for (const character in team) {
        console.log(`${character}\n HP: ${team[character].HP}\n Bullets: ${team[character].bullets}`);
    }

}

solve(["2",
"Gus 100 4",
"Walt 100 5",
"FireShot - Gus - Bandit",
"TakeHit - Walt - 100 - Bandit",
"Reload - Gus",
"Ride Off Into Sunset"])

;

function solve(input) {
    const numberOfRacers = Number(input.shift());
    const allRacers = {};

    for (let i = 0; i < numberOfRacers; i++) {
        const line = input.shift();
        const tokens = line.split('|');
        const racerName = tokens[0];
        const fuelCapacity = Number(tokens[1]);
        const position = Number(tokens[2]);
        allRacers[racerName] = {};
        allRacers[racerName].fuelCapacity = Math.min(Number(fuelCapacity),100);
        allRacers[racerName].position = Number(position);
    }
    
    let currLine = input.shift();
    while(currLine != 'Finish'){
        const tokens = currLine.split(' - ');
        const command = tokens[0];
        if (command == 'StopForFuel') {
            const racerName = tokens[1];
            const minFuel = Number(tokens[2]);
            const changedPosition = Number(tokens[3]);
            const racer = allRacers[racerName];
            
            if (racer.fuelCapacity < minFuel) {
                racer.position = changedPosition;
                console.log(`${racerName} stopped to refuel but lost his position, now he is ${changedPosition}.`);
            }else{
                console.log(`${racerName} does not need to stop for fuel!`);
            }
        }else if(command == 'Overtaking'){
           const racerOneName = tokens[1];
           const racerTwoName = tokens[2];
            if (allRacers[racerOneName].position < allRacers[racerTwoName].position) {
                const swap = allRacers[racerOneName].position;
                allRacers[racerOneName].position = allRacers[racerTwoName].position;
                allRacers[racerTwoName].position = swap;
                console.log(`${racerOneName} overtook ${racerTwoName}!`);
            }
            
        }else if(command == 'EngineFail'){
            const racerName = tokens[1];
            delete allRacers[racerName];
            console.log(`${racerName} is out of the race because of a technical issue, ${tokens[2]} laps before the finish.`);
        }
        
        
        currLine = input.shift();
    }

    for (const racer in allRacers) {
        console.log(`${racer}\n  Final position: ${allRacers[racer].position}`);
    }
}

solve(["4",
"Valentino Rossi|100|1",
"Marc Marquez|90|3",
"Jorge Lorenzo|180|4",
"Johann Zarco|80|2",
"StopForFuel - Johann Zarco - 90 - 5",
"Overtaking - Marc Marquez - Jorge Lorenzo",
"EngineFail - Marc Marquez - 10",
"Finish"])
;

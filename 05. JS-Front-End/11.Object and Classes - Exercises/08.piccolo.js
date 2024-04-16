function solve(input) {
    const parking = new Set();
    for (const line of input) {
        const [command, carNumber] = line.split(', ');
        command == 'IN'? parking.add(carNumber) : parking.delete(carNumber);
    }

    if (parking.size == 0) {
        console.log(`Parking Lot is Empty`);
    }

    Array.from(parking.values())
    .sort((a,b) => a.localeCompare(b))
    .forEach(p => console.log(p));

}

function solve2(input) {
    const parking = {};
    for (const line of input) {
        const [command, carNumber] = line.split(', ');
        command == 'IN'? parking[carNumber] = true : delete parking[carNumber];
    }

    if (Object.keys(parking) == 0) {
        console.log(`Parking Lot is Empty`);
        return;
    }

     Object.keys(parking)
    .sort((a,b) => a.localeCompare(b))
    .forEach(p => console.log(p));

}


solve2(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']




);
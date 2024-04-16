function solve(input) {
    const garage = {};
    for (const line of input) {
        const tokens = line.split(' - ');
        const garageNumber = tokens[0];
        if (!garage.hasOwnProperty(garageNumber)) {
            garage[garageNumber] = [];
        }
        const keyAndValues = tokens.slice(1).toString().split(', ');
        const currVehicle = {};
        for (const keyValue of keyAndValues) {
            const[key,value] = keyValue.split(': ');
            currVehicle[key] = value;
        }
        garage[garageNumber].push(currVehicle);
    }

    for (const garageNumber in garage) {
        console.log(`Garage № ${garageNumber}`);
        for (const vehicle of garage[garageNumber]) {
            const vehicleKeys = Object.entries(vehicle);
            const result = vehicleKeys.map(v => `${v[0]} - ${v[1]}`).join(', ')
            console.log(`--- ${result}`);
           
        }
    }
}

solve(['1 - color: blue, fuel type: diesel', '1 - color: red, manufacture: Audi', '2 - fuel type: petrol', '4 - color: dark blue, fuel type: diesel, manufacture: Fiat'])
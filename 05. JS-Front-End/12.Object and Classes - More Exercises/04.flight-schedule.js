function solve(input) {
    class Flight{
        _status = false;
        constructor(flightID,destination){
            this.flightID = flightID;
            this.destination = destination;
            this.status = false;
        }

        get _status(){
            return this.status;
        }

        set _status(value){
            return this.status = value; 
        }
    }

    const allFlights = [];

    const firstArray = input[0];
    const statuses = input[1];
    const givenStatuses = input[2][0];

    for (const flight of firstArray) {
        const tokens = flight.split(' ');
        let flightID = tokens[0];
        let destination = tokens.slice(1).join(' ');
        let currflight = new Flight(flightID,destination);
        allFlights.push(currflight);
    }

    for (const line of statuses) {
        const [flightID, status] = line.split(' ');
        let flight = allFlights.find(f => f.flightID == flightID);
        if (flight) {
            flight._status = status;
        }
    }

    if (givenStatuses == 'Ready to fly') {
        let filtered = allFlights.filter(f => f._status == false);
        filtered.forEach(f => console.log(`{ Destination: '${f.destination}', Status: 'Ready to fly' }`));
    }else{
        allFlights.filter(f => f._status == givenStatuses)
        .forEach(f => console.log(`{ Destination: '${f.destination}', Status: '${f._status}' }`));
    }

}

solve([["WN269 Delaware","FL2269 Oregon","WN498 Las vegas","WN3145 Ohio","WN612 Alabama","WN4010 New York","WN1173 California","DL2120 Texas","KL5744 Illinois","WN678 Pennsylvania"],["DL2120 Cancelled","WN612 Cancelled","WN1173 Cancelled","SK330 Cancelled"],["Ready to fly"]]

);
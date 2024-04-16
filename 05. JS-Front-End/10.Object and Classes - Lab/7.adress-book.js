function solve(input) {
    const addressBook = {};
    for (let index = 0; index < input.length; index++) {
       let tokens = input[index].split(':');
       let name = tokens[0];
       let address = tokens[1];
       addressBook[name] = address;
    }

    let sorted = Object.entries(addressBook).sort((a,b) => a[0].localeCompare(b[0]));
    const sortedAddressBook = Object.fromEntries(sorted);

    for (const address in sortedAddressBook) {
        console.log(`${address} -> ${sortedAddressBook[address]}`);
    }
}

solve(['Bob:Huxley Rd',
'John:Milwaukee Crossing',
'Peter:Fordem Ave',
'Bob:Redwing Ave',
'George:Mesta Crossing',
'Ted:Gateway Way',
'Bill:Gateway Way',
'John:Grover Rd',
'Peter:Huxley Rd',
'Jeff:Gateway Way',
'Jeff:Huxley Rd']
);
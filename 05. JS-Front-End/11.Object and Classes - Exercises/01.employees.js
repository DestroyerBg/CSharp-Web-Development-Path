function solve(input) {
    const people = [];

    for (const name of input) {
        let person = {
            name,
            personalNumber: name.length,
        };

        people.push(person);
    }

    people.forEach(p => console.log(`Name: ${p.name} -- Personal Number: ${p.personalNumber}`));
}

solve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    );
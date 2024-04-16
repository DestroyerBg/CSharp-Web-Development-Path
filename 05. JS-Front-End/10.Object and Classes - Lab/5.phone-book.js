function solve(array) {
    const phoneBook = {};
    for (let index = 0; index < array.length; index++) {
        let tokens = array[index].split(' ');
        let personName = tokens[0];
        let telephoneNumber = tokens[1];
        phoneBook[personName] = telephoneNumber; 
    }

    for (const key in phoneBook) {
        console.log(`${key} -> ${phoneBook[key]}`);
    }
}

solve(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
)
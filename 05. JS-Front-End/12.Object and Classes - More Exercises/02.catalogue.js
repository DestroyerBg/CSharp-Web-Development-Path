function solve(input) {
    const catalog = {};
    for (const line of input) {
        const [productName, productPrice] = line.split(' : ');
        catalog[productName] = productPrice;
    }

    const sorted = Object.entries(catalog).sort((a,b) => a[0].localeCompare(b[0]));
    let firstLetter = sorted[0][0].charAt(0);
    console.log(firstLetter);
    for (const product of sorted) {
        let currLetter = product[0].charAt(0);
        if (currLetter != firstLetter) {
            firstLetter = currLetter;
            console.log(firstLetter);
        }
        console.log(`${' '.repeat(2)}${product[0]}: ${product[1]}`);
    }
}

solve([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
    ]
    )
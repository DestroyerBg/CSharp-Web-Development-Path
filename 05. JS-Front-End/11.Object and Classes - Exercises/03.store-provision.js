function solve(currentStock, delivery) {
    let shop = {};
    for (let index = 0; index < currentStock.length; index+=2) {
        let product = currentStock[index];
        let quantity = Number(currentStock[index + 1]);
        shop[product] = quantity;
    }

    for (let index = 0; index < delivery.length; index+=2) {
        let product = delivery[index];
        let quantity = Number(delivery[index + 1]);
        if (!shop.hasOwnProperty(product)) {
           shop[product] = 0;
        }
        shop[product]+=quantity;
    }


    for (const key in shop) {
       console.log(`${key} -> ${shop[key]}`);
    }
}

solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
    );
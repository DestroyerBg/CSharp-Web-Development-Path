function solve(product, quantity) {
    let unitPrice = 0;
    if (product == 'coffee') {
        unitPrice = 1.50;
    }else if(product == 'water'){
        unitPrice = 1.00;
    }else if(product == 'coke'){
        unitPrice = 1.40;
    }else if(product == 'snacks'){
        unitPrice = 2.00;
    }

    function getPrice(unitPrice, quantity) {
        return unitPrice*quantity;
    }
    function printResult(finalPrice) {
        console.log(finalPrice.toFixed(2));
    }

   let finalPrice = getPrice(unitPrice,quantity);
   printResult(finalPrice);
}

solve("water", 5);
solve('coffee', 2);
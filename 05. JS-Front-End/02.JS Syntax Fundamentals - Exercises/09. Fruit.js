function calculatePriceForFruit(fruit, grams, pricePerKG) {
    grams = grams/1000;
    const price = grams * pricePerKG;
    console.log(`I need $${price.toFixed(2)} to buy ${grams.toFixed(2)} kilograms ${fruit}.`);
}

calculatePriceForFruit('orange', 2500, 1.80);
calculatePriceForFruit('apple', 1563, 2.35);
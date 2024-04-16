function calculatePrice(peopleCount, peopleType, dayOfWeek) {
    let price = 0;

    if (peopleType.toLowerCase() == 'students') {
        if (dayOfWeek.toLowerCase() == 'friday') {
            price = 8.45*peopleCount;
        }
        else if (dayOfWeek.toLowerCase() == 'saturday') {
            price = 9.80*peopleCount;
        }
        else if (dayOfWeek.toLowerCase() == 'sunday') {
            price = 10.46*peopleCount;
        }

        if (peopleCount >=30) {
            price-=price*0.15;
        }
    }

    else if (peopleType.toLowerCase() == 'business') {
        if (peopleCount >=100) {
            peopleCount-=10;
        }

        if (dayOfWeek.toLowerCase() == 'friday') {
            price = 10.90*peopleCount;
        }
        else if (dayOfWeek.toLowerCase() == 'saturday') {
            price = 15.60*peopleCount;
        }
        else if (dayOfWeek.toLowerCase() == 'sunday') {
            price = 16*peopleCount;
        }

        
    }

    else if (peopleType.toLowerCase() == 'regular') {
        if (dayOfWeek.toLowerCase() == 'friday') {
            price = 15*peopleCount;
        }
        else if (dayOfWeek.toLowerCase() == 'saturday') {
            price = 20*peopleCount;
        }
        else if (dayOfWeek.toLowerCase() == 'sunday') {
            price = 22.50*peopleCount;
        }

        if (peopleCount >= 10 && peopleCount <=20) {
            price-=price*0.05;
        }

    }

    console.log(`Total price: ${price.toFixed(2)}`);
}

calculatePrice(30,"Students","Sunday");

calculatePrice(40,"Regular","Saturday");




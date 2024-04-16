function calculatePromotion(dayOfWeek, age) {
    let price = 0;
    if (age >= 0 && age <= 18) {
        switch (dayOfWeek.toLowerCase()) {
            case 'weekday':
            price = 12;
            break;

            case 'weekend':
            price = 15;
            break;

            case 'holiday':
            price = 5;
            break;
            
            default:
                console.log(`Error`);
                return;
        }
    }

    else if (age > 18 && age <= 64) {
        switch (dayOfWeek.toLowerCase()) {
            case 'weekday':
            price = 18;
            break;

            case 'weekend':
            price = 20;
            break;

            case 'holiday':
            price = 12;
            break;
            
            default:
                console.log(`Error`);
                return;
        }
    }

    else if (age > 64 && age <= 122) {
        switch (dayOfWeek.toLowerCase()) {
            case 'weekday':
            price = 12;
            break;

            case 'weekend':
            price = 15;
            break;

            case 'holiday':
            price = 10;
            break;
            
            default:
                console.log('Error!');
                return;
        }
    }
    else{
        console.log('Error!');
        return;
    }

    console.log(`${price}$`);
}

calculatePromotion('Weekday', 42);
calculatePromotion('Holiday', -12);
calculatePromotion('Holiday', 15)
function calculateCircleArea(argument) {
    if (typeof(argument) == 'number' ){
        const area = Math.PI * Math.pow(argument,2);
        console.log(area.toFixed(2));
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${typeof(argument)}.`);
    }
}

calculateCircleArea(5);

calculateCircleArea('name');
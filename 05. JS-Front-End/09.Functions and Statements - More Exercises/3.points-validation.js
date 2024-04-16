function solve(points) {
    function validate(x1,y1,x2,y2) {
        let result = Math.sqrt((Math.pow(x2-x1,2) + (Math.pow(y2-y1,2))));
        if (result % 1 == 0) {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
        }else{
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
        }
    }
    validate(points[0],points[1],0,0);
    validate(points[2],points[3],0,0);
    validate(points[0],points[1],points[2],points[3]);
}

solve([3, 0, 0, 4]);
solve([2, 1, 1, 1]);
function solve(percent) {
    const percentDividedBy10 = (percent) => percent/10;
    function buildLoadingBar(points) {
        let arr = [];
        for (let index = 1; index <= points; index++) {
            arr.push('%');    
        }
        for (let index = points+1; index <= 10; index++) {
            arr.push('.');
        }
        return arr.join('');
    }

    function getState(points) {
        if (points == 10) {
            return 'Complete!'; 
        }
        return 'Still loading...';
    }

    function printResult(percentDivideBy10, state, loadingBarString) {
        if (state == 'Complete!') {
            console.log('100% Complete!');
            console.log(`[${loadingBarString}]`);
            return;
        }
        console.log(`${percentDivideBy10*10}% [${loadingBarString}]`);
        console.log(state);
    }

    printResult(percentDividedBy10(percent), getState(percentDividedBy10(percent)),buildLoadingBar(percentDividedBy10(percent)));
}

solve(30);
solve(50);
solve(100);
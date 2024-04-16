function solve(number) {
    function printCol(number) {
        for (let index = 1; index <= number; index++) {
           console.log(printRow(number));
        }
    }
    function printRow(number) {
       let row = [];
        for (let index = 1; index <= number; index++) {
           row.push(number);
        }
        return row.join(' ');
    }
    printCol(number);
}
solve(7);
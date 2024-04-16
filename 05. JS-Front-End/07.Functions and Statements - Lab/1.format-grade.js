function solve(grade) {
    function getDescription(grade) {
        let description = '';
        if (grade < 3) {
            description = 'Fail';
        }else if(grade >= 3 && grade < 3.50){
            description = 'Poor';
        }else if(grade >= 3.50 && grade < 4.50){
            description = 'Good';
        }else if(grade >= 4.50 && grade < 5.50){
            description = 'Very good';
        }else{
            description = 'Excellent';
        }
        return description;
    }
    function printResult(description, grade) {
        if (grade < 3) {
            console.log(`${description} (${2})`);
            return;
        }
        console.log(`${description} (${grade.toFixed(2)})`);
    }
    printResult(getDescription(grade),grade);
}
solve(3.33);
solve(4.50);
solve(2.99);
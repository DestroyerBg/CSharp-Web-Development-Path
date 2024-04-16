function solve(input) {
    class Grade{
        constructor(){
            this.studentsNames = [];
            this.studentsScores = [];
        }

        pushStudent(name,score){
            this.studentsNames.push(name);
            this.studentsScores.push(score);
        }
        getAverage(){
            return this.studentsScores.reduce((acc, curr) => acc + curr , 0) / this.studentsScores.length;
        }

    }
    const school = {};

    for (const line of input) {
        let tokens = line.split(', ');
        let name = tokens[0].split(': ')[1];
        let grade = Number(tokens[1].split(': ')[1]);
        let score = Number(tokens[2].split(': ')[1]);
        if (score >= 3) {
            if (!school.hasOwnProperty(grade+1)) {
                school[grade + 1] = new Grade();
            }
            school[grade + 1].pushStudent(name,score);
        }
    }

    let sorted = Array.from(Object.entries(school)).sort((a,b) => a - b);

    for (const grade of sorted) {
        console.log(`${grade[0]} Grade`);
        console.log(`List of students: ${grade[1].studentsNames.join(', ')}`);
        console.log(`Average annual score from last year: ${grade[1].getAverage().toFixed(2)}\n`);
    }
}

solve([
    "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
    "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
    "Student name: George, Grade: 8, Graduated with an average score: 2.83",
    "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
    "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
    "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
    "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
    "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
    "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
    "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
    "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
    "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"
]
);
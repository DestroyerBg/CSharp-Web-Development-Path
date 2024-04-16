function solve(input) {
    const meetings = {};
    for (let index = 0; index < input.length; index++) {
        let tokens = input[index].split(' ');
        let weekday = tokens[0];
        let name = tokens[1];
        if (meetings.hasOwnProperty(weekday)) {
            console.log(`Conflict on ${weekday}!`);
            continue;
        }
        meetings[weekday] = name;
        console.log(`Scheduled for ${weekday}`);   
    }

    for (const weekday in meetings) {
        console.log(`${weekday} -> ${meetings[weekday]}`);
    }
}

solve(['Monday Peter',
'Wednesday Bill',
'Monday Tim',
'Friday Tim']
);
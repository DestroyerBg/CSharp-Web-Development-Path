function solve(input) {
    class Leader{
        constructor(name){
            this.name = name;
            this.armies = {};
        }
        
        addArmy(armyName, count){
            this.armies[armyName] = count;
        }
        
        get totalArmiesCount(){
            let result = 0;
            for (const army in this.armies) {
                result+=this.armies[army];
            }
            return result;
        }
        addCountToArmy(armyName, count){
            if (this.armies.hasOwnProperty(armyName)) {
                this.armies[armyName]+=Number(count);
            }
        }
    }
    const leaders = [];
    for (const line of input) {
        if (line.includes('arrives')) {
            const tokens = line.split(' ');
            tokens.pop();
            const leaderName = tokens.join(' ');
            const leader = new Leader(leaderName);
            leaders.push(leader);
        }else if(line.includes(':')){
            const [leaderName, armiesInfo] = line.split(': ');
            const leader = leaders.find(f => f.name == leaderName);
            if (leader) {
                const tokens = armiesInfo.split(', ');
                const armyName = tokens[0];
                const armyCount = Number(tokens[1]);
                leader.addArmy(armyName,armyCount);
            }
        }else if(line.includes('+')){
            const tokens = line.split(' + ');
            const armyName = tokens[0];
            const armyCount = Number(tokens[1]);
            const leader = leaders.find(f => f.armies.hasOwnProperty(armyName));
            if (leader) {
                leader.addCountToArmy(armyName,armyCount);
            }
        }else if(line.includes('defeated')){
            const tokens = line.split(' ');
            tokens.pop();
            const leaderName = tokens.join(' ');
            const leader = leaders.find(f => f.name == leaderName);
            if (leader) {
                leaders.splice(leaders.indexOf(leader),1);
            }
        }
    }
    
    leaders.sort((a,b) => b.totalArmiesCount - a.totalArmiesCount);
    
    for (const leader of leaders) {
        console.log(`${leader.name}: ${leader.totalArmiesCount}`);
        const sortedArmy = Object.entries(leader.armies)
        .sort((a,b) => b[1] - a[1]);
        for (const army of sortedArmy) {
            console.log(`>>> ${army[0]} - ${army[1]}`);
        }
    }
    
}

solve(['Rick Burr arrives', 'Findlay arrives', 'Rick Burr: Juard, 1500', 'Wexamp arrives', 'Findlay: Wexamp, 34540', 'Wexamp + 340', 'Wexamp: Britox, 1155', 'Wexamp: Juard, 43423'])
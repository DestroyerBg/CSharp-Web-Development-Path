function solve(browserObject, input) {
    for (const line of input) {
        const [command, tabName] = line.split(' ');
        if (command == 'Close') {
            if (browserObject['Open Tabs'].includes(tabName)) {
                browserObject['Open Tabs'].splice( browserObject['Open Tabs'].indexOf(tabName), 1);
                browserObject['Recently Closed'].push(tabName);
                browserObject['Browser Logs'].push(line);
            }
        }else if(command == 'Open'){
            browserObject['Open Tabs'].push(tabName);
            browserObject['Browser Logs'].push(line);
        }else if(command == 'Clear'){
            browserObject['Open Tabs'] = [];
            browserObject['Recently Closed'] = [];
            browserObject['Browser Logs'] = [];
        }

    }

    console.log(`${browserObject['Browser Name']}`);
    console.log(`Open Tabs: ${browserObject['Open Tabs'].join(', ')}`);
    console.log(`Recently Closed: ${browserObject['Recently Closed'].join(', ')}`);
    console.log(`Browser Logs: ${browserObject['Browser Logs'].join(', ')}`);
}

solve({"Browser Name":"Mozilla Firefox",
"Open Tabs":["YouTube"],
"Recently Closed":["Gmail", "Dropbox"],
"Browser Logs":["Open Gmail", "Close Gmail", "Open Dropbox", "Open YouTube", "Close Dropbox"]},
["Open Wikipedia", "Clear History and Cache", "Open Twitter"]



);
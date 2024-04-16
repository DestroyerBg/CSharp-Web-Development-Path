function solve(listNames) {
    listNames.sort((a,b) => a.localeCompare(b));
    for (let index = 1; index <= listNames.length; index++) {
        console.log(`${index}.${listNames[index-1]}`);
    }
}
solve(["John", "Bob", "Christina", "Ema"]);
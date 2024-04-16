function solve(input) {
    function isArrayHere(collection, arr) {
       for (const element of collection) {
            if (JSON.stringify(element) === JSON.stringify(arr)) {
                return true;
            }
       }
       return false;
    }
    const collection = [];
    for (const line of input) {
        let arr = JSON.parse(line).sort((a,b) => b - a);
        if (!isArrayHere(collection,arr)) {
            collection.push(arr);
        }
    }

    collection.sort((a,b) => a.length - b.length).forEach(f => console.log(`[${f.join(', ')}]`));

}

solve(
    ["[-3, -2, -1, 0, 1, 2, 3, 4]",
    "[10, 1, -17, 0, 2, 13]",
    "[4, -3, 3, -2, 2, -1, 1, 0]"]
    


)
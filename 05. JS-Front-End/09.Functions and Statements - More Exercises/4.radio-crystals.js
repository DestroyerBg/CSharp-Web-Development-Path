function solve(chunks) {
    const operations = {
        Cut: (c) => c/4,
        Lap: (c) => c-= c*0.20,
        Grind: (c) => c-=20,
        Etch: (c) => c-=2,
        'X-ray': (c) => c++,
        'Transporting and washing': (c) => Math.floor(c), 
    };
    
    function getBestOperation(chunk) {
        let biggestDifference = Number.MIN_SAFE_INTEGER;
        let biggestOperation = undefined;
        for (const operation in operations) {
            let currOperation = operations[operation](chunk);
            let difference = chunk - currOperation;
            if (difference > biggestDifference && currOperation >= requiredSize - 1) {
                biggestDifference = difference;
                biggestOperation = operations[operation];
            }
        }
        let operationName = '';
        for (const key in operations) {
            if (operations[key] == biggestOperation) {
                operationName = key;
                break;
            }
       }
        
        return operationName;
        
    }
    let requiredSize = chunks[0];
    
    for (let index = 1; index < chunks.length; index++) {
        console.log(`Processing chunk ${chunks[index]} microns`);
        let currChunk = chunks[index];
        let xrayFlag = false;
        while (currChunk >= requiredSize - 1) {
            let operation = getBestOperation(currChunk);
            let count = 0;
            while (operations[operation](currChunk)>= requiredSize - 1) {
                count++;
                currChunk = operations[operation](currChunk);
                if (operation == 'X-ray') {
                    xrayFlag = true;
                    break;
                }
            }
           
            currChunk = operations['Transporting and washing'](currChunk);
            console.log(`${operation} x${count}`);
            if (operation != 'X-ray') {
                console.log('Transporting and washing');
            }
            if (currChunk == requiredSize) {
                break;
            }
           if (xrayFlag == true) {
                break;
           }
          
          
        }
        console.log(`Finished crystal ${requiredSize} microns`);
    }
}
// solve([1375, 50000]);
solve([1000, 4000, 8100]);
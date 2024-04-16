function solve(text) {
    const tracker = {};
    const searchWords = text[0].split(' ');
    const textToArr = text.slice(1);
    for (const word of searchWords) {
        tracker[word] = 0;
    }

    for (const word of textToArr) {
        if (tracker.hasOwnProperty(word)) {
            tracker[word]++;
        }
    }

    let sorted = Object.entries(tracker).sort((a,b) => b[1] - a[1])
    .forEach(w => console.log(`${w[0]} - ${w[1]}`));
   
}

solve(
    [
        'this sentence', 
        'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
        ]
        
    );
function solve(searchWord, text) {
    let textArr = text.split(' ');
    for (let index = 0; index < textArr.length; index++) {
        if (textArr[index].toLowerCase() === searchWord.toLowerCase()) {
            console.log(searchWord);
            return;
        }
    }
    console.log(`${searchWord} not found!`);
}

solve('javascript','JavaScript is the best programming language');
solve('python','JavaScript is the best programming language');

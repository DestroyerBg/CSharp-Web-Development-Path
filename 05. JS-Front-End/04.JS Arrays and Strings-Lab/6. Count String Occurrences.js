function solve(text,word) {
    let textArr = text.split(' ');
    let occurences = textArr.filter(w => w == word);
    console.log(occurences.length);    
}
solve('This is a word and it also is a sentence','is');
solve('softuni is great place for learning new programming languages','softuni');

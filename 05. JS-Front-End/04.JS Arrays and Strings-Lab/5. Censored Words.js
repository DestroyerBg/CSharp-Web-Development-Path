function solve(text, censorWord) {
    while (text.includes(censorWord)) {
        text = text.replace(censorWord,'*'.repeat(censorWord.length));
    }
    console.log(text);
}

solve('A small sentence with some words', 'small');
solve('Find the hidden word', 'hidden')
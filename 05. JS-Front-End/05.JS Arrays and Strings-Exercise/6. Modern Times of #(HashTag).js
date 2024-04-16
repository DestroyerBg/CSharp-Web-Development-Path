function solve(text) {
    let pattern = /#[a-zA-Z]+/g;
    let result = text.match(pattern);
    result.forEach(element => console.log(element.substring(1)));
}
solve('Nowadays everyone uses # to tag a #special word in #socialMedia');
solve('The symbol # is known #variously in English-speaking #regions as the #number sign');
solve('#number-!=.');
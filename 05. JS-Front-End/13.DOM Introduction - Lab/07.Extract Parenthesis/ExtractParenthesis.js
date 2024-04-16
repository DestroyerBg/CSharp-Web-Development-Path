function extract(content) {
    const element = document.getElementById(content).textContent;
    let regex = /\(([\w\s]+)\)/g;
    let result = [];
    let match;
    while ((match = regex.exec(element)) != null) {
        result.push(match[1]);
    }

    return result.join('; ')
}
   


let text = extract("content");
console.log(text);
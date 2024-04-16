function solve(words,text) {
    let textToArr = text.split(' ');
    let wordsToReplaceArr = words.split(', ');
    for (let index = 0; index < textToArr.length; index++) {
      let currWord = textToArr[index];
      if (currWord == '*'.repeat(currWord.length)) {
         text = text.replace(currWord, wordsToReplaceArr.find(word => word.length == currWord.length))
      }
   }

   console.log(text); 
    
}
solve('great','softuni is ***** place for learning new programming languages');
solve('great, learning','softuni is ***** place for ******** new programming languages');
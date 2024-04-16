function solve(length) {
    const letters = ['A:T','C:G','T:T','A:G','G:G']

    function printResult(firstCharacterIndex, secondCharacterIndex, firstCharacter, secondCharacter) {
        let result = [];
        for (let index = 0; index < 6; index++) {
            if (index < firstCharacterIndex || index > secondCharacterIndex) {
                result.push('*');
            }
            else{
                result.push('-');
            }
            if (index == firstCharacterIndex) {
                result[index] = firstCharacter;
            }
            else if (index == secondCharacterIndex){
                result[index] = secondCharacter;
            }
        }
        console.log(result.join(''));
}
    let forward = false;
    let charIndex = 0;
    let firstCharacterStartIndex = 2;
    let secondCharacterStartIndex = 3;
    for (let index = 0; index < length; index++) {
        let characters = letters[charIndex].split(':');
        printResult(firstCharacterStartIndex,secondCharacterStartIndex,characters[0],characters[1]);
        if (firstCharacterStartIndex == 0 && secondCharacterStartIndex == 5) {
            forward = true;
        }

        if (firstCharacterStartIndex == 2 && secondCharacterStartIndex == 3) {
            forward = false;
        }

        if (forward == true) {
            firstCharacterStartIndex++;
            secondCharacterStartIndex--;
        }
        else{
            firstCharacterStartIndex--;
            secondCharacterStartIndex++;
        }

        charIndex++;
        if (charIndex > letters.length - 1) {
            charIndex = 0;
        }

        
    }
}
// solve(4);
solve(10);
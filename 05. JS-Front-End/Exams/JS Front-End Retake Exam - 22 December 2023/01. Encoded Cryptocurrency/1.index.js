function solve(input) {
    let encodedMessage = input.shift();
    let currentLine = input.shift();
    while (currentLine != 'Buy') {
        if (currentLine == 'TakeEven') {
            let newMessage = [];
            for (let index = 0; index < encodedMessage.length; index++) {
                if (index % 2 == 0) {
                    newMessage.push(encodedMessage[index]);
                }
            }
            encodedMessage = newMessage.join('');
            console.log(encodedMessage);
        }else if(currentLine.includes('ChangeAll')){
            const tokens = currentLine.split('?');
            tokens.shift();
            const substring = tokens[0];
            const replace = tokens[1];
            while (encodedMessage.includes(substring)) {
                encodedMessage = encodedMessage.replace(substring,replace);
            }
            console.log(encodedMessage);
        }else if(currentLine.includes('Reverse')){
            const tokens = currentLine.split('?');
            tokens.shift();
            const substring = tokens[0];
            if (encodedMessage.includes(substring)) {

                let index = encodedMessage.indexOf(substring);
                let substringToReverse = encodedMessage.substring(index, index + substring.length);

                encodedMessage = encodedMessage.replace(substringToReverse,'');
                substringToReverse = substringToReverse.split('').reverse().join('');

                encodedMessage = encodedMessage + substringToReverse;
                console.log(encodedMessage);
            }else{
                console.log('error');
            }
        }

       

        currentLine = input.shift();
    }

    console.log(`The cryptocurrency is: ${encodedMessage}`);
}

solve((["PZDfA2PkAsakhnefZ7aZ", 
"TakeEven",
"TakeEven",
"TakeEven",
"ChangeAll?Z?X",
"ChangeAll?A?R",
"Reverse?PRX",
"Buy"])

);

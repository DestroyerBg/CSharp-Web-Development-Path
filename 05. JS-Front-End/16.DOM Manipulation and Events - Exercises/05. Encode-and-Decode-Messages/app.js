function encodeAndDecodeMessages() {
    const [writeMessageArea, receivedMessagesArea] = document.getElementsByTagName('textarea');
    const [encodeButton,decodeButton] = document.getElementsByTagName('button');

    let result = '';

    encodeButton.addEventListener('click', (e) => {
        const sentence = writeMessageArea.value;
        let newMessage = '';
        for (let i = 0; i < sentence.length; i++) {
            const currChar = sentence.charCodeAt(i);
            const newChar = String.fromCharCode(currChar + 1);
            newMessage+=newChar;
        }
        result = newMessage;
        writeMessageArea.value = '';
        receivedMessagesArea.value = result;
    })

    decodeButton.addEventListener('click', (e) => {
        const sentence = receivedMessagesArea.value;
        let newMessage = '';
        for (let i = 0; i < sentence.length; i++) {
            const currChar = sentence.charCodeAt(i);
            const newChar = String.fromCharCode(currChar - 1);
            newMessage+=newChar;
        }
        result = newMessage;
        receivedMessagesArea.value = '';
        receivedMessagesArea.value = result;
    })

    
}
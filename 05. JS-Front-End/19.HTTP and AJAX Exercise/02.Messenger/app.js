function attachEvents() {
    const requestUrl = 'http://localhost:3030/jsonstore/messenger';

    const messagesArea = document.getElementById('messages');
    const authorInput = document.querySelectorAll('input[type = text]')[0];
    const messageInput = document.querySelectorAll('input[type = text]')[1];
    const sendButton = document.getElementById('submit');
    const refreshButton = document.getElementById('refresh');

    sendButton.addEventListener('click', async(e) => {
        const message = {
            author: authorInput.value,
            content: messageInput.value,
        }
        const options = {
            method: 'POST',
            headers:{
                'Content-Type':'application/json'
            },
            body: JSON.stringify(message),
        }
        const response = await fetch(requestUrl,options);
        console.log(response.status);
    })

    refreshButton.addEventListener('click', async(e) => {
        authorInput.value = '';
        messageInput.value = '';
        messagesArea.value = '';
        const messages = [];
        const response = await fetch(requestUrl);
        const data = await response.json();
        for (const value of Object.values(data)) {
            messages.push(`${value.author}: ${value.content}`)
        }
        messagesArea.value = messages.join('\n');
    })
}

attachEvents();
const url = 'http://localhost:3030/jsonstore/gifts';
const loadPresentsButton = document.getElementById('load-presents');
const addPresentsButton = document.getElementById('add-present');
const editPresentsButton = document.getElementById('edit-present');
const giftList = document.getElementById('gift-list');
const giftInput = document.getElementById('gift');
const forInput = document.getElementById('for');
const priceInput = document.getElementById('price');

loadPresentsButton.addEventListener('click', () => {
    loadPosts();
})

addPresentsButton.addEventListener('click', () => {
    const gift = giftInput.value;
    const giftFor = forInput.value;
    const price = priceInput.value;

    const newPresent = {
        gift,
        for: giftFor,
        price,
    }

    fetch(url,{
        method: 'POST',
        headers:{
            'content-type': 'application/json',
        },
        body: JSON.stringify(newPresent),
    })
    .then(res => {
        if (res.ok) {
            loadPosts();
            giftInput.value = '';
            forInput.value = '';
            priceInput.value = '';
        }
    })
    
})

function createElement(present) {
    const gift = document.createElement('div');
    gift.classList.add('gift-sock');

    const divGiftSock = document.createElement('div');
    divGiftSock.classList.add('content');

    const giftParagraph = document.createElement('p');
    giftParagraph.textContent = present.gift;

    const giftFor = document.createElement('p');
    giftFor.textContent = present.for;

    const giftPrice = document.createElement('p');
    giftPrice.textContent = present.price;

    divGiftSock.appendChild(giftParagraph);
    divGiftSock.appendChild(giftFor);
    divGiftSock.appendChild(giftPrice);

    const divButtons = document.createElement('div');
    divButtons.classList.add('buttons-container');

    const buttonChange = document.createElement('button');
    buttonChange.classList.add('change-btn');
    buttonChange.textContent = 'Change';

    const buttonDelete = document.createElement('button');
    buttonDelete.classList.add('delete-btn');
    buttonDelete.textContent = 'Delete';

    divButtons.appendChild(buttonChange);
    divButtons.appendChild(buttonDelete);

    gift.appendChild(divGiftSock);
    gift.appendChild(divButtons);

    buttonChange.addEventListener('click', () => {
            gift.remove();

            giftInput.value =  giftParagraph.textContent;
            forInput.value = giftFor.textContent;
            priceInput.value = giftPrice.textContent;

            addPresentsButton.disabled = true;
            editPresentsButton.disabled = false;

            editPresentsButton.addEventListener('click', () => {
                fetch(`${url}/${present._id}`,{
                    method:'PUT',
                    headers: {
                        'content-type': 'application/json',
                    },
                    body: JSON.stringify({
                        gift:  giftInput.value,
                        for: forInput.value,
                        price: priceInput.value,
                    })
                })
                .then(res => {
                    if (res.ok) {
                        giftInput.value = '';
                        forInput.value = '';
                        priceInput.value = '';
                        addPresentsButton.disabled = false;
                        editPresentsButton.disabled = true;
                        loadPosts();
                    }
                })
            });


            
    })

    buttonDelete.addEventListener('click', () => {
        fetch(`${url}/${present._id}`,{
            method: 'DELETE',
        })
        .then(res => {
            if (res.ok) {
                gift.remove();
                loadPosts();
            }
        })

    })

    giftList.appendChild(gift);

}

function loadPosts() {
    giftList.innerHTML = '';
    fetch(url)
    .then(res => res.json())
    .then(presents => {
        Object.values(presents)
        .forEach(present => {
            createElement(present);
        })
    })
    
}
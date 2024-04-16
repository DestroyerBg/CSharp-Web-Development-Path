function attachEvents() {
    const getAndPostUrl = 'http://localhost:3030/jsonstore/phonebook';
    const deleteUrl = 'http://localhost:3030/jsonstore/phonebook';

    const phonebook = document.getElementById('phonebook');

    const loadButton = document.getElementById('btnLoad');
    const createButton = document.getElementById('btnCreate');

    loadButton.addEventListener('click', () => {
        fetch(getAndPostUrl)
        .then(res => res.json())
        .then(data => {
            const phones = Object.values(data);
            phonebook.innerHTML = '';
            for (const phone of phones) {
                phonebook.appendChild(createElement(phone.person, phone.phone,phone._id));
            }
        })
    })

    // create contact
    createButton.addEventListener('click', async() =>{
        const personNameInput = document.getElementById('person');
        const personTelephoneInput = document.getElementById('phone');

        const newEntry = {
            person: personNameInput.value,
            phone: personTelephoneInput.value,
        }

        const response = await fetch(getAndPostUrl,{
            method: 'POST',
            headers:{
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(newEntry),
            
        });
        if (response.ok) {
            personNameInput.value = '';
            personTelephoneInput.value = '';

            const reloadPhoneBookResponse = await fetch(getAndPostUrl);
            const reloadMessagesData = await reloadPhoneBookResponse.json();
            phonebook.innerHTML = '';
            for (const phone of Object.values(reloadMessagesData)) {
                phonebook.appendChild(createElement(phone.person,phone.phone));
            }
        }
    })

    function createElement(name, phone, id) {
        //create li element
        const liElement = document.createElement('li');
        liElement.textContent = `${name}: ${phone}`;

        // create delete button
        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.value = id;
        //delete button function
        deleteButton.addEventListener('click',async() => {
            const getPhoneKey = id;
            const deleteResponse = await fetch(`${deleteUrl}/${getPhoneKey}`,{
                method: 'DELETE',
            });
            if (deleteResponse.ok) {
                phonebook.removeChild(liElement);
            }
        })
        // append contacts after we got the data from the server
        liElement.appendChild(deleteButton);
        return liElement;
    }

}

attachEvents();
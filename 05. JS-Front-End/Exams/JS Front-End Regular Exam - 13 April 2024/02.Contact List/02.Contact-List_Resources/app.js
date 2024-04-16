window.addEventListener("load", solve);

function solve() {
    const addButton = document.getElementById('add-btn');
    const checkList = document.getElementById('check-list');
    const nameInput = document.getElementById('name');
    const phoneInput = document.getElementById('phone');
    const selectMenu = document.getElementById('category');
    const contactList = document.getElementById('contact-list');
    
    addButton.addEventListener('click', () => {
        const name = nameInput.value;
        const phone = phoneInput.value;
        const selectedIndex = selectMenu.selectedIndex;
        const category = selectMenu.options[selectedIndex].value;
        
        if (!name || !phone || !category) {
            return;
        }
        
        const element = createElement(name, phone, category);
        
        nameInput.value = '';
        phoneInput.value = '';
        selectMenu.value = '';
    })
    
    
    function createElement(name, phone, category) {
        const li = document.createElement('li');
        
        const article = document.createElement('article');
        
        const paragraphName = document.createElement('p');
        paragraphName.textContent = `name:${name}`;
        
        const paragraphPhone = document.createElement('p');
        paragraphPhone.textContent = `phone:${phone}`;
        
        const paragraphCategory = document.createElement('p');
        paragraphCategory.textContent = `category:${category}`;
        
        article.appendChild(paragraphName);
        article.appendChild(paragraphPhone);
        article.appendChild(paragraphCategory);
        
        li.appendChild(article);
        
        const buttonsDiv = document.createElement('div');
        buttonsDiv.classList.add('buttons');
        
        const editButton = document.createElement('button');
        editButton.classList.add('edit-btn');
        
        const saveButton = document.createElement('button');
        saveButton.classList.add('save-btn');
        
        buttonsDiv.appendChild(editButton);
        buttonsDiv.appendChild(saveButton);
        
        li.appendChild(buttonsDiv);
        
        
        editButton.addEventListener('click', () => {
            nameInput.value = name;
            phoneInput.value = phone;
            selectMenu.value = category;
            li.remove();
        });

        saveButton.addEventListener('click', () => {
            li.remove();
            li.querySelector('.buttons').remove();
            const deleteButton = document.createElement('button');
            deleteButton.classList.add('del-btn');
            li.appendChild(deleteButton);
            contactList.appendChild(li);

            deleteButton.addEventListener('click', () =>{
                li.remove();
            })
        })

        
        checkList.appendChild(li);
    }
}




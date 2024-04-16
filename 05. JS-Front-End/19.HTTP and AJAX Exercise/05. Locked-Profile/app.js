function lockedProfile() {
    const url = 'http://localhost:3030/jsonstore/advanced/profiles';

    const main = document.getElementById('main');
    fetch(url)
    .then(res => res.json())
    .then(data => {
        const profiles = Object.values(data);
        let userCounter = 0;
        for (const profile of profiles) {
            userCounter++;
            main.appendChild(createElement(profile.username, profile.email, profile.age,userCounter));

        }
    })

    function createElement(username, email, age, userCounter) {
        // create image element
        const img = document.createElement('img');
        img.src = './iconProfile2.png';
        img.classList.add('userIcon');

        // create label lock
        const lockLabel = document.createElement('label');
        lockLabel.textContent = 'Lock';

        // create lock input

        const lockInput = document.createElement('input');
        lockInput.type = 'radio';
        lockInput.name = `user${userCounter}Locked`;
        lockInput.value = 'lock';
        lockInput.defaultChecked = true;

        // create label unlock
        const unlockLabel = document.createElement('label');
        unlockLabel.textContent = 'Unlock';

        // create unlock input 
        const unlockInput = document.createElement('input');
        unlockInput.type = 'radio';
        unlockInput.name = `user${userCounter}Locked`;
        unlockInput.value = 'unlock';

        // create br 
        const br = document.createElement('br');

        // create hr
        const hr = document.createElement('hr');

        // create username label
        const usernameLabel = document.createElement('label');
        usernameLabel.textContent = 'Username';

        // create userName input 
        const usernameInput = document.createElement('input');
        usernameInput.type = 'text';
        usernameInput.name = `user${userCounter}Username`;
        usernameInput.value = username;
        usernameInput.disabled = true;
        usernameInput.readOnly = true;

        // create hiddenDiv hr
        const hiddenHr = document.createElement('hr');

        // create hiddenEmailLabel
        const emailLabel = document.createElement('label');
        emailLabel.textContent = 'Email:';

        // create input for email 
        const emailInput = document.createElement('input');
        emailInput.type = 'email';
        emailInput.name = `user${userCounter}Email`;
        emailInput.value = email;
        emailInput.disabled = true;
        emailInput.readOnly = true;

        // create hidenAgeLabel 
        const ageLabel = document.createElement('label');
        ageLabel.textContent = 'Age:';

        // create input for age 

        const ageInput = document.createElement('input');
        ageInput.type = 'email';
        ageInput.name = `user${userCounter}Age`;
        ageInput.value = age;
        ageInput.disabled = true;
        ageInput.readOnly = true;

        // create hidden info div

        const hiddenInfoDiv = document.createElement('div');
        hiddenInfoDiv.id = `user${userCounter}HiddenFields`;
        hiddenInfoDiv.style.display = 'none';
        hiddenInfoDiv.appendChild(hiddenHr);
        hiddenInfoDiv.appendChild(emailLabel);
        hiddenInfoDiv.appendChild(emailInput);
        hiddenInfoDiv.appendChild(ageLabel);
        hiddenInfoDiv.appendChild(ageInput);

        // create show more button 

        const button = document.createElement('button');
        button.textContent = 'Show more';

        button.addEventListener('click', () => {
            if (unlockInput.checked) {
                switch (button.textContent) {
                    case 'Show more':
                        button.textContent = 'Hide it';
                        hiddenInfoDiv.style.display = 'block';
                        break;
                        case 'Hide it':
                            button.textContent = 'Show more';
                            hiddenInfoDiv.style.display = 'none';
                            break;
                    default:
                        break;
                }
                
            }
        })

        // create whole profile card 
        const profile = document.createElement('profile');
        profile.classList.add('profile');
        profile.appendChild(img);
        profile.appendChild(lockLabel);
        profile.appendChild(lockInput);
        profile.appendChild(unlockLabel);
        profile.appendChild(unlockInput);
        profile.appendChild(br);
        profile.appendChild(hr);
        profile.appendChild(usernameLabel);
        profile.appendChild(usernameInput);
        profile.appendChild(hiddenInfoDiv);
        profile.appendChild(button);

        return profile;


    }
}
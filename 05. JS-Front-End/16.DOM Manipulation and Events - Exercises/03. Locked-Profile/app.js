function lockedProfile() {
    const allProfiles = Array.from(document.querySelectorAll('div.profile'));

    for (const profile of allProfiles) {
        const button = profile.querySelector('button');
        const unlock = profile.querySelector('input[value = unlock]');
        button.addEventListener('click', (e) => {
            if (unlock.checked) {
                switch (button.textContent) {
                    case 'Show more':
                        profile.querySelector('div').style.display = 'block';
                        button.textContent = 'Hide it';
                        break;
                    case 'Hide it':
                    profile.querySelector('div').style.display = 'none';
                    button.textContent = 'Show more';
                    break;

                    default:
                        break;
                }
            }
        })
    }
}
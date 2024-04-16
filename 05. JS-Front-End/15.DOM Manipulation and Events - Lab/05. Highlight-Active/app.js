function focused() {
    const sections = document.querySelectorAll('input[type = text]');

    Array.from(sections).forEach(s => {
        s.addEventListener('focus', (event) => {
          event.target.parentElement.classList.add('focused');
        });
    });

    Array.from(sections).forEach(s => {
        s.addEventListener('blur', (event) => {
            event.target.parentElement.classList.remove('focused');
        });
    });

}
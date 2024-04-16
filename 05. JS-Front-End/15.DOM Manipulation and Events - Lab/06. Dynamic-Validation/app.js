function validate() {
    const input = document.getElementById('email');

    input.addEventListener('change', (event) => {
        const pattern = /[a-z]+\@[a-z]+\.[a-z]+/gm;
        if (!pattern.test(input.value)) {
            event.target.classList.add('error');
        }else{
            event.target.classList.remove('error');
        }
    })
}
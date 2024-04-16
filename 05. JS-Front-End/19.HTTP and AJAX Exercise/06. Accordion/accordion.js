function solution() {
    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const contentUrl = 'http://localhost:3030/jsonstore/advanced/articles/details';
    const main = document.getElementById('main');
    fetch(url)
    .then(res => res.json())
    .then(data => {
        const articles = Object.values(data);
        const allElements = [];
        for (const article of articles) {
            allElements.push(createElement(article.title, article._id));
        }

        allElements.forEach(element => main.appendChild(element));
    })

    function createElement(title,id) {
        const htmlTemplate = `<div class="accordion">
        <div class="head">
            <span>${title}</span>
            <button class="button" id="ee9823ab-c3e8-4a14-b998-8c22ec246bd3">More</button>
        </div>
        <div class="extra">
            <p></p>
        </div>
        </div>`
        const div = document.createElement('div');
        div.innerHTML = htmlTemplate;
        const paragraph = div.querySelector('p');
        const extra = div.querySelector('.extra');
         fetch(`${contentUrl}/${id}`)
         .then(res => res.json())
         .then(data => {
            paragraph.textContent = data.content;
         });
        const button = div.querySelector('button');
        button.addEventListener('click', () => {
            if (button.textContent == 'More') {
                button.textContent = 'Less';
                extra.style.display = 'block'
            }else {
                button.textContent = 'More';
                extra.style.display = 'none'
            }
        })
        
        return div;
    }
}

solution();



window.addEventListener("load", solve);

function solve() {
    const addButton = document.getElementById('add-btn');
    const playerNameInput = document.getElementById('player');
    const scoreInput = document.getElementById('score');
    const roundInput = document.getElementById('round');
    const sureListUl = document.getElementById('sure-list');
    const scoreboard = document.getElementById
    ('scoreboard-list');
    const clearButton = document.querySelector('.clear');

    addButton.addEventListener('click', () => {
        const playerName = playerNameInput.value;
        const score = scoreInput.value;
        const round = roundInput.value;
        
        if (!playerName || !score || !round ) {
            return;
        }
        addButton.disabled = true;
        playerNameInput.value = '';
        scoreInput.value = '';
        roundInput.value = '';
        const element = createElement(playerName, score, round);
        sureListUl.appendChild(element);
    });

    clearButton.addEventListener('click', () => {
        sureListUl.innerHTML = '';
        scoreboard.innerHTML = '';
        addButton.disabled = false;
        playerNameInput.value = '';
        scoreInput.value = '';
        roundInput.value = '';
    })
    
    function createElement(playerName, score, round) {
        const li = document.createElement('li');
        li.classList.add('dart-item');
        
        const article = document.createElement('article');
        
        const nameParagraph = document.createElement('p');
        nameParagraph.textContent = playerName;
        
        const scoreParagraph = document.createElement('p');
        scoreParagraph.textContent = `Score: ${score}`;
        
        const roundParagraph = document.createElement('p');
        roundParagraph.textContent = `Round: ${round}`;
        
        article.appendChild(nameParagraph);
        article.appendChild(scoreParagraph);
        article.appendChild(roundParagraph);
        
        const editButton = document.createElement('button');
        editButton.classList.add('btn');
        editButton.classList.add('edit');
        editButton.textContent = 'edit';
        
        const okButton = document.createElement('button');
        okButton.classList.add('btn');
        okButton.classList.add('ok');
        okButton.textContent = 'ok';
        
        li.appendChild(article);
        li.appendChild(editButton);
        li.appendChild(okButton);
        
        
        editButton.addEventListener('click', () => {

            playerNameInput.value = playerName;
            scoreInput.value =  score;
            roundInput.value = round;
            
            addButton.disabled = false;
            li.remove();
        });

        okButton.addEventListener('click', () => {
            li.remove();
            li.querySelector('.edit').remove();
            li.querySelector('.ok').remove();
            scoreboard.appendChild(li);
            addButton.disabled = false;
        })
        
        return li;
    }
}

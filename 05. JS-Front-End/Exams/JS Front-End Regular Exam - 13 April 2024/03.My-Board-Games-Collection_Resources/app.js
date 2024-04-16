const url = 'http://localhost:3030/jsonstore/games';

const loadGameButton = document.getElementById('load-games');
const gamesList = document.getElementById('games-list');
const addGameButton = document.getElementById('add-game');
const editGameButton = document.getElementById('edit-game');
const gameNameInput = document.getElementById('g-name');
const gameTypeInput = document.getElementById('type');
const maxPlayerInput = document.getElementById('players');
loadGameButton.addEventListener('click', () => {
    loadData();
})

addGameButton.addEventListener('click', () => {
    const name = gameNameInput.value;
    const type = gameTypeInput.value;
    const players = maxPlayerInput.value;
    
    const newGame = {
        name,
        type,
        players,
    }
    
    fetch(url,{
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify(newGame),
    })
    .then(res => {
        if (res.ok) {
            clearInputData();
            loadData();
        }
    })
})

function loadData() {
    gamesList.innerHTML = '';
    fetch(url)
    .then(res => res.json())
    .then(data => {
        const games = Object.values(data);
        for (const game of games) {
            createElement(game);
        }
    })
}

function createElement(game) {
    const div = document.createElement('div');
    div.classList.add('board-game');
    
    const contentDiv = document.createElement('div');
    contentDiv.classList.add('content');
    
    const gameParagraph = document.createElement('p');
    gameParagraph.textContent = game.name;
    
    const gamePlayersParagraph = document.createElement('p');
    gamePlayersParagraph.textContent = game.players;
    
    const gameTypeParagraph = document.createElement('p');
    gameTypeParagraph.textContent = game.type;
    
    contentDiv.appendChild(gameParagraph);
    contentDiv.appendChild(gamePlayersParagraph);
    contentDiv.appendChild(gameTypeParagraph);
    
    div.appendChild(contentDiv);
    
    const buttonsDiv = document.createElement('div');
    buttonsDiv.classList.add('buttons-container');
    
    const changeButton = document.createElement('button');
    changeButton.classList.add('change-btn');
    changeButton.textContent = 'Change';
    
    const deleteButton = document.createElement('button');
    deleteButton.classList.add('delete-btn');
    deleteButton.textContent = 'Delete';
    
    buttonsDiv.appendChild(changeButton);
    buttonsDiv.appendChild(deleteButton);
    
    div.appendChild(buttonsDiv);
    
    changeButton.addEventListener('click', () => {
        gameNameInput.value = game.name;
        gameTypeInput.value = game.type;
        maxPlayerInput.value = game.players;
        div.remove();
        addGameButton.disabled = true;
        editGameButton.disabled = false;
        
        editGameButton.addEventListener('click', () => {
            const name = gameNameInput.value;
            const type = gameTypeInput.value;
            const players = maxPlayerInput.value;
            
            const newGame = {
                name,
                type,
                players,
                _id: game._id,
            }

            fetch(`${url}/${game._id}`,{
                method: 'PUT',
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify(newGame),
            })
            .then(res => {
                if (res.ok) {
                    clearInputData();
                    loadData();
                    addGameButton.disabled = false;
                    editGameButton.disabled = true;
                }
            })
        })

        deleteButton.addEventListener('click', () => {
            fetch()
        })
    })
    
    deleteButton.addEventListener('click', () => {
        fetch(`${url}/${game._id}`,{
            method: 'DELETE',
        })
        .then(res => {
            if (res.ok) {
                loadData();
            }
        })
    })
    gamesList.appendChild(div);
}

function clearInputData() {
    gameNameInput.value = '';
    gameTypeInput.value = '';
    maxPlayerInput.value = '';
}
console.log('//TODO...');
const baseUrl = 'http://localhost:3030/jsonstore/games';

const btnLoadGamesElement = document.getElementById('load-games');//
const btnEditGameElement = document.getElementById('edit-game');//
const btnAddGameElement = document.getElementById('add-game');//

const divGamesListElement = document.getElementById('games-list');//
const inputNameElement = document.getElementById('g-name');//
const inputTypeElement = document.getElementById('type');//
const inputMaxPlayersElement = document.getElementById('players');//

let selectedTaskId = null;

function createGame(game) {
    // TODO: Create a list of players with name, steps, and calories from the provided array
    // Each player should be added to the <ul> with id="list"
    const divBoardGameElement = document.createElement('div');
    divBoardGameElement.setAttribute('class', 'board-game');

    const divContentElement = document.createElement('div');
    divContentElement.setAttribute('class', 'content');

    const p1Element = document.createElement('p');
    p1Element.textContent = game.name;
    const p2Element = document.createElement('p');
    p2Element.textContent = game.players;
    const p3Element = document.createElement('p');
    p3Element.textContent = game.type;

    divContentElement.appendChild(p1Element);
    divContentElement.appendChild(p2Element);
    divContentElement.appendChild(p3Element);
    divBoardGameElement.appendChild(divContentElement);

    const divBtnContainerElement = document.createElement('div');
    divBtnContainerElement.setAttribute('class', 'buttons-container');

    const btnChangeElement = document.createElement('button');
    btnChangeElement.setAttribute('class', 'change-btn');
    btnChangeElement.textContent = 'Change';
    btnChangeElement.addEventListener('click', () => {
        // [Change Record] button should enable the [Edit Record] button
        // and display the current player's details in the input fields
        fnActivatedEditDeactivatedAddButtons();
        inputNameElement.value = game.name;
        inputTypeElement.value = game.type;
        inputMaxPlayersElement.value = game.players;
        selectedTaskId = game._id;
    });

    const btnDeleteElement = document.createElement('button');
    btnDeleteElement.setAttribute('class', 'delete-btn');
    btnDeleteElement.textContent = 'Delete';
    btnDeleteElement.addEventListener('click', () => {
        // [Delete Record] button should send a DELETE request to the server to remove the selected player
        // After you've removed it successfully, fetch the Records again. -> fnLoadRecord();
        selectedTaskId = game._id;
        fetch(`${baseUrl}/${selectedTaskId}`, { method: 'DELETE' })
            .then(response => {
                if (response.ok) {
                    selectedTaskId = null;
                    fnClearListElement();
                    fnLoadGames();
                }
            })
            .catch(err => console.log(err.message));
    });

    divBtnContainerElement.appendChild(btnChangeElement);
    divBtnContainerElement.appendChild(btnDeleteElement);
    divBoardGameElement.appendChild(divBtnContainerElement);

    return divBoardGameElement;
}

function fnLoadGames() {
    // TODO: send a GET request to the server to fetch all records from your local database
    // You must add each task to the <ul> with id="list"
    // [Edit Record] button should be deactivated

    fetch(baseUrl)
        .then(response => response.json())
        .then(data => {
            fnClearListElement();
            fnClearInputs();
            fnDeactivatedEditActivatedAddButtons();
            Object.values(data).forEach(game => {
                divGamesListElement.appendChild(createGame(game));
            });
            fnDeactivatedEditActivatedAddButtons();
        })
        .catch(err => console.log(err.message));

}
function fnAddGame() {
    // TODO: send a POST request to the server, creating a new Record record with the Name, Steps and Calories from the input values
    // send another GET request to fetch all the records including the newly added one
    // clear all the input fields after the creation

    const gameName = inputNameElement.value;
    const gameType = inputTypeElement.value;
    const gameMaxPlayers = inputMaxPlayersElement.value;

    if (!gameName || !gameType || !gameMaxPlayers) {
        return;
    }

    const sendData = {
        name: gameName,
        type: gameType,
        players: gameMaxPlayers
    }

    fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(sendData)
    })
        .then(response => {
            if (response.ok) {
                fnLoadGames();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));

}

function fnEditGame(e) {
    // TODO: [Change] button  ???
    e.preventDefault();
    const EditedData = {
        name: inputNameElement.value,
        type: inputTypeElement.value,
        players: inputMaxPlayersElement.value,
        _id: selectedTaskId,
    };

    fetch(`${baseUrl}/${selectedTaskId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(EditedData),
    })
        .then(response => {
            if (response.ok) {
                selectedTaskId = null;
                fnClearListElement();
                fnLoadGames();
                fnDeactivatedEditActivatedAddButtons();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));
}


function attachEvents() {
    btnLoadGamesElement.addEventListener('click', fnLoadGames);
    btnEditGameElement.addEventListener('click', fnEditGame);
    btnAddGameElement.addEventListener('click', fnAddGame);
}

function fnClearInputs() {
    inputNameElement.value = '';
    inputTypeElement.value = '';
    inputMaxPlayersElement.value = '';
}

function fnClearListElement() {
    divGamesListElement.innerHTML = '';
}

function fnDeactivatedEditActivatedAddButtons() {
    btnEditGameElement.disabled = true;
    btnAddGameElement.disabled = false;
}

function fnActivatedEditDeactivatedAddButtons() {
    btnEditGameElement.disabled = false;
    btnAddGameElement.disabled = true;
}

attachEvents();

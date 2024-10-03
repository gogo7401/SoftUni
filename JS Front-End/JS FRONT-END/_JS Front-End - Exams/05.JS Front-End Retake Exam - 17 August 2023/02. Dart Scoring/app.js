window.addEventListener("load", solve);

function solve() {
    // console.log('//TODO');

    const formElement = document.querySelector('form');
    const inputNameElement = document.getElementById('player');
    const inputScoreElement = document.getElementById('score');
    const inputRoundElement = document.getElementById('round');
    const btnAddElement = document.getElementById('add-btn');
    const btnClearElement = document.querySelector('#players-container > div > div > button');

    const ulSureListElement = document.getElementById('sure-list');
    const ulScoreboardListElement = document.getElementById('scoreboard-list');


    function addPlayerToLists(playerName, playerScore, roundNumber) {
        // TODO: 

        // Create player elements
        const liPlayerElement = document.createElement('li');
        liPlayerElement.setAttribute('class', 'dart-item');

        const articleElement = document.createElement('article');

        const p1Element = document.createElement('p');
        p1Element.textContent = playerName;
        const p2Element = document.createElement('p');
        p2Element.textContent = `Score: ${playerScore}`;
        const p3Element = document.createElement('p');
        p3Element.textContent = `Round: ${roundNumber}`;

        articleElement.appendChild(p1Element);
        articleElement.appendChild(p2Element);
        articleElement.appendChild(p3Element);
        liPlayerElement.appendChild(articleElement);

        const btnEditElement = document.createElement('button');
        btnEditElement.setAttribute('class', 'btn edit');
        btnEditElement.textContent = 'edit';
        btnEditElement.addEventListener('click', () => {
            // TODO: Implement edit functionality
            inputNameElement.value = p1Element.textContent;
            inputScoreElement.value = p2Element.textContent.split(': ')[1];
            inputRoundElement.value = p3Element.textContent.split(': ')[1];

            liPlayerElement.remove();

            btnAddElement.disabled = false;
        });

        const btnOkElement = document.createElement('button');
        btnOkElement.setAttribute('class', 'btn ok');
        btnOkElement.textContent = 'ok';
        btnOkElement.addEventListener('click', () => {
            // TODO: Implement ok functionality

            liPlayerElement.removeChild(btnEditElement);
            liPlayerElement.removeChild(btnOkElement);

            ulScoreboardListElement.appendChild(liPlayerElement);

            btnAddElement.disabled = false;
        });

        liPlayerElement.appendChild(btnEditElement);
        liPlayerElement.appendChild(btnOkElement);

        return liPlayerElement;
    }

    function fnAddElement() {
        const playerName = inputNameElement.value;
        const playerScore = Number(inputScoreElement.value);
        const roundNumber = Number(inputRoundElement.value);

        if ((inputNameElement.value === '') || (inputScoreElement.value === '')|| (inputRoundElement.value === '')){
            return;
        }

        ulSureListElement.appendChild(addPlayerToLists(playerName, playerScore, roundNumber));
        fnClearInputs();
        btnAddElement.disabled = true;
    }

    function fnClearInputs() {
        inputNameElement.value = '';
        inputScoreElement.value = '';
        inputRoundElement.value = '';
    }

    function fnClearElements() {
        location.reload();
    }

    function addButtonsEventListener() {
        btnAddElement.addEventListener('click', fnAddElement);
        btnClearElement.addEventListener('click', fnClearElements);
    }

    addButtonsEventListener();
}

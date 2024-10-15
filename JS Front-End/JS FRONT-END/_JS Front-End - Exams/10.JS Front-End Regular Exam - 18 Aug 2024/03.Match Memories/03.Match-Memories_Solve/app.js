console.log('//TODO...');
const baseUrl = 'http://localhost:3030/jsonstore/matches';

const btnLoadElement = document.getElementById('load-matches');
const btnAddElement = document.getElementById('add-match');
const btnEditElement = document.getElementById('edit-match');

const ulListElement = document.getElementById('list');
const inputHostElement = document.getElementById('host');
const inputScoreElement = document.getElementById('score');
const inputGuestElement = document.getElementById('guest');

let selectedTaskId = null;


function createSubItem(itemData) {
    // TODO: Create a list of players with name, steps, and calories from the provided array
    // Each player should be added to the <ul> with id="list"
    const liElement = document.createElement('li');
    liElement.setAttribute('class', 'match');
    
    const divInfoElement = document.createElement('div');
    divInfoElement.setAttribute('class', 'info');
    liElement.appendChild(divInfoElement);

    const p1Element = document.createElement('p');
    p1Element.textContent = itemData.host;
    divInfoElement.appendChild(p1Element);

    const p2Element = document.createElement('p');
    p2Element.textContent = itemData.score;
    divInfoElement.appendChild(p2Element);
    
    const p3Element = document.createElement('p');
    p3Element.textContent = itemData.guest;
    divInfoElement.appendChild(p3Element);

    const divBtnWrapperElement = document.createElement('div');
    divBtnWrapperElement.setAttribute('class', 'btn-wrapper');
    liElement.appendChild(divBtnWrapperElement);

    const btnChangeElement = document.createElement('button');
    divBtnWrapperElement.appendChild(btnChangeElement);
    btnChangeElement.setAttribute('class', 'change-btn');
    btnChangeElement.textContent = 'Change';
    btnChangeElement.addEventListener('click', () => {
        fnActivatedEditDeactivatedAddButtons();
        inputHostElement.value = itemData.host;
        inputScoreElement.value = itemData.score;
        inputGuestElement.value = itemData.guest;
        selectedTaskId = itemData._id;
    });

    const btnDeleteElement = document.createElement('button');
    divBtnWrapperElement.appendChild(btnDeleteElement);
    btnDeleteElement.setAttribute('class', 'delete-btn');
    btnDeleteElement.textContent = 'Delete';
    btnDeleteElement.addEventListener('click', () => {
        selectedTaskId = itemData._id;
        fetch(`${baseUrl}/${selectedTaskId}`, { method: 'DELETE' })
            .then(response => {
                if (response.ok) {
                    selectedTaskId = null;
                    fnClearListElement();
                    fnLoadItems();
                }
            })
            .catch(err => console.log(err.message));
    });

    return liElement;
}

function fnLoadItems() {
    // TODO: send a GET request to the server to fetch all records from your local database
    // You must add each task to the <ul> with id="list"
    // [Edit Record] button should be deactivated

    fetch(baseUrl)
        .then(response => response.json())
        .then(data => {
            fnClearListElement();
            fnClearInputs();
            fnDeactivatedEditActivatedAddButtons();
            Object.values(data).forEach(itemData => {
                ulListElement.appendChild(createSubItem(itemData));
            });
        })
        .catch(err => console.log(err.message));

}
function fnAddNewItem() {
    // TODO: send a POST request to the server, creating a new Record record with the Name, Steps and Calories from the input values
    // send another GET request to fetch all the records including the newly added one
    // clear all the input fields after the creation

    const itemHost = inputHostElement.value;
    const itemScore = inputScoreElement.value;
    const itemGuest = inputGuestElement.value;

    if (!itemHost || !itemScore || !itemGuest) {
        return;
    }

    const sendData = {
        host: itemHost,                    
        score: itemScore,           
        guest: itemGuest,     
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
                fnLoadItems();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));

}

function fnEditItem() {
    // TODO: [Change, Edit, Update and etc.] button  ???

    //e.preventDefault();
    const EditedData = {
        host: inputHostElement.value,             
        score: inputScoreElement.value,           
        guest: inputGuestElement.value,       
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
                fnLoadItems();
                fnDeactivatedEditActivatedAddButtons();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));
}


function attachEvents() {
    btnLoadElement.addEventListener('click', (e) => {
        e.preventDefault();
        fnLoadItems();
    });
    btnAddElement.addEventListener('click', (e) => {
        e.preventDefault();
        fnAddNewItem();
    });
    btnEditElement.addEventListener('click', (e) => {
        e.preventDefault();
        fnEditItem();
    });
}

function fnClearInputs() {
    inputHostElement.value = '';
    inputScoreElement.value = '';
    inputGuestElement.value = '';
}

function fnClearListElement() {
    ulListElement.innerHTML = '';
}

function fnDeactivatedEditActivatedAddButtons() {
    btnEditElement.disabled = true;
    btnAddElement.disabled = false;
}

function fnActivatedEditDeactivatedAddButtons() {
    btnEditElement.disabled = false;
    btnAddElement.disabled = true;
}

attachEvents();

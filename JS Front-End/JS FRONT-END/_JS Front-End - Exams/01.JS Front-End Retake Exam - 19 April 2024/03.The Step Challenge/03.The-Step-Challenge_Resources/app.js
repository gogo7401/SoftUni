console.log('//TODO...');
const baseUrl = 'http://localhost:3030/jsonstore/records';

const btnLoadRecordsElement = document.getElementById('load-records');
const btnEditRecordElement = document.getElementById('edit-record');
const btnAddRecordElement = document.getElementById('add-record');

const ulListElement = document.getElementById('list');
const inputNameElement = document.getElementById('p-name');
const inputStepsElement = document.getElementById('steps');
const inputCaloriesElement = document.getElementById('calories');

let selectedTaskId = null;


function createPlayers(player) {
    // TODO: Create a list of players with name, steps, and calories from the provided array
    // Each player should be added to the <ul> with id="list"
    const liElement = document.createElement('li');
    liElement.setAttribute('class', 'record');

    const divInfoElement = document.createElement('div');
    divInfoElement.setAttribute('class', 'info');

    const p1Element = document.createElement('p');
    p1Element.textContent = player.name;
    const p2Element = document.createElement('p');
    p2Element.textContent = player.steps;
    const p3Element = document.createElement('p');
    p3Element.textContent = player.calories;

    divInfoElement.appendChild(p1Element);
    divInfoElement.appendChild(p2Element);
    divInfoElement.appendChild(p3Element);
    liElement.appendChild(divInfoElement);

    const divBtnWrapperElement = document.createElement('div');
    divBtnWrapperElement.setAttribute('class', 'btn-wrapper');

    const btnChangeElement = document.createElement('button');
    btnChangeElement.setAttribute('class', 'change-btn');
    btnChangeElement.textContent = 'Change';
    btnChangeElement.addEventListener('click', () => {
        // [Change Record] button should enable the [Edit Record] button
        // and display the current player's details in the input fields
        fnActivatedEditDeactivatedAddButtons();
        inputNameElement.value = player.name;
        inputStepsElement.value = player.steps;
        inputCaloriesElement.value = player.calories;
        selectedTaskId = player._id;
    });

    const btnDeleteElement = document.createElement('button');
    btnDeleteElement.setAttribute('class', 'delete-btn');
    btnDeleteElement.textContent = 'Delete';
    btnDeleteElement.addEventListener('click', () => {
        // [Delete Record] button should send a DELETE request to the server to remove the selected player
        // After you've removed it successfully, fetch the Records again. -> fnLoadRecord();
        selectedTaskId = player._id;
        fetch(`${baseUrl}/${selectedTaskId}`, { method: 'DELETE' })
            .then(response => {
                if (response.ok) {
                    selectedTaskId = null;
                    fnClearListElement();
                    fnLoadRecords();
                }
            })
            .catch(err => console.log(err.message));
    });

    divBtnWrapperElement.appendChild(btnChangeElement);
    divBtnWrapperElement.appendChild(btnDeleteElement);
    liElement.appendChild(divBtnWrapperElement);

    return liElement;
}

function fnLoadRecords() {
    // TODO: send a GET request to the server to fetch all records from your local database
    // You must add each task to the <ul> with id="list"
    // [Edit Record] button should be deactivated

    fetch(baseUrl)
        .then(response => response.json())
        .then(data => {
            fnClearListElement();
            fnClearInputs();
            fnDeactivatedEditActivatedAddButtons();
            Object.values(data).forEach(player => {
                ulListElement.appendChild(createPlayers(player));
            });
            fnDeactivatedEditActivatedAddButtons();
        })
        .catch(err => console.log(err.message));

}
function fnAddRecord() {
    // TODO: send a POST request to the server, creating a new Record record with the Name, Steps and Calories from the input values
    // send another GET request to fetch all the records including the newly added one
    // clear all the input fields after the creation

    const playerName = inputNameElement.value;
    const playerSteps = inputStepsElement.value;
    const playerCalories = inputCaloriesElement.value;

    if (!playerName || !playerSteps || !playerCalories) {
        return;
    }

    const sendData = {
        name: playerName,
        steps: playerSteps,
        calories: playerCalories
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
                fnLoadRecords();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));

}

function fnEditRecord(e) {
    // TODO: [Change] button  ???
    e.preventDefault();
    const EditedData = {
        name: inputNameElement.value,
        steps: inputStepsElement.value,
        calories: inputCaloriesElement.value,
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
                fnLoadRecords();
                fnDeactivatedEditActivatedAddButtons();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));
}


function attachEvents() {
    btnLoadRecordsElement.addEventListener('click', fnLoadRecords);
    btnEditRecordElement.addEventListener('click', fnEditRecord);
    btnAddRecordElement.addEventListener('click', fnAddRecord);
}

function fnClearInputs() {
    inputNameElement.value = '';
    inputStepsElement.value = '';
    inputCaloriesElement.value = '';
}

function fnClearListElement() {
    ulListElement.innerHTML = '';
}

function fnDeactivatedEditActivatedAddButtons() {
    btnEditRecordElement.disabled = true;
    btnAddRecordElement.disabled = false;
}

function fnActivatedEditDeactivatedAddButtons() {
    btnEditRecordElement.disabled = false;
    btnAddRecordElement.disabled = true;
}

attachEvents();

console.log('//TODO...');
const baseUrl = 'http://localhost:3030/jsonstore/tasks';

const btnLoadVacationsElement = document.getElementById('load-vacations');//'
const btnAddVacationElement = document.getElementById('add-vacation');//
const btnEditVacationElement = document.getElementById('edit-vacation');//

const divListElement = document.getElementById('list');
const inputNameElement = document.getElementById('name');
const inputNumDaysElement = document.getElementById('num-days');
const inputFromDateElement = document.getElementById('from-date');

let selectedTaskId = null;

function createVacation(item) {
    // TODO: Create a list of players with name, steps, and calories from the provided array
    // Each player should be added to the <ul> with id="list"
    //console.log(`${gift.gift},${gift.for},${gift.price}`);

    const divContainerElement = document.createElement('div');
    divContainerElement.setAttribute('class', 'container');

    const h1Element = document.createElement('h2');
    h1Element.textContent = item.name;
    const h2Element = document.createElement('h3');
    h2Element.textContent = item.date;
    const h3Element = document.createElement('h3');
    h3Element.textContent = item.days;

    divContainerElement.appendChild(h1Element);
    divContainerElement.appendChild(h2Element);
    divContainerElement.appendChild(h3Element);

    const btnChangeElement = document.createElement('button');
    btnChangeElement.setAttribute('class', 'change-btn');
    btnChangeElement.textContent = 'Change';
    btnChangeElement.addEventListener('click', () => {
        // [Change Record] button should enable the [Edit Record] button
        // and display the current player's details in the input fields
        fnActivatedEditDeactivatedAddButtons();
        inputNameElement.value = item.name;
        inputNumDaysElement.value = item.days;
        inputFromDateElement.value = item.date;
        selectedTaskId = item._id;
        divListElement.removeChild(divContainerElement);
    });

    const btnDeleteElement = document.createElement('button');
    btnDeleteElement.setAttribute('class', 'done-btn');
    btnDeleteElement.textContent = 'Done';
    btnDeleteElement.addEventListener('click', () => {
        // [Delete Record] button should send a DELETE request to the server to remove the selected player
        // After you've removed it successfully, fetch the Records again. -> fnLoadRecord();
        selectedTaskId = item._id;
        fetch(`${baseUrl}/${selectedTaskId}`, { method: 'DELETE' })
            .then(response => {
                if (response.ok) {
                    selectedTaskId = null;
                    fnClearListElement();
                    fnLoadVacation();
                }
            })
            .catch(err => console.log(err.message));
    });

    divContainerElement.appendChild(btnChangeElement);
    divContainerElement.appendChild(btnDeleteElement);

    return divContainerElement;
}

function fnLoadVacation() {
    // TODO: send a GET request to the server to fetch all records from your local database
    // You must add each task to the <ul> with id="list"
    // [Edit Record] button should be deactivated

    fetch(baseUrl)
        .then(response => response.json())
        .then(data => {
            //console.log(data);
            //console.log(Object.values(data));
            fnClearListElement();
            fnClearInputs();
            fnDeactivatedEditActivatedAddButtons();
            Object.values(data).forEach(item => {
                divListElement.appendChild(createVacation(item));
            });
        })
        .catch(err => console.log(err.message));

}
function fnAddVacation(e) {
    // TODO: send a POST request to the server, creating a new Record record with the Name, Steps and Calories from the input values
    // send another GET request to fetch all the records including the newly added one
    // clear all the input fields after the creation

    e.preventDefault();
    const vacationName = inputNameElement.value;
    const vacationNumDays = inputNumDaysElement.value;
    const vacationDate = inputFromDateElement.value;

    if (!vacationName || !vacationNumDays || !vacationDate) {
        return;
    }

    const sendData = {
        name: vacationName,
        days: vacationNumDays,
        date: vacationDate
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
                fnLoadVacation();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));

}

function fnEditLocation(e) {
    // TODO: [Change] button  ???
    e.preventDefault();
    const EditedData = {
        name: inputNameElement.value,
        days: inputNumDaysElement.value,
        date: inputFromDateElement.value,
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
                fnLoadVacation();
                fnDeactivatedEditActivatedAddButtons();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));
}


function attachEvents() {
    btnLoadVacationsElement.addEventListener('click', fnLoadVacation);
    btnAddVacationElement.addEventListener('click', fnAddVacation);
    btnEditVacationElement.addEventListener('click', fnEditLocation);
}

function fnClearInputs() {
    inputNameElement.value = '';
    inputNumDaysElement.value = '';
    inputFromDateElement.value = '';
}

function fnClearListElement() {
    divListElement.innerHTML = '';
}

function fnDeactivatedEditActivatedAddButtons() {
    btnEditVacationElement.disabled = true;
    btnAddVacationElement.disabled = false;
}

function fnActivatedEditDeactivatedAddButtons() {
    btnEditVacationElement.disabled = false;
    btnAddVacationElement.disabled = true;
}

attachEvents();

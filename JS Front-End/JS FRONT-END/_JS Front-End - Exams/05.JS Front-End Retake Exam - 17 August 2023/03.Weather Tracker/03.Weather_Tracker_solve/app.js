console.log('//TODO...');
const baseUrl = 'http://localhost:3030/jsonstore/tasks';

const btnLoadHistoryElement = document.getElementById('load-history');//
const btnAddWeatherElement = document.getElementById('add-weather');//
const btnEditWeatherElement = document.getElementById('edit-weather');//

const divListElement = document.getElementById('list');//
const inputLocationNameElement = document.getElementById('location');//
const inputTemperatureElement = document.getElementById('temperature');//
const inputDateElement = document.getElementById('date');//

let selectedTaskId = null;

function createLocation(location) {
    // TODO: Create a list of players with name, steps, and calories from the provided array
    // Each player should be added to the <ul> with id="list"
    //console.log(`${gift.gift},${gift.for},${gift.price}`);

    const divContainerElement = document.createElement('div');
    divContainerElement.setAttribute('class', 'container');

    const h1Element = document.createElement('h2');
    h1Element.textContent = location.location;
    const h2Element = document.createElement('h3');
    h2Element.textContent = location.temperature;
    const h3Element = document.createElement('h3');
    h3Element.textContent = location.date;

    divContainerElement.appendChild(h1Element);
    divContainerElement.appendChild(h2Element);
    divContainerElement.appendChild(h3Element);

    const divBtnContainerElement = document.createElement('div');
    divBtnContainerElement.setAttribute('class', 'buttons-container');

    const btnChangeElement = document.createElement('button');
    btnChangeElement.setAttribute('class', 'change-btn');
    btnChangeElement.textContent = 'Change';
    btnChangeElement.addEventListener('click', () => {
        // [Change Record] button should enable the [Edit Record] button
        // and display the current player's details in the input fields
        fnActivatedEditDeactivatedAddButtons();
        inputLocationNameElement.value = location.location;
        inputTemperatureElement.value = location.temperature;
        inputDateElement.value = location.date;
        selectedTaskId = location._id;
        divListElement.removeChild(divContainerElement);
    });

    const btnDeleteElement = document.createElement('button');
    btnDeleteElement.setAttribute('class', 'delete-btn');
    btnDeleteElement.textContent = 'Delete';
    btnDeleteElement.addEventListener('click', () => {
        // [Delete Record] button should send a DELETE request to the server to remove the selected player
        // After you've removed it successfully, fetch the Records again. -> fnLoadRecord();
        selectedTaskId = location._id;
        fetch(`${baseUrl}/${selectedTaskId}`, { method: 'DELETE' })
            .then(response => {
                if (response.ok) {
                    selectedTaskId = null;
                    fnClearListElement();
                    fnLoadLocation();
                }
            })
            .catch(err => console.log(err.message));
    });

    divBtnContainerElement.appendChild(btnChangeElement);
    divBtnContainerElement.appendChild(btnDeleteElement);
    divContainerElement.appendChild(divBtnContainerElement);

    return divContainerElement;
}

function fnLoadLocation() {
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
            Object.values(data).forEach(location => {
                divListElement.appendChild(createLocation(location));
            });
            fnDeactivatedEditActivatedAddButtons();
        })
        .catch(err => console.log(err.message));

}
function fnAddLocation() {
    // TODO: send a POST request to the server, creating a new Record record with the Name, Steps and Calories from the input values
    // send another GET request to fetch all the records including the newly added one
    // clear all the input fields after the creation

    const locationName = inputLocationNameElement.value;
    const locationTemperature = inputTemperatureElement.value;
    const locationDate = inputDateElement.value;

    if (!locationName || !locationTemperature || !locationDate) {
        return;
    }

    const sendData = {
        location: locationName,
        temperature: locationTemperature,
        date: locationDate
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
                fnLoadLocation();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));

}

function fnEditLocation(e) {
    // TODO: [Change] button  ???
    e.preventDefault();
    const EditedData = {
        location: inputLocationNameElement.value,
        temperature: inputTemperatureElement.value,
        date: inputDateElement.value,
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
                fnLoadLocation();
                fnDeactivatedEditActivatedAddButtons();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));
}


function attachEvents() {
    btnLoadHistoryElement.addEventListener('click', fnLoadLocation);
    btnAddWeatherElement.addEventListener('click', fnAddLocation);
    btnEditWeatherElement.addEventListener('click', fnEditLocation);
}

function fnClearInputs() {
    inputLocationNameElement.value = '';
    inputTemperatureElement.value = '';
    inputDateElement.value = '';
}

function fnClearListElement() {
    divListElement.innerHTML = '';
}

function fnDeactivatedEditActivatedAddButtons() {
    btnEditWeatherElement.disabled = true;
    btnAddWeatherElement.disabled = false;
}

function fnActivatedEditDeactivatedAddButtons() {
    btnEditWeatherElement.disabled = false;
    btnAddWeatherElement.disabled = true;
}

attachEvents();

console.log('//TODO...');
const baseUrl = 'http://localhost:3030/jsonstore/tasks';

const btnLoadElement = document.getElementById('load-course');
const btnAddElement = document.getElementById('add-course');
const btnEditElement = document.getElementById('edit-course');

const divListElement = document.getElementById('list');
const inputTitleElement = document.getElementById('course-name');
const inputTypeElement = document.getElementById('course-type');
const textareaDescriptionElement = document.getElementById('description');
const inputTeacherElement = document.getElementById('teacher-name');

let selectedTaskId = null;

function createNewItem(item) {
    // TODO: Create a list of players with name, steps, and calories from the provided array
    // Each player should be added to the <ul> with id="list"
    //console.log(`${gift.gift},${gift.for},${gift.price}`);

    const divContainerElement = document.createElement('div');
    divContainerElement.setAttribute('class', 'container');

    const h1Element = document.createElement('h2');
    h1Element.textContent = item.title;
    const h2Element = document.createElement('h3');
    h2Element.textContent = item.teacher;
    const h3Element = document.createElement('h3');
    h3Element.textContent = item.type;
    const h4Element = document.createElement('h4');
    h4Element.textContent = item.description;

    divContainerElement.appendChild(h1Element);
    divContainerElement.appendChild(h2Element);
    divContainerElement.appendChild(h3Element);
    divContainerElement.appendChild(h4Element);

    const btnChangeElement = document.createElement('button');
    btnChangeElement.setAttribute('class', 'edit-btn');
    btnChangeElement.textContent = 'Edit Course';
    btnChangeElement.addEventListener('click', () => {
        // [Change Record] button should enable the [Edit Record] button
        // and display the current player's details in the input fields
        fnActivatedEditDeactivatedAddButtons();
        inputTitleElement.value = item.title;
        inputTypeElement.value = item.type;
        textareaDescriptionElement.value = item.description;
        inputTeacherElement.value = item.teacher;
        selectedTaskId = item._id;
        divListElement.removeChild(divContainerElement);
    });

    const btnDeleteElement = document.createElement('button');
    btnDeleteElement.setAttribute('class', 'finish-btn');
    btnDeleteElement.textContent = 'Finish Course';
    btnDeleteElement.addEventListener('click', () => {
        // [Delete Record] button should send a DELETE request to the server to remove the selected player
        // After you've removed it successfully, fetch the Records again. -> fnLoadRecord();
        selectedTaskId = item._id;
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

    divContainerElement.appendChild(btnChangeElement);
    divContainerElement.appendChild(btnDeleteElement);

    return divContainerElement;
}

function fnLoadItems() {
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
                divListElement.appendChild(createNewItem(item));
            });
        })
        .catch(err => console.log(err.message));

}
function fnAddItem(e) {
    // TODO: send a POST request to the server, creating a new Record record with the Name, Steps and Calories from the input values
    // send another GET request to fetch all the records including the newly added one
    // clear all the input fields after the creation

    e.preventDefault();
    const itemTitle = inputTitleElement.value;
    const itemType = inputTypeElement.value;
    const itemDesc = textareaDescriptionElement.value;
    const itemTeacher = inputTeacherElement.value;

    if ((itemType !== 'Long' && itemType !== 'Medium' && itemType !== 'Short')) {
        return;
    }

    const sendData = {
        title: itemTitle,
        type: itemType,
        description: itemDesc,
        teacher: itemTeacher,
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

function fnEditItem(e) {
    // TODO: [Change] button  ???
    e.preventDefault();
    const EditedData = {
        title: inputTitleElement.value,
        type: inputTypeElement.value,
        description: textareaDescriptionElement.value,
        teacher: inputTeacherElement.value,
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
    btnLoadElement.addEventListener('click', fnLoadItems);
    btnAddElement.addEventListener('click', fnAddItem);
    btnEditElement.addEventListener('click', fnEditItem);
}

function fnClearInputs() {
    inputTitleElement.value = '';
    inputTypeElement.value = '';
    textareaDescriptionElement.value = '';
    inputTeacherElement.value = '';

}

function fnClearListElement() {
    divListElement.innerHTML = '';
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

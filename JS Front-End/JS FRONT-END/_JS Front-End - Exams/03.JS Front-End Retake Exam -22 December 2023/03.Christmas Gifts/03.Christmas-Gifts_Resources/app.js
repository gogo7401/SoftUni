console.log('//TODO...');
const baseUrl = 'http://localhost:3030/jsonstore/gifts';

const btnLoadPesentsElement = document.getElementById('load-presents');//
const btnEditPresentElement = document.getElementById('edit-present');//
const btnAddPresentElement = document.getElementById('add-present');//

const divGiftListElement = document.getElementById('gift-list');//
const inputPresentElement = document.getElementById('gift');//
const inputForElement = document.getElementById('for');//
const inputPriceElement = document.getElementById('price');//

let selectedTaskId = null;

function createGift(gift) {
    // TODO: Create a list of players with name, steps, and calories from the provided array
    // Each player should be added to the <ul> with id="list"
    //console.log(`${gift.gift},${gift.for},${gift.price}`);

    const divGiftSockElement = document.createElement('div');
    divGiftSockElement.setAttribute('class', 'gift-sock');

    const divContentElement = document.createElement('div');
    divContentElement.setAttribute('class', 'content');

    const p1Element = document.createElement('p');
    p1Element.textContent = gift.gift;
    const p2Element = document.createElement('p');
    p2Element.textContent = gift.for;
    const p3Element = document.createElement('p');
    p3Element.textContent = gift.price;

    divContentElement.appendChild(p1Element);
    divContentElement.appendChild(p2Element);
    divContentElement.appendChild(p3Element);
    divGiftSockElement.appendChild(divContentElement);

    const divBtnContainerElement = document.createElement('div');
    divBtnContainerElement.setAttribute('class', 'buttons-container');

    const btnChangeElement = document.createElement('button');
    btnChangeElement.setAttribute('class', 'change-btn');
    btnChangeElement.textContent = 'Change';
    btnChangeElement.addEventListener('click', () => {
        // [Change Record] button should enable the [Edit Record] button
        // and display the current player's details in the input fields
        fnActivatedEditDeactivatedAddButtons();
        inputPresentElement.value = gift.gift;
        inputForElement.value = gift.for;
        inputPriceElement.value = gift.price;
        selectedTaskId = gift._id;
        divGiftListElement.removeChild(divGiftSockElement);
    });

    const btnDeleteElement = document.createElement('button');
    btnDeleteElement.setAttribute('class', 'delete-btn');
    btnDeleteElement.textContent = 'Delete';
    btnDeleteElement.addEventListener('click', () => {
        // [Delete Record] button should send a DELETE request to the server to remove the selected player
        // After you've removed it successfully, fetch the Records again. -> fnLoadRecord();
        selectedTaskId = gift._id;
        fetch(`${baseUrl}/${selectedTaskId}`, { method: 'DELETE' })
            .then(response => {
                if (response.ok) {
                    selectedTaskId = null;
                    fnClearListElement();
                    fnLoadGifts();
                }
            })
            .catch(err => console.log(err.message));
    });

    divBtnContainerElement.appendChild(btnChangeElement);
    divBtnContainerElement.appendChild(btnDeleteElement);
    divGiftSockElement.appendChild(divBtnContainerElement);

    return divGiftSockElement;
}

function fnLoadGifts() {
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
            Object.values(data).forEach(gift => {
                divGiftListElement.appendChild(createGift(gift));
            });
            fnDeactivatedEditActivatedAddButtons();
        })
        .catch(err => console.log(err.message));

}
function fnAddGift() {
    // TODO: send a POST request to the server, creating a new Record record with the Name, Steps and Calories from the input values
    // send another GET request to fetch all the records including the newly added one
    // clear all the input fields after the creation

    const giftName = inputPresentElement.value;
    const giftFor = inputForElement.value;
    const giftPrice = inputPriceElement.value;

    if (!giftName || !giftFor || !giftPrice) {
        return;
    }

    const sendData = {
        gift: giftName,
        for: giftFor,
        price: giftPrice
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
                fnLoadGifts();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));

}

function fnEditGift(e) {
    // TODO: [Change] button  ???
    e.preventDefault();
    const EditedData = {
        gift: inputPresentElement.value,
        for: inputForElement.value,
        price: inputPriceElement.value,
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
                fnLoadGifts();
                fnDeactivatedEditActivatedAddButtons();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));
}


function attachEvents() {
    btnLoadPesentsElement.addEventListener('click', fnLoadGifts);
    btnEditPresentElement.addEventListener('click', fnEditGift);
    btnAddPresentElement.addEventListener('click', fnAddGift);
}

function fnClearInputs() {
    inputPresentElement.value = '';
    inputForElement.value = '';
    inputPriceElement.value = '';
}

function fnClearListElement() {
    divGiftListElement.innerHTML = '';
}

function fnDeactivatedEditActivatedAddButtons() {
    btnEditPresentElement.disabled = true;
    btnAddPresentElement.disabled = false;
}

function fnActivatedEditDeactivatedAddButtons() {
    btnEditPresentElement.disabled = false;
    btnAddPresentElement.disabled = true;
}

attachEvents();

console.log('//TODO...');
const baseUrl = 'http://localhost:3030/jsonstore/tasks';

const btnLoadMealsElement = document.getElementById('load-meals');//
const btnAddMealElement = document.getElementById('add-meal');//
const btnEditMealElement = document.getElementById('edit-meal');//

const divListElement = document.getElementById('list');//
const inputFoodElement = document.getElementById('food');//
const inputTimeElement = document.getElementById('time');//
const inputCaloriesElement = document.getElementById('calories');//

let selectedTaskId = null;

function createFood(food) {
    // TODO: Create a list of players with name, steps, and calories from the provided array
    // Each player should be added to the <ul> with id="list"
    //console.log(`${gift.gift},${gift.for},${gift.price}`);

    const divMealElement = document.createElement('div');
    divMealElement.setAttribute('class', 'meal');

    const h1Element = document.createElement('h2');
    h1Element.textContent = food.food;
    const h2Element = document.createElement('h3');
    h2Element.textContent = food.time;
    const h3Element = document.createElement('h3');
    h3Element.textContent = food.calories;

    divMealElement.appendChild(h1Element);
    divMealElement.appendChild(h2Element);
    divMealElement.appendChild(h3Element);

    const divBtnContainerElement = document.createElement('div');
    divBtnContainerElement.setAttribute('class', 'meal-buttons');

    const btnChangeElement = document.createElement('button');
    btnChangeElement.setAttribute('class', 'change-meal');
    btnChangeElement.textContent = 'Change';
    btnChangeElement.addEventListener('click', () => {
        // [Change Record] button should enable the [Edit Record] button
        // and display the current player's details in the input fields
        fnActivatedEditDeactivatedAddButtons();
        inputFoodElement.value = food.food;
        inputTimeElement.value = food.time;
        inputCaloriesElement.value = food.calories;
        selectedTaskId = food._id;
        divListElement.removeChild(divMealElement);
    });

    const btnDeleteElement = document.createElement('button');
    btnDeleteElement.setAttribute('class', 'delete-meal');
    btnDeleteElement.textContent = 'Delete';
    btnDeleteElement.addEventListener('click', () => {
        // [Delete Record] button should send a DELETE request to the server to remove the selected player
        // After you've removed it successfully, fetch the Records again. -> fnLoadRecord();
        selectedTaskId = food._id;
        fetch(`${baseUrl}/${selectedTaskId}`, { method: 'DELETE' })
            .then(response => {
                if (response.ok) {
                    selectedTaskId = null;
                    fnClearListElement();
                    fnLoadFoods();
                }
            })
            .catch(err => console.log(err.message));
    });

    divBtnContainerElement.appendChild(btnChangeElement);
    divBtnContainerElement.appendChild(btnDeleteElement);
    divMealElement.appendChild(divBtnContainerElement);

    return divMealElement;
}

function fnLoadFoods() {
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
            Object.values(data).forEach(food => {
                divListElement.appendChild(createFood(food));
            });
            fnDeactivatedEditActivatedAddButtons();
        })
        .catch(err => console.log(err.message));

}
function fnAddFood() {
    // TODO: send a POST request to the server, creating a new Record record with the Name, Steps and Calories from the input values
    // send another GET request to fetch all the records including the newly added one
    // clear all the input fields after the creation

    const foodName = inputFoodElement.value;
    const foodTime = inputTimeElement.value;
    const foodCalories = inputCaloriesElement.value;

    if (!foodName || !foodTime || !foodCalories) {
        return;
    }

    const sendData = {
        food: foodName,
        time: foodTime,
        calories: foodCalories
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
                fnLoadFoods();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));

}

function fnEditFood(e) {
    // TODO: [Change] button  ???
    e.preventDefault();
    const EditedData = {
        food: inputFoodElement.value,
        time: inputTimeElement.value,
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
                fnLoadFoods();
                fnDeactivatedEditActivatedAddButtons();
                fnClearInputs();
            }
        })
        .catch(err => console.log(err.message));
}


function attachEvents() {
    btnLoadMealsElement.addEventListener('click', fnLoadFoods);
    btnEditMealElement.addEventListener('click', fnEditFood);
    btnAddMealElement.addEventListener('click', fnAddFood);
}

function fnClearInputs() {
    inputFoodElement.value = '';
    inputTimeElement.value = '';
    inputCaloriesElement.value = '';
}

function fnClearListElement() {
    divListElement.innerHTML = '';
}

function fnDeactivatedEditActivatedAddButtons() {
    btnEditMealElement.disabled = true;
    btnAddMealElement.disabled = false;
}

function fnActivatedEditDeactivatedAddButtons() {
    btnEditMealElement.disabled = false;
    btnAddMealElement.disabled = true;
}

attachEvents();

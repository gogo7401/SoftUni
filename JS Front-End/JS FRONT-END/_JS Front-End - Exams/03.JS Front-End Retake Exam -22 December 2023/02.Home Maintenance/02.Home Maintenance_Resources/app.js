window.addEventListener("load", solve);

function solve() {
    let formElement = document.querySelector('form');    
    let inputPlaceElement = document.querySelector('#place');
    let inputActionElement = document.querySelector('#action');
    let inputPersonElement = document.querySelector('#person');
    let buttonAddElement = document.querySelector('#add-btn');
    let ulTaskListElement = document.querySelector('#task-list');
    let ulDoneListElement = document.querySelector('#done-list');

    buttonAddElement.addEventListener('click', fnAddTask);

    function fnAddTask(event) {
        event.preventDefault();
        let place = inputPlaceElement.value;
        let action = inputActionElement.value;
        let person = inputPersonElement.value;

        //check for empty string
        if (place === '' || action === '' || person === '') {
            return;
        }

        let liElement = document.createElement('li');
        liElement.setAttribute('class', 'clean-task');

        let articleElement = document.createElement('article');

        let paragraphPlaceElement = document.createElement('p');
        paragraphPlaceElement.textContent = `Place:${place}`;

        let paragraphActionElement = document.createElement('p');
        paragraphActionElement.textContent = `Action:${action}`;

        let paragraphPersonElement = document.createElement('p');
        paragraphPersonElement.textContent = `Person:${person}`;

        articleElement.appendChild(paragraphPlaceElement);
        articleElement.appendChild(paragraphActionElement);
        articleElement.appendChild(paragraphPersonElement);
        liElement.appendChild(articleElement);

        let divElelment = document.createElement('div');
        divElelment.setAttribute('class', 'buttons');

        let buttonEditElement = document.createElement('button');
        buttonEditElement.setAttribute('class', 'edit');
        buttonEditElement.textContent = 'Edit';
        buttonEditElement.addEventListener('click', fnEditTask);

        let buttonDoneElement = document.createElement('button');
        buttonDoneElement.setAttribute('class', 'done');
        buttonDoneElement.textContent = 'Done';
        buttonDoneElement.addEventListener('click', fnDoneTask);

        divElelment.appendChild(buttonEditElement);
        divElelment.appendChild(buttonDoneElement);
        liElement.appendChild(divElelment);
        ulTaskListElement.appendChild(liElement);

        // Clear input fields
        formElement.reset();

        // Disable Add button
        //buttonAddElement.disabled = true;

        function fnEditTask(event){
            // TODO: Implement edit functionality
            let liTargetElement = event.currentTarget.parentElement.parentElement;
            
            inputPlaceElement.value = liTargetElement.querySelector('article').children[0].textContent.split(':')[1];
            inputActionElement.value = liTargetElement.querySelector('article').children[1].textContent.split(':')[1];
            inputPersonElement.value = liTargetElement.querySelector('article').children[2].textContent.split(':')[1];
            ulTaskListElement.removeChild(liTargetElement);
        }

        function fnDoneTask(event) {
            // TODO: Implement done functionality
            let liTargetElement = event.currentTarget.parentElement.parentElement;
            //ulTaskListElement.removeChild(liTargetElement);
            
            liTargetElement.removeChild(liTargetElement.querySelector('div'));
            let buttonDeleteElement = document.createElement('button');
            buttonDeleteElement.setAttribute('class', 'delete');
            buttonDeleteElement.textContent = 'Delete';
            buttonDeleteElement.addEventListener('click', fnDeleteTask);
            liTargetElement.appendChild(buttonDeleteElement);

            ulDoneListElement.appendChild(liTargetElement);

            function fnDeleteTask(event) {
                // TODO: Implement delete functionality
                let liTargetElement = event.currentTarget.parentElement;
                //console.log(liTargetElement);
                ulDoneListElement.removeChild(liTargetElement);
            }
 
        }
    }
        
}

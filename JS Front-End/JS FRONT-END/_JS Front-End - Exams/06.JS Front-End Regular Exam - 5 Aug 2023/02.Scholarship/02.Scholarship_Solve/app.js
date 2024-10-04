window.addEventListener("load", solve);

function solve() {
	// console.log('//TODO');

	const formElement = document.querySelector('form');
	const inputNameElement = document.getElementById('student');
	const inputUniversityElement = document.getElementById('university');
	const inputScoreElement = document.getElementById('score');
	const btnAddElement = document.getElementById('next-btn');
	// const btnClearElement = document.querySelector('#players-container > div > div > button');  // само когато има първоначално създаден Clear button

	const ulFirstListElement = document.getElementById('preview-list');
	const ulSecondListElement = document.getElementById('candidates-list');


	function addToFirstLists(itemName, itemUniversity, itemScore) {
		// TODO: 

		// Create item element for add to First List - UL
		const liItemElement = document.createElement('li');
		liItemElement.setAttribute('class', 'application');

		const articleElement = document.createElement('article');

		const p1Element = document.createElement('h4');
		p1Element.textContent = itemName;
		const p2Element = document.createElement('p');
		p2Element.textContent = `University: ${itemUniversity}`;
		const p3Element = document.createElement('p');
		p3Element.textContent = `Score: ${itemScore}`;

		articleElement.appendChild(p1Element);
		articleElement.appendChild(p2Element);
		articleElement.appendChild(p3Element);
		liItemElement.appendChild(articleElement);

		const btnEditElement = document.createElement('button');
		btnEditElement.setAttribute('class', 'action-btn edit');
		btnEditElement.textContent = 'edit';
		btnEditElement.addEventListener('click', () => {
			// TODO: Implement edit functionality
			// inputNameElement.value = p1Element.textContent;
			// inputUniversityElement.value = p2Element.textContent.split(': ')[1];
			// inputScoreElement.value = p3Element.textContent.split(': ')[1];

			inputNameElement.value = itemName;
			inputUniversityElement.value = itemUniversity;
			inputScoreElement.value = itemScore;

			liItemElement.remove();

			btnAddElement.disabled = false;
		});

		const btnActionElement = document.createElement('button');
		btnActionElement.setAttribute('class', 'action-btn apply');
		btnActionElement.textContent = 'apply';
		btnActionElement.addEventListener('click', () => {
			// TODO: Implement ok functionality

			liItemElement.removeChild(btnEditElement);
			liItemElement.removeChild(btnActionElement);

			ulSecondListElement.appendChild(liItemElement);

			btnAddElement.disabled = false;
		});

		liItemElement.appendChild(btnEditElement);
		liItemElement.appendChild(btnActionElement);

		return liItemElement;
	}

	function fnAddElement() {
		const itemName = inputNameElement.value;
		const itemUniversity = inputUniversityElement.value;
		const itemScore = Number(inputScoreElement.value);

		if ((inputNameElement.value === '') || (inputUniversityElement.value === '') || (inputScoreElement.value === '')) {
			return;
		}

		ulFirstListElement.appendChild(addToFirstLists(itemName, itemUniversity, itemScore));
		fnClearInputs();
		btnAddElement.disabled = true;
	}

	function fnClearInputs() {
		inputNameElement.value = '';
		inputUniversityElement.value = '';
		inputScoreElement.value = '';
	}

	// само когато има първоначално създаден Clear button
	// function fnClearElements() {  
	// 	location.reload();
	// }

	function addButtonsEventListener() {
		btnAddElement.addEventListener('click', fnAddElement);
		// btnClearElement.addEventListener('click', fnClearElements); // само когато има първоначално създаден Clear button
	}

	addButtonsEventListener();

}

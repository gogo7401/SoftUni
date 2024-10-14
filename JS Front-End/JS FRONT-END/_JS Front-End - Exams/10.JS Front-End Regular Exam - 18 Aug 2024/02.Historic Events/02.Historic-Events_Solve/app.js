window.addEventListener("load", solve);

function solve() {
	console.log('//TODO');

	const formElement = document.querySelector('form');

	const inputEventNameElement = document.getElementById('name');
	const inputTimePeriodElement = document.getElementById('time');
	const textareaDescriptionElement = document.getElementById('description');

	const btnAddElement = document.getElementById('add-btn');

	const ulFirstListElement = document.getElementById('preview-list');
	const ulSecondListElement = document.getElementById('archive-list');


	function addToFirstLists(itemName, itemPeriod, itemDesc) {
		// TODO: 

		// Create item element for add to First List - UL
		const liItemElement = document.createElement('li');

		const articleElement = document.createElement('article');
		liItemElement.appendChild(articleElement);

		const p1Element = document.createElement('p');
		p1Element.textContent = itemName;
		articleElement.appendChild(p1Element);
		
		const p2Element = document.createElement('p');
		p2Element.textContent = itemPeriod;
		articleElement.appendChild(p2Element);
		
		const p3Element = document.createElement('p');
		p3Element.textContent = itemDesc;
		articleElement.appendChild(p3Element);

		divButtonsElement = document.createElement('div');
		divButtonsElement.setAttribute('class', 'buttons');
		liItemElement.appendChild(divButtonsElement);

		const btnEditElement = document.createElement('button');
		btnEditElement.setAttribute('class', 'edit-btn');
		btnEditElement.textContent = 'Edit';
		divButtonsElement.appendChild(btnEditElement);

		btnEditElement.addEventListener('click', () => {
			// TODO: Implement edit functionality
			
			inputEventNameElement.value = itemName;
			inputTimePeriodElement.value = itemPeriod;
			textareaDescriptionElement.value = itemDesc;
			
			liItemElement.remove();

			btnAddElement.disabled = false;
		});

		const btnNextElement = document.createElement('button');
		btnNextElement.setAttribute('class', 'next-btn');
		btnNextElement.textContent = 'Next';
		divButtonsElement.appendChild(btnNextElement);

		btnNextElement.addEventListener('click', (event) => {
			// TODO: Implement ok functionality

			event.target.parentElement.remove();

			const btnArchiveElement = document.createElement('button');
			liItemElement.appendChild(btnArchiveElement);
			btnArchiveElement.setAttribute('class', 'archive-btn');
			btnArchiveElement.textContent = 'Archive';
			btnArchiveElement.addEventListener('click', (event) => {
				event.target.parentElement.remove();
			});

			ulSecondListElement.appendChild(liItemElement);

			btnAddElement.disabled = false;
		});

		return liItemElement;
	}

	function fnAddElement(e) {
		e.preventDefault();
		const itemName = inputEventNameElement.value;
		const itemPeriod = inputTimePeriodElement.value;
		const itemDesc = textareaDescriptionElement.value;

		if ((inputEventNameElement.value === '') || (inputTimePeriodElement.value === '') || (textareaDescriptionElement.value === '')) {
			return;
		}

		ulFirstListElement.appendChild(addToFirstLists(itemName, itemPeriod, itemDesc));
		fnClearInputs();
		btnAddElement.disabled = true;
	}

	function fnClearInputs() {
		formElement.reset();
	}

	function addButtonsEventListener() {
		btnAddElement.addEventListener('click', fnAddElement);
	}

	addButtonsEventListener();

}

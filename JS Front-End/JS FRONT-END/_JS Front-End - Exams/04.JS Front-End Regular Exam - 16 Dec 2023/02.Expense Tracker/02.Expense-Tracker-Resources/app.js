window.addEventListener("load", solve);

function solve() {
	console.log('//TODO');

	const formElement = document.querySelector('form');
	const inputTypeElement = document.getElementById('expense');
	const inputAmountElement = document.getElementById('amount');
	const inputDateElement = document.getElementById('date');
	const btnAddElement = document.getElementById('add-btn');
	const btnDeleteElement = document.querySelector('.btn.delete');
	
	const ulFirstListElement = document.getElementById('preview-list');
	const ulSecondListElement = document.getElementById('expenses-list');


	function addToFirstLists(itemType, itemAmount, itemDate) {
		// TODO: 

		// Create item element for add to First List - UL
		const liItemElement = document.createElement('li');
		liItemElement.setAttribute('class', 'expense-item');

		const articleElement = document.createElement('article');

		const p1Element = document.createElement('p');
		p1Element.textContent = `Type: ${itemType}`;;
		const p2Element = document.createElement('p');
		p2Element.textContent = `Amount: ${itemAmount}$`;
		const p3Element = document.createElement('p');
		p3Element.textContent = `Date: ${itemDate}`;

		articleElement.appendChild(p1Element);
		articleElement.appendChild(p2Element);
		articleElement.appendChild(p3Element);
		liItemElement.appendChild(articleElement);

		divButtonsElement = document.createElement('div');
		divButtonsElement.setAttribute('class', 'buttons');

		const btnEditElement = document.createElement('button');
		btnEditElement.setAttribute('class', 'btn edit');
		btnEditElement.textContent = 'edit';
		divButtonsElement.appendChild(btnEditElement);
		btnEditElement.addEventListener('click', () => {
			// TODO: Implement edit functionality
			
			// const [, type] = liItemElement.querySelector("p:nth-child(1)").textContent.split(":");
			// const [, gender] = liItemElement.querySelector("p:nth-child(2)").textContent.split(":");
			// const [, age] = liItemElement.querySelector("p:nth-child(3)").textContent.split(":");
			
			inputTypeElement.value = itemType;
			inputAmountElement.value = itemAmount;
			inputDateElement.value = itemDate;
			
			liItemElement.remove();

			btnAddElement.disabled = false;
		});

		const btnActionElement = document.createElement('button');
		btnActionElement.setAttribute('class', 'btn ok');
		btnActionElement.textContent = 'ok';
		divButtonsElement.appendChild(btnActionElement);
		btnActionElement.addEventListener('click', (event) => {
			// TODO: Implement ok functionality

			// liItemElement.removeChild(btnEditElement);
			// liItemElement.removeChild(btnActionElement);


			event.target.parentElement.remove();

			ulSecondListElement.appendChild(liItemElement);

			btnAddElement.disabled = false;
		});

		
		
		liItemElement.appendChild(divButtonsElement);

		return liItemElement;
	}

	function fnAddElement(e) {
		e.preventDefault();
		const itemType = inputTypeElement.value;
		const itemAmount = inputAmountElement.value;
		const itemDate = inputDateElement.value;

		if ((inputTypeElement.value === '') || (inputAmountElement.value === '') || (inputDateElement.value === '')) {
			return;
		}

		ulFirstListElement.appendChild(addToFirstLists(itemType, itemAmount, itemDate));
		fnClearInputs();
		btnAddElement.disabled = true;
	}

	function fnClearInputs() {
		// inputTypeElement.value = '';
		// inputAgeElement.value = '';
		// selectGenderElement.selectedIndex = 0;
		formElement.reset();
	}

	function fnDeleteAllElement(e) {
        location.reload();
    }

	function addButtonsEventListener() {
		btnAddElement.addEventListener('click', fnAddElement);
		btnDeleteElement.addEventListener('click', fnDeleteAllElement);
	}

	addButtonsEventListener();

}

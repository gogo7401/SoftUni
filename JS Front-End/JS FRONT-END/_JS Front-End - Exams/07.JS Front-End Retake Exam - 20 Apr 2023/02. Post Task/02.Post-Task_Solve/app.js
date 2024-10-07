window.addEventListener("load", solve);

function solve() {
    console.log('//TODO');

    const formElement = document.querySelector('form');
    const inputTitleElement = document.getElementById('task-title');
    const inputCategoryElement = document.getElementById('task-category');
    const textareaContentElement = document.getElementById('task-content');
    const btnAddElement = document.getElementById('publish-btn');

    const ulFirstListElement = document.getElementById('review-list');
    const ulSecondListElement = document.getElementById('published-list');


    function addToFirstLists(itemTitle, itemCategory, itemContent) {
        // TODO: 

        // Create item element for add to First List - UL
        const liItemElement = document.createElement('li');
        liItemElement.setAttribute('class', 'rpost');

        const articleElement = document.createElement('article');

        const p1Element = document.createElement('h4');
        p1Element.textContent = `${itemTitle}`;
        const p2Element = document.createElement('p');
        p2Element.textContent = `Category: ${itemCategory}`;
        const p3Element = document.createElement('p');
        p3Element.textContent = `Content: ${itemContent}`;

        articleElement.appendChild(p1Element);
        articleElement.appendChild(p2Element);
        articleElement.appendChild(p3Element);
        liItemElement.appendChild(articleElement);

        const btnEditElement = document.createElement('button');
        btnEditElement.setAttribute('class', 'action-btn edit');
        btnEditElement.textContent = 'Edit';
        liItemElement.appendChild(btnEditElement);
        btnEditElement.addEventListener('click', () => {
            // TODO: Implement edit functionality

            inputTitleElement.value = itemTitle;
            inputCategoryElement.value = itemCategory;
            textareaContentElement.value = itemContent;

            liItemElement.remove();
        });

        const btnActionElement = document.createElement('button');
        btnActionElement.setAttribute('class', 'action-btn post');
        btnActionElement.textContent = 'Post';
        liItemElement.appendChild(btnActionElement);
        btnActionElement.addEventListener('click', (event) => {
            // TODO: Implement Post functionality

            liItemElement.removeChild(btnEditElement);
            liItemElement.removeChild(btnActionElement);

            ulSecondListElement.appendChild(liItemElement);
        });

        return liItemElement;
    }

    function fnAddElement(e) {
        e.preventDefault();
        const itemTitle = inputTitleElement.value;
        const itemCategory = inputCategoryElement.value;
        const itemContent = textareaContentElement.value;

        if ((inputTitleElement.value === '') || (inputCategoryElement.value === '') || (textareaContentElement.value === '')) {
            return;
        }

        ulFirstListElement.appendChild(addToFirstLists(itemTitle, itemCategory, itemContent));
        fnClearInputs();
    }

    function fnClearInputs() {
        formElement.reset();
    }

    function addButtonsEventListener() {
        btnAddElement.addEventListener('click', fnAddElement);
    }

    addButtonsEventListener();

}

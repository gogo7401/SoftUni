window.addEventListener("load", solve);


function solve() {
    let formElelment = document.querySelector('form');
    let inputExpenseElement = document.getElementById('expense');
    let inputAmountElement = document.getElementById('amount');
    let inputDateElement = document.getElementById('date');
    let buttonAddElement = document.getElementById('add-btn');
    let ulPreviewListElement = document.getElementById('preview-list');
    let ulExpensesListElement = document.getElementById('expenses-list');
    let buttonDeleteElement = document.querySelector('.btn.delete');
    buttonDeleteElement.addEventListener("click", () => { location.reload(); });

    buttonAddElement.addEventListener("click", fnAdd);

    function fnAdd(event) {
        event.preventDefault();

        let expense = inputExpenseElement.value;
        let amount = inputAmountElement.value;
        let date = inputDateElement.value;

        if (expense === '' || amount === '' || date === '') {
            alert("All fields are required!");
            return;
        }

        let liElement = document.createElement('li');
        liElement.setAttribute('class', 'expense-item');

        let articleElement = document.createElement('article');
        let pTypeElement = document.createElement('p');
        pTypeElement.textContent = `Type: ${expense}`;
        let pAmountElement = document.createElement('p');
        pAmountElement.textContent = `Amount: ${amount}$`;
        let pDateElement = document.createElement('p');
        pDateElement.textContent = `Date: ${date}`;
        articleElement.appendChild(pTypeElement);
        articleElement.appendChild(pAmountElement);
        articleElement.appendChild(pDateElement);
        liElement.appendChild(articleElement);

        let divElement = document.createElement('div');
        divElement.setAttribute('class', 'buttons');
        let btnEditElement = document.createElement('button');
        btnEditElement.setAttribute('class', 'btn edit');
        btnEditElement.textContent = 'edit';
        btnEditElement.addEventListener('click', fnEdit);
        let btnOkElement = document.createElement('button');
        btnOkElement.setAttribute('class', 'btn ok');
        btnOkElement.textContent = 'ok';
        btnOkElement.addEventListener('click', fnOk);
        divElement.appendChild(btnEditElement);
        divElement.appendChild(btnOkElement);
        liElement.appendChild(divElement);

        ulPreviewListElement.appendChild(liElement);

        buttonAddElement.disabled = true;
        formElelment.reset();

        function fnEdit(event) {
            buttonAddElement.disabled = false;

            let liParentElement = event.currentTarget.parentElement.parentElement;
            inputExpenseElement.value = liParentElement.querySelectorAll('p')[0].textContent.split(': ')[1];
            inputAmountElement.value = liParentElement.querySelectorAll('p')[1].textContent.split(': ')[1].split('$')[0];
            inputDateElement.value = liParentElement.querySelectorAll('p')[2].textContent.split(': ')[1];

            liParentElement.remove();
        }

        function fnOk(event) {
            buttonAddElement.disabled = false;

            let liParentElement = event.currentTarget.parentElement.parentElement;
            liParentElement.removeChild(liParentElement.querySelector('div'));
            ulExpensesListElement.appendChild(liParentElement);
        }
    }
}

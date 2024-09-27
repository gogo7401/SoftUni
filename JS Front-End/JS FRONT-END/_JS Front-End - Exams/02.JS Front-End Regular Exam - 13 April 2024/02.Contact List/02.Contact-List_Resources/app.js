window.addEventListener("load", solve);

function solve() {
  //console.log('//...TODO');

  let addBtnElement = document.getElementById('add-btn');
  addBtnElement.addEventListener("click", addBtnAction);

  function addBtnAction(event) {
    event.preventDefault();
    let formElement = event.currentTarget.parentElement;
    let nameInput = formElement.querySelector('input[type="text"][id="name"]');
    let phoneNumberInput = formElement.querySelector('input[type="number"][id="phone"]');
    let selectCategoriesInput = formElement.querySelector('select[name="category"][id="category"]');

    if ((nameInput.value === '') || (phoneNumberInput.value === '') || (selectCategoriesInput.value === '')){
      return;
    }

    //console.log(nameInput.value, phoneNumberInput.value, selectCategoriesInput.value, selectCategoriesInput.selectedIndex);

    let ulCheckListElement = document.querySelector('#check-list');

    let liElement = document.createElement('li');

    let articleElement = document.createElement('article');

    let nameParagraphElement = document.createElement('p');
    nameParagraphElement.textContent = `name:${nameInput.value}`;

    let phoneParagraphElement = document.createElement('p');
    phoneParagraphElement.textContent = `phone:${phoneNumberInput.value}`;

    let categoryParagraphElement = document.createElement('p');
    categoryParagraphElement.textContent = `category:${selectCategoriesInput.options[selectCategoriesInput.selectedIndex].value}`;

    articleElement.appendChild(nameParagraphElement);
    articleElement.appendChild(phoneParagraphElement);
    articleElement.appendChild(categoryParagraphElement);
    liElement.appendChild(articleElement);

    let divElement = document.createElement('div');
    divElement.setAttribute('class', 'buttons');

    let edtBtnElement = document.createElement('button');
    edtBtnElement.setAttribute('class', 'edit-btn');
    edtBtnElement.addEventListener('click',fnEdit);

    let saveBtnElement = document.createElement('button');
    saveBtnElement.setAttribute('class','save-btn');
    saveBtnElement.addEventListener('click',fnSave);

    divElement.appendChild(edtBtnElement);
    divElement.appendChild(saveBtnElement);
    liElement.appendChild(divElement);

    ulCheckListElement.appendChild(liElement);

    // Clear input fields
    nameInput.value = '';
    phoneNumberInput.value = '';
    selectCategoriesInput.value = '';

    function fnEdit(event){
      let liTargetElement = event.currentTarget.parentElement.parentElement;
      let [targetNameElement, targetPhoneNumberElement, targetCategoryElement] = liTargetElement.querySelectorAll('article p');

      let targetName = targetNameElement.textContent.split(':')[1];
      let targetPhoneNumber = targetPhoneNumberElement.textContent.split(':')[1];
      let targetCategory = targetCategoryElement.textContent.split(':')[1];
  
      nameInput.value = targetName;
      phoneNumberInput.value = targetPhoneNumber;
      selectCategoriesInput.value = targetCategory;

      ulCheckListElement.removeChild(liTargetElement);
    }

    function fnSave(event){
      let ulContactListElement = document.getElementById("contact-list");

      let liTargetElement = event.currentTarget.parentElement.parentElement;
      ulCheckListElement.removeChild(liTargetElement);
      liTargetElement.removeChild(liTargetElement.querySelector('div'));

      let deleteBtnElement = document.createElement('button');
      deleteBtnElement.setAttribute('class', 'del-btn');
      deleteBtnElement.addEventListener('click', fnDelete);
      liTargetElement.appendChild(deleteBtnElement);

      ulContactListElement.appendChild(liTargetElement);

    }

    function fnDelete(event){
      let ulContactListElement = event.currentTarget.parentElement.parentElement;
      let liTargetElement = event.currentTarget.parentElement;
      ulContactListElement.removeChild(liTargetElement);
    }

  }

}

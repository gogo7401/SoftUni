window.addEventListener("load", solve);

function solve() {
  //console.log('//TODO..');
  let adoptButtonElement = document.getElementById('adopt-btn');
  //console.log(adoptButtonElement);
  adoptButtonElement.addEventListener('click', adoptPet);


  function adoptPet(event) {
    // TODO: Add pet to adopted pets list
    event.preventDefault();
    let inputPetInfo = event.currentTarget.parentElement;
    let petType = inputPetInfo.querySelector('input[type="text"][id="type"]');
    let petAge = inputPetInfo.querySelector('input[type="number"][id="age"]');
    let petGender = inputPetInfo.querySelector('select[name="gender"][id="gender"]');

    if ((petType.value === '') || (Number(petAge.value) <= 0) || (petGender.selectedIndex === 0))
      return;

    // console.log(petType.value);
    // console.log(Number(petAge.value));
    // console.log(petGender.options[petGender.selectedIndex].text);

    let ulAdoptionInfoElement = document.getElementById('adoption-info');

    let liElement = document.createElement('li');

    let articleElement = document.createElement('article');

    let paragraphPetElement = document.createElement('p');
    paragraphPetElement.textContent = `Pet:${petType.value}`;
    let petTypeValue = petType.value;

    let paragraphGenderElement = document.createElement('p');
    paragraphGenderElement.textContent = `Gender:${petGender.value}`;
    let petGenderIndex = petGender.selectedIndex;

    let paragraphAgeElement = document.createElement('p');
    paragraphAgeElement.textContent = `Age:${petAge.value}`;
    let petAgeValue = petAge.value;

    let divClassButtonsElement = document.createElement('div');
    divClassButtonsElement.setAttribute('class', 'buttons');

    let editButtonElement = document.createElement('button');
    editButtonElement.setAttribute('class', 'edit-btn');
    editButtonElement.textContent = 'Edit';
    editButtonElement.addEventListener('click', editPet);

    let doneButtonElement = document.createElement('button');
    doneButtonElement.setAttribute('class', 'done-btn');
    doneButtonElement.textContent = 'Done';
    doneButtonElement.addEventListener('click', donePet);

    // appendChild
    divClassButtonsElement.appendChild(editButtonElement);
    divClassButtonsElement.appendChild(doneButtonElement);

    articleElement.appendChild(paragraphPetElement);
    articleElement.appendChild(paragraphGenderElement);
    articleElement.appendChild(paragraphAgeElement);

    liElement.appendChild(articleElement);
    liElement.appendChild(divClassButtonsElement);

    ulAdoptionInfoElement.appendChild(liElement);


    console.log(editButtonElement);

    // clear input
    petType.value = '';
    petAge.value = '';
    petGender.selectedIndex = 0;

    function editPet(event){
      // TODO: Edit pet info
      petType.value = petTypeValue;
      petAge.value = petAgeValue;
      petGender.selectedIndex = petGenderIndex;
      console.log(event.currentTarget.parentElement.parentElement);
      event.currentTarget.parentElement.parentElement.remove();
    }

    function donePet(event){
      let ulAdoptionInfoElement = document.getElementById('adopted-list');
      let liElement = event.currentTarget.parentElement.parentElement;
      let removeDivElement = liElement.querySelector('div.buttons');
      liElement.removeChild(removeDivElement);
      let clearButtonElement = document.createElement('button');
      clearButtonElement.setAttribute('class', 'clear-btn');
      clearButtonElement.textContent = 'Clear';
      clearButtonElement.addEventListener('click', clearPet);
      liElement.appendChild(clearButtonElement);
      ulAdoptionInfoElement.appendChild(liElement);
    }  

    function clearPet(event){
      event.currentTarget.parentElement.remove();
    }

  }
}

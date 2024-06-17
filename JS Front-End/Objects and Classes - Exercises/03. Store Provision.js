function Solve(arrInput1, arrInput2) {
let storeWarehouse = [];
for (let index = 0; index < arrInput1.length-1; index++) {
  const product = {};
  product.name = arrInput1[index];
  product.price = Number(arrInput1[++index]);
  storeWarehouse.push(product);
}

for (let index = 0; index < arrInput2.length-1; index++) {
  const product = {};
  product.name = arrInput2[index];
  product.price = Number(arrInput2[++index]);
  let result;
  if (result = storeWarehouse.find(({ name }) => name === product.name)) {
    result.price += product.price;
    
  } else {
    storeWarehouse.push(product);
  }
  
  
  
}


// print
for (const item of storeWarehouse) {
  console.log(item.name + " -> " + item.price);
  
}
}

Solve(
  ["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
  ["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]
);
Solve(
  ["Salt", "2", "Fanta", "4", "Apple", "14", "Water", "4", "Juice", "5"],
  ["Sugar", "44", "Oil", "12", "Apple", "7", "Tomatoes", "7", "Bananas", "30"]
);

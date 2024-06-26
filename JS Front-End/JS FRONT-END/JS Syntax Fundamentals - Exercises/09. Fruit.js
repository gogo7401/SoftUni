function PrintFruit(fruit, grams, price) {
    const weight = (grams / 1000).toFixed(2);
    const money = ((grams / 1000)*price).toFixed(2);


    console.log(`I need $${money} to buy ${weight} kilograms ${fruit}.`);
}



PrintFruit('orange', 2500, 1.80);
PrintFruit('apple', 1563, 2.35);

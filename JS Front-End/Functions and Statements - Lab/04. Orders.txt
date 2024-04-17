function Solve(order, quantity) {
    const totalPrice = {
        coffee: (quantity) => quantity * 1.50,
        water: (quantity) => quantity * 1.00,
        coke: (quantity) => quantity * 1.40,
        snacks: (quantity) => quantity * 2.00,

    }

    console.log(totalPrice[order](quantity).toFixed(2));
}





Solve("water", 5);
Solve("coffee", 2);


// •	coffee - 1.50
// •	water - 1.00
// •	coke - 1.40
// •	snacks - 2.00

function PrintTotalPrices(count, type, day) {

    let totalPrice;
    let price;

    if (day == 'Friday') {
        if (type == 'Students') {
            price = 8.45;
        }
        if (type == 'Business') {
            price = 10.90;
        }
        if (type == 'Regular') {
            price = 15;
        }
    }

    if (day == 'Saturday') {
        if (type == 'Students') {
            price = 9.80;
        }
        if (type == 'Business') {
            price = 15.60;
        }
        if (type == 'Regular') {
            price = 20;
        }
    }

    if (day == 'Sunday') {
        if (type == 'Students') {
            price = 10.46;
        }
        if (type == 'Business') {
            price = 16;
        }
        if (type == 'Regular') {
            price = 22.50;
        }
    }

    if (type == 'Students') {
        if (count >= 30) {
            totalPrice = (price * count) * 0.85;
        } else {
            totalPrice = price * count;
        }
    }
    if (type == 'Business') {
        if (count >= 100) {
            totalPrice = price * (count - 10);
        } else {
            totalPrice = price * count;
        }
    }
    if (type == 'Regular') {
        if (count >= 10 && count <= 20) {
            totalPrice = (price * count) * 0.95;
        } else {
            totalPrice = price * count;
        }
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

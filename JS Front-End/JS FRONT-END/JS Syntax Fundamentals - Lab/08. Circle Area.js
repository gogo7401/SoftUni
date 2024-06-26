function PrintCircleArea(num) {
    if (typeof (num) == "number") {
        console.log((Math.PI * num ** 2).toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof (num)}.`);
    }

}

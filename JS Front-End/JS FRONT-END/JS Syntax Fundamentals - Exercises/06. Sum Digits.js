function PrintSumDigits(num) {
    let sum = 0;
    let numString = num.toString();
    for (let index = 0; index < numString.length; index++) {
        sum += parseInt(numString[index]);
    }
    console.log(sum);
}

function PrintSameNumbers(num) {
    let strNumber = num.toString();
    let isSame = true;
    let sum = parseInt(strNumber[0]);
    for (let index = 0; index < strNumber.length - 1; index++) {
        if (strNumber[index] != strNumber[index + 1]) {
            isSame = false;
        }
        sum += parseInt(strNumber[index + 1]);
    }
    if (isSame) {
        console.log('true');
    } else {
        console.log('false');
    }
    console.log(sum);
}



PrintSameNumbers(2222222);
PrintSameNumbers(1234);

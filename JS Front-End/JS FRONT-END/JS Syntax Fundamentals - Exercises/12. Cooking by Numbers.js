function PrintCookingByNumbers(num, op1, op2, op3, op4, op5) {
    const arr = [op1, op2, op3, op4, op5];
    const start = parseInt(num);
    let result = start;

    for (let index = 0; index < arr.length; index++) {
        switch (arr[index]) {
            case 'chop':
                result /= 2;
                break;
            case 'dice':
                result = Math.sqrt(result);
                break;
            case 'spice':
                result += 1;
                break;
            case 'bake':
                result *= 3;
                break;
            case 'fillet':
                result = result - result*0.20;
                break;
        }
        console.log(result);
    }


}



PrintCookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');
PrintCookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');

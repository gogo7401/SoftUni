function Difference (arr){
    let diff = 0;
    let sumEven = 0;
    let sumOdd = 0; 

    for (const item of arr) {
        if (item % 2 === 0){
            sumEven += item;
        } else {
            sumOdd += item;
        }
    }

    diff = sumEven - sumOdd;

    console.log(diff);

}


Difference([1,2,3,4,5,6]);
Difference([3,5,7,9]);

function Solve(arr1, arr2, arr3) {
    let smallestNum = 0;
    let newArr = function (a, b) {
        if (a <= b) {
            return a;
        } else {
            return b;
        }
    }
 
    let first = newArr(arr1, arr2);

    if (first <= arr3) {
        smallestNum = first;
    } else {
        smallestNum = arr3;
    }


    console.log(smallestNum);
}

function Solve(arr1, arr2, arr3) {
    // let smallestNum = 0;
    // let newArr = function (a, b) {
    //     if (a <= b) {
    //         return a;
    //     } else {
    //         return b;
    //     }
    // }

    // let first = newArr(arr1, arr2);

    // if (first <= arr3) {
    //     smallestNum = first;
    // } else {
    //     smallestNum = arr3;
    // }


    // console.log(smallestNum);
     console.log(Math.min(arr1, arr2, arr3));
}


Solve(2,
    5,
    3
);
Solve(600,
    342,
    123
);
Solve(25,
    21,
    4
);
Solve(2,
    2,
    2
);

function Solve(arr, count) {
    for (let index = 0; index < count; index++) {
        arr.push(arr.shift()); 
    }

    console.log(arr.join(' ')); 
}


Solve([51, 47, 32, 61, 21], 2);
Solve([32, 21, 61, 1], 4);
Solve([2, 4, 15, 31], 5);

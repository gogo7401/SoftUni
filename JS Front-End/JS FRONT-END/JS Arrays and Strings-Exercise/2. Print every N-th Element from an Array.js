function Solve(arr, step) {
    let newArr = [];
    for (let index = 0; index < arr.length; index+=step) {
        newArr.push(arr[index]); 
    }

    return newArr;
}


Solve(['5', '20', '31', '4', '20'], 2);
Solve(['dsa', 'asd', 'test', 'tset'], 2);
Solve(['1', '2', '3', '4', '5'], 6);

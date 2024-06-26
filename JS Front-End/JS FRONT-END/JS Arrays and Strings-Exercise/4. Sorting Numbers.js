function Solve(arr) {
    let newArr = [];
    arr.sort((a, b) => { return a-b; });

    while (arr.length !== 0) {
        newArr.push(arr.shift());
        newArr.push(arr.pop());
    }
    return newArr;
    //console.log(newArr);
}
 

Solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);

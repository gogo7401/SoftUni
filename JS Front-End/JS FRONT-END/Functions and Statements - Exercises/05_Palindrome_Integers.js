function Solve(arr) {
    for (const item of arr) {
        const itemStr = item.toString();
        let isPalindrome = true;
        for (let index = 0; index < itemStr.length / 2; index++) {
            if (itemStr[index] != itemStr[itemStr.length - 1 - index]) {
                isPalindrome = false;
            }
        }
        console.log(isPalindrome);
    } 
}

====================================================

function Solve(arr) {
    for (const item of arr) {
        const itemStr = item.toString();
        const itemRevers = itemStr.split('').reverse().join('');
        console.log(itemStr === itemRevers);
    }
}


Solve([123, 323, 421, 121]);
Solve([32, 2, 232, 1010]);



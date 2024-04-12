function Solve(num) {
    const numLength = num / 2;
    let sum = 0;
    for (let index = 0; index <= numLength; index++) {
        if (num % index === 0) {
            sum += index;
        }
    }

    if (num === sum) {
        console.log("We have a perfect number!");
    } else {
        console.log("It's not so perfect.");
    }

}


Solve(6);
Solve(28);
Solve(1236498);



function Solve(input) {
    const inputStr = input.toString();
    let oddSum = 0;
    let evenSum = 0;

    for (let index = 0; index < inputStr.length; index++) {
        const element = inputStr[index];
        if (element % 2 === 0) {
            evenSum += Number(element);
        } else {
            oddSum += Number(element);
        }
    }
    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`)
}

Solve(1000435);
Solve(3495892137259234);



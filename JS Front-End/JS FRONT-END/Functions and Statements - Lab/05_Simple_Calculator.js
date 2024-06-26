function Solve(numOne, numTwo, operator) {
    const operators = {
        multiply: (numOne, numTwo) => numOne * numTwo,
        divide: (numOne, numTwo) => numOne / numTwo,
        add: (numOne, numTwo) => numOne + numTwo,
        subtract: (numOne, numTwo) => numOne - numTwo,
        
    }

    console.log(operators[operator](numOne, numTwo));
}





Solve(5,5,'multiply');
Solve(40,8,'divide');
Solve(12,19,'add');
Solve(50,13,'subtract');




function Solve(numOne, numTwo, numThree) {
    let count = 0;
    if (numOne < 0 ){
        count++;
    }
    if (numTwo < 0 ){
        count++;
    }
    if (numThree < 0 ){
        count++;
    }

    if (count % 2 === 0){
        console.log("Positive");
    } else {
        console.log("Negative");
    }
}





Solve(5,
    12,
    -15
);
Solve(-6,
    -12,
    14
);
Solve(-1,
    -2,
    -3
);
Solve(1,
    2,
    3
);




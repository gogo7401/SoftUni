function Solve(...elements) {
    let count = 0;
    for (const item of elements) {
        if (item < 0) {count++;}
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




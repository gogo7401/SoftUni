function Solve(int1, int2, int3) {

    function sum(a, b) {
        return a + b;
    }

    const result = function substract(int1, int2, int3) {
        const sumAB = sum(int1, int2);
        return sumAB - int3;
    }

    console.log(result(int1, int2, int3));
} 
 

Solve(23,
    6,
    10
);
Solve(1,
    17,
    30
);
Solve(42,
    58,
    100
);

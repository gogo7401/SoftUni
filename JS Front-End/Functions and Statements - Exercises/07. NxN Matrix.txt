function Solve(num) {
    const row = (num + ' ').repeat(num).trimEnd();
    for (let col = 0; col < num; col++) {
        console.log(row);
    }
}


 Solve(3);
//  Solve(7);
//  Solve(2);



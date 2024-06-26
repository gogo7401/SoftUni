function Solve(percent) {
    const count = percent / 10;
    let arr = ['.','.','.','.','.','.','.','.','.','.'];
    for (let i = 0; i < count; i++) {
        arr[i] = '%';
    }
    
    if (percent != 100){
        console.log(`${percent}% [${arr.join('')}]`);
        console.log('Still loading...');
    } else {
        console.log(`${percent}% Complete!`);
        console.log(`[${arr.join('')}]`);
    } 
}


Solve(30);
Solve(50);
Solve(100);
Solve(0);



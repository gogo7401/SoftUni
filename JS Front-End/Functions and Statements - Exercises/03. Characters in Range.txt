function Solve(c1, c2) {
    let start = c1.charCodeAt();
    let end = c2.charCodeAt();
    let result = [];

    if ((end - start) < 0) {
        let temp = start;
        start = end;
        end = temp;
    }

    start++;
    end--;

    for (let index = start; index <= end; index++) {
        result.push(String.fromCharCode(index));

    }

    console.log(result.join(' '));

}

Solve('a', 'd');
Solve('#', ':');
Solve('C', '#');


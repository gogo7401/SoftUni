function Solve(word, text) {
    let output = `${word} not found!`;
    let words = text.split(' ');
    for (const item of words) {
        if (item.toLowerCase() === word.toLowerCase()) {
            output = word;
        }
    }

    console.log(output);


}




Solve('javascript', 'is the Javascript best programming language');
Solve('javascript', 'is the javascriptbest programming language');
Solve('python', 'JavaScript is the best programming language');
// Solve(['1', '2', '3', '4', '5'], 6);

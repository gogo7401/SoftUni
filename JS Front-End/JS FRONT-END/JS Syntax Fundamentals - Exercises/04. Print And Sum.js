function PrintNumberAndSum(start, end) {
    let numbers = null;
    let sum = 0;
for (let index = start; index <= end; index++) {
    numbers = numbers + index + " ";
    sum = sum + index;
}

console.log(numbers);
console.log(`Sum: ${sum}`);

}

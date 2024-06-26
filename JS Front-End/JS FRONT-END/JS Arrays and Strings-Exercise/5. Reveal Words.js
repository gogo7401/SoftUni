function Solve(input, template) {
    let words = input.split(", ").sort((a,b)=> b.length - a.length);


    for (const item of words) {
        let len = item.length;
        let stars = '*'.repeat(len);
        while (template.includes(stars)) {
           template = template.replace(stars, item); 
        }

    }

    // return newArr;
    console.log(template);
    // console.log(words);


}




Solve('great', 'softuni is ***** place for learning new programming languages');
Solve('great, learning', 'softuni is ***** place for ******** new programming languages');
// Solve(['1', '2', '3', '4', '5'], 6);

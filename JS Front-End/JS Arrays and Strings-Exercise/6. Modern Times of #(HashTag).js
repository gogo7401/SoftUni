function Solve(text) {
    let regExp = new RegExp('#[A-Za-z]+', 'gm');

    let matches = text.match(regExp);
    for (let item of matches) {
        item = item.replace('#', '');
        console.log(item);
    }

}




Solve('Nowadays everyone uses # to tag a #special word in #socialMedia');
Solve('The symbol # is known #variously in English-speaking #regions as the #number sign');
// Solve(['1', '2', '3', '4', '5'], 6);

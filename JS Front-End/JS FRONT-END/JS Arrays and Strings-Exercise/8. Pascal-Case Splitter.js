function Solve(text) {
    let regExp = new RegExp('[A-Z][a-z]*', 'gm');
let matches = text.match(regExp);
    console.log(matches.join(', '));
}




Solve('SplitMeIfYouCanHaHaYouCantOrYouCan');
Solve('HoldTheDoor');
Solve('ThisIsSoAnnoyingToDo');

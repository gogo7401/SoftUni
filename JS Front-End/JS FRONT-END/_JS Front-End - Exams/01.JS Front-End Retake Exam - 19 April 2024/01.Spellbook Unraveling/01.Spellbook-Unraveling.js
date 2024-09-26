function solve(informationArray) {
    let mysteriousString = informationArray.shift();
    let encodedSpell = '';

    let commands = informationArray.shift();
    while (commands !== 'End') {
        let [command, firstArg, secondArg] = commands.split('!');
        //console.log(`${command}, ${firstArg}, ${secondArg}`)
        switch (command) {
            case 'RemoveEven':
                // for (let i = 0; i < mysteriousString.length; i++) {
                //     if (i % 2 === 0) {
                //         encodedSpell += mysteriousString.substring(i, i + 1);
                //     }
                // }
                mysteriousString = mysteriousString.split('').filter((char, index) => index % 2 === 0).join('');
                // mysteriousString = encodedSpell;
                // encodedSpell = '';
                console.log(mysteriousString);
                break;
            case 'TakePart':
                const numArg1 = Number(firstArg);
                const numArg2 = Number(secondArg);
                if (numArg1 > 0 || numArg2 > 0) {
                    // encodedSpell = mysteriousString.substring(Number(firstArg), Number(secondArg));
                    mysteriousString = mysteriousString.slice(numArg1, numArg2)
                    // mysteriousString = encodedSpell;
                    // encodedSpell = '';
                }
                console.log(mysteriousString);
                break;
            case 'Reverse':
                if (mysteriousString.includes(firstArg)) {
                    const reversedSub = firstArg.split('').reverse().join('');
                    encodedSpell = mysteriousString.replace(firstArg, '').concat(reversedSub);
                    mysteriousString = encodedSpell;
                    encodedSpell = '';
                    console.log(mysteriousString);
                } else {
                    console.log('Error');
                }
                // if (mysteriousString.includes(firstArg)) {
                //     let reversedSub = firstArg.split('').reverse().join('');
                //     mysteriousString = mysteriousString.replace(firstArg, '');
                //     mysteriousString += reversedSub;
                //     console.log(mysteriousString);
                // } else {
                //     console.log('Error');
                // }
                break;
        }
        commands = informationArray.shift();
    }

    console.log(`The concealed spell is: ${mysteriousString}`);
}




// solve(["asAsl2adkda2mdaczsa",
//     "RemoveEven",
//     "TakePart!1!9",
//     "Reverse!maz",
//     "End"]);

solve(["hZwemtroiui5tfone1haGnanbvcaploL2u2a2n2i2m",
    "TakePart!31!43",
    "RemoveEven",
    "Reverse!anim",
    "Reverse!sad",
    "End"]);
// solve(["hZwemtroiui5tfone1haGnanbvcaploL2u2a2n2i2m",
//     "TakePart!31!42",
//     "RemoveEven",
//     "Reverse!anim",
//     "Reverse!sad",
//     "End"]);


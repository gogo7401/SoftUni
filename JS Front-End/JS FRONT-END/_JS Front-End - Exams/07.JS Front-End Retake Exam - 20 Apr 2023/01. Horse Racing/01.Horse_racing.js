function solve(input) {
    const rankingList = input.shift().split('|');

    let line = input.shift();
    while (line !== 'Finish') {
        let [command, horseArg1, horseArg2] = line.split(' ');
        switch (command) {
            case 'Retake':
                let overtakingHorse = horseArg1;
                let overtakenHorse = horseArg2;

                const indexOfOvertakingHorse = rankingList.indexOf(overtakingHorse);
                const indexOfOvertakenHorse = rankingList.indexOf(overtakenHorse);

                if (indexOfOvertakingHorse < indexOfOvertakenHorse) {
                    rankingList.splice(indexOfOvertakingHorse, 1, overtakenHorse);
                    rankingList.splice(indexOfOvertakenHorse, 1, overtakingHorse);

                    console.log(`${overtakingHorse} retakes ${overtakenHorse}.`);
                }
                break;

            case 'Trouble':
                let horseName = horseArg1;
                const indexOfHorseName = rankingList.indexOf(horseName);

                if (indexOfHorseName > 0) {
                    rankingList.splice(indexOfHorseName, 1);
                    rankingList.splice(indexOfHorseName - 1, 0, horseName);
                    console.log(`Trouble for ${horseName} - drops one position.`);
                }
                break;

            case 'Rage':
                let horseNameRage = horseArg1;
                const indexOfHorseNameRage = rankingList.indexOf(horseNameRage);
                const position = Math.min((indexOfHorseNameRage + 2), rankingList.length - 1);
                rankingList.splice(indexOfHorseNameRage, 1);
                rankingList.splice(position, 0, horseNameRage);
                console.log(`${horseNameRage} rages 2 positions ahead.`);
                break;

            case 'Miracle':
                const lastHorseName = rankingList.shift();
                rankingList.push(lastHorseName);
                console.log(`What a miracle - ${lastHorseName} becomes first.`);
                break;
        }




        line = input.shift();
    }

    console.log(rankingList.join('->'));
    const horse1 = rankingList[rankingList.length - 1];
    console.log(`The winner is: ${horse1}`);
}

// solve(['Bella|Alexia|Sugar',
//     'Retake Alexia Sugar',
//     'Rage Bella',
//     'Trouble Bella',
//     'Finish']);

// solve(['Onyx|Domino|Sugar|Fiona',
//     'Trouble Onyx',
//     'Retake Onyx Sugar',
//     'Rage Domino',
//     'Miracle',
//     'Finish']);

solve(['Fancy|Lilly',
    'Retake Lilly Fancy',
    'Trouble Lilly',
    'Trouble Lilly',
    'Finish',
    'Rage Lilly']);

function solve(input) {
    const heroCount = input.shift();
    const heroesList = {};

    // "{superhero name}-{superpower}-{energy}"
    for (let i = 0; i < heroCount; i++) {
        const [superheroName, superpowerString, energy] = input[i].split('-');
        let superpower = superpowerString.split(',');
        if (energy > 100) { energy = 100 }
        if (energy > 0) {
            heroesList[superheroName] = { 'superpower': superpower, 'energy': energy };
        } else {
            continue;
        }
    }

    let line = input.shift();
    let useSuperpower, energyRequired, trainingEnergy, newSuperpower;

    while (line !== 'Evil Defeated!') {
        const [command, superheroName, arg1, arg2] = line.split(' * ');
        switch (command) {
            case 'Use Power':
                useSuperpower = arg1;
                energyRequired = Number(arg2);
                if (heroesList[superheroName].superpower.includes(useSuperpower) && (heroesList[superheroName].energy >= energyRequired)) {
                    heroesList[superheroName].energy -= energyRequired;
                    // if (heroesList[superheroName].energy < 0) {heroesList[superheroName].energy = 0;}
                    console.log(`${superheroName} has used ${useSuperpower} and now has ${heroesList[superheroName].energy} energy!`);
                } else {
                    console.log(`${superheroName} is unable to use ${useSuperpower} or lacks energy!`);
                }
                break;

            case 'Train':
                trainingEnergy = Number(arg1);
                let superheroCurrentEnergy = Number(heroesList[superheroName].energy);
                if (superheroCurrentEnergy < 100) {
                    if (superheroCurrentEnergy + trainingEnergy > 100) {
                        trainingEnergy = 100 - superheroCurrentEnergy;
                    }
                    heroesList[superheroName].energy = superheroCurrentEnergy + trainingEnergy;
                    console.log(`${superheroName} has trained and gained ${trainingEnergy} energy!`);
                } else {
                    console.log(`${superheroName} is already at full energy!`);
                }
                break;

            case 'Learn':
                newSuperpower = arg1;
                if (heroesList[superheroName].superpower.includes(newSuperpower)) {
                    console.log(`${superheroName} already knows ${newSuperpower}.`);
                } else {
                    heroesList[superheroName].superpower.push(newSuperpower);
                    console.log(`${superheroName} has learned ${newSuperpower}!`);
                }
                break;
        }


        line = input.shift();
    }

    for (const superheroName in heroesList) {
        console.log(`Superhero: ${superheroName}`);
        // - Superpowers: {superpower 1, superpower 2, ...}
        console.log(`- Superpowers: ${heroesList[superheroName].superpower.join(', ')}`);
        // - Energy: {current energy}
        console.log(`- Energy: ${heroesList[superheroName].energy}`);
    }

}


// solve(
//     [
//         "3",
//         "Iron Man-Repulsor Beams,Flight-80",
//         "Thor-Lightning Strike,Hammer Throw-10",
//         "Hulk-Super Strength-60",
//         "Use Power * Iron Man * Flight * 30",
//         "Train * Thor * 20",
//         "Train * Hulk * 50",
//         "Learn * Hulk * Thunderclap",
//         "Use Power * Hulk * Thunderclap * 70",
//         "Evil Defeated!"
//     ]
// );

// solve(
//     [
//         "2",
//         "Iron Man-Repulsor Beams,Flight-20",
//         "Thor-Lightning Strike,Hammer Throw-100",
//         "Train * Thor * 20",
//         "Use Power * Iron Man * Repulsor Beams * 30",
//         "Evil Defeated!"
//     ]
// );

solve(
    [
        "2",
        "Iron Man-Repulsor Beams,Flight-100",
        "Thor-Lightning Strike,Hammer Throw-50",
        "Train * Thor * 20",
        "Learn * Thor * Hammer Throw",
        "Use Power * Iron Man * Repulsor Beams * 30",
        "Evil Defeated!"
    ]
);

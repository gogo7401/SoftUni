function solve(input) {
    const astroCount = input.shift();
    const astronauts = {};

    for (let i = 0; i < astroCount; i++) {
        const [name, oxygen, energy] = input[i].split(' ');
        if ((Number(oxygen) >= 0 && Number(oxygen) <= 100) && (Number(energy) >= 0 && Number(energy) <= 200)) {
            astronauts[name] = { oxygen: Number(oxygen), energy: Number(energy) };
        } else {
            continue;
        }
    }

    let line = input.shift();
    while (line !== 'End') {
        const [command, astronautName, arg] = line.split(' - ');
        let amountOxygen, amountEnergy, amountRecoveredOxygen, amountRecoveredEnergy;
        switch (command) {
            case 'Explore':
                let energyNeeded = arg;
                let energyReserves = astronauts[astronautName].energy;
                if (energyReserves >= energyNeeded) {
                    astronauts[astronautName].energy -= energyNeeded;
                    console.log(`${astronautName} has successfully explored a new area and now has ${astronauts[astronautName].energy} energy!`);
                } else {
                    console.log(`${astronautName} does not have enough energy to explore!`);
                }
                break;

            case 'Refuel':
                amountEnergy = Number(arg);
                amountRecoveredEnergy = Math.min(amountEnergy, 200 - astronauts[astronautName].energy);
                if (astronauts[astronautName].energy + amountEnergy > 200){
                    astronauts[astronautName].energy = 200;
                } else {
                    astronauts[astronautName].energy += amountEnergy;
                }
                console.log(`${astronautName} refueled their energy by ${amountRecoveredEnergy}!`);
                break;

            case 'Breathe':
                amountOxygen = Number(arg);
                amountRecoveredOxygen = Math.min(amountOxygen, 100 - astronauts[astronautName].oxygen);
                if (astronauts[astronautName].oxygen + amountOxygen > 100){
                    astronauts[astronautName].oxygen = 100;
                } else {
                    astronauts[astronautName].oxygen += amountOxygen;
                }
                console.log(`${astronautName} took a breath and recovered ${amountRecoveredOxygen} oxygen!`);
                break;
        }


        line = input.shift();
    }

    for (const name in astronauts) {
        console.log(`Astronaut: ${name}, Oxygen: ${astronauts[name].oxygen}, Energy: ${astronauts[name].energy}`);
    }

}

// solve(['3',
//     'John 50 120',
//     'Kate 80 180',
//     'Rob 70 150',
//     'Explore - John - 50',
//     'Refuel - Kate - 30',
//     'Breathe - Rob - 20',
//     'End']
// );

  solve(['4',
    'Alice 60 100',
    'Bob 40 80',
    'Charlie 70 150',
    'Dave 80 180',
    'Explore - Bob - 60',
    'Refuel - Alice - 30',
    'Breathe - Charlie - 50',
    'Refuel - Dave - 40',
    'Explore - Bob - 40',
    'Breathe - Charlie - 30',
    'Explore - Alice - 40',
    'End']
);

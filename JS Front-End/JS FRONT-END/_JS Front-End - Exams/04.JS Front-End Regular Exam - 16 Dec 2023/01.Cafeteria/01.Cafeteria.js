function solve(input) {
    const baristaCount = Number(input.shift());
    const baristaTeam = [];
    for (let i = 0; i < baristaCount; i++) {
        const [name, shift, coffeeTypes] = input[i].split(' ');
        const barista = { name, shift, coffeeTypes: coffeeTypes.split(',') };
        baristaTeam.push(barista);
    }

    let line = input.shift();
    while (line !== 'Closed') {
        let [command, baristaName, arg1, arg2] = line.split(' / ');
        let targetBarista = baristaTeam.filter((barista) => barista.name === baristaName)[0];
        switch (command) {
            case 'Prepare':
                const shift = arg1;
                const coffeeType = arg2;
                // targetBarista = baristaTeam.filter((barista) => barista.name === baristaName)[0];
                // console.log(targetBarista);
                if ((targetBarista.shift === shift) && (targetBarista.coffeeTypes.includes(coffeeType))) {
                    console.log(`${baristaName} has prepared a ${coffeeType} for you!`);
                } else {
                    console.log(`${baristaName} is not available to prepare a ${coffeeType}.`);
                }
                break;

            case 'Change Shift':
                const newShift = arg1;
                // targetBarista = baristaTeam.filter((barista) => barista.name === baristaName)[0];
                targetBarista.shift = newShift;
                //console.log(targetBarista.shift);
                console.log(`${baristaName} has updated his shift to: ${newShift}`);
                break;

            case 'Learn':
                const newCoffeeType = arg1;
                if (targetBarista.coffeeTypes.includes(newCoffeeType)) {
                    console.log(`${baristaName} knows how to make ${newCoffeeType}.`);
                } else {
                    targetBarista.coffeeTypes.push(newCoffeeType);
                    //console.log(targetBarista.coffeeTypes);
                    console.log(`${baristaName} has learned a new coffee type: ${newCoffeeType}.`);
                }

                break;

        }


        line = input.shift();
    }

    baristaTeam.forEach(barista => {
        console.log(`Barista: ${barista.name}, Shift: ${barista.shift}, Drinks: ${barista.coffeeTypes.join(', ')}`);
    });

}

// solve(['3',
//     'Alice day Espresso,Cappuccino',
//     'Bob night Latte,Mocha',
//     'Carol day Americano,Mocha',
//     'Prepare / Alice / day / Espresso',
//     'Change Shift / Bob / night',
//     'Learn / Carol / Latte',
//     'Learn / Bob / Latte',
//     'Prepare / Bob / night / Latte',
//     'Closed']);


solve(['4',
    'Alice day Espresso,Cappuccino',
    'Bob night Latte,Mocha',
    'Carol day Americano,Mocha',
    'David night Espresso',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / day',
    'Learn / Carol / Latte',
    'Prepare / Bob / night / Latte',
    'Learn / David / Cappuccino',
    'Prepare / Carol / day / Cappuccino',
    'Change Shift / Alice / night',
    'Learn / Bob / Mocha',
    'Prepare / David / night / Espresso',
    'Closed']);

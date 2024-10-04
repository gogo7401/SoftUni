function solve(input) {
    const riderCount = input.shift();
    const riders = {};
    const maxCapacity = 100;
    for (let i = 0; i < riderCount; i++) {
        let [name, fuelCapacity, position] = input[i].split("|");
        if (Number(fuelCapacity) > maxCapacity) {
            fuelCapacity = maxCapacity;
        }
        riders[name] = { fuelCapacity: Number(fuelCapacity), position: Number(position) };
    }

    let line = input.shift();
    let minFuel, changedPosition, rider1, rider2;
    while (line !== 'Finish') {
        let [command, rider, arg1, arg2] = line.split(' - ');

        switch (command) {
            case 'StopForFuel':
                minFuel = Number(arg1);
                changedPosition = Number(arg2);
                if (riders[rider].fuelCapacity < minFuel) {
                    riders[rider].position = changedPosition;
                    riders[rider].fuelCapacity = maxCapacity; // TODO ??
                    console.log(`${rider} stopped to refuel but lost his position, now he is ${changedPosition}.`);
                } else {
                    console.log(`${rider} does not need to stop for fuel!`);
                }
                break;

            case 'Overtaking':
                rider1 = rider;
                rider2 = arg1;
                if (riders[rider1].position < riders[rider2].position) {
                    let tempPosition = riders[rider1].position;
                    riders[rider1].position = riders[rider2].position;
                    riders[rider2].position = tempPosition;
                    console.log(`${rider1} overtook ${rider2}!`);
                }

                break;

            case 'EngineFail':
                let lapsLeft = arg1;
                if (riders.hasOwnProperty(rider)) {
                    delete riders[rider];
                    console.log(`${rider} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
                }
                break;
        }

        line = input.shift();
    }

    for (const rider in riders) {
        console.log(`${rider}`);
        console.log(`  Final position: ${riders[rider].position}`);
    }
}

solve(["3",
    "Valentino Rossi|100|1",
    "Marc Marquez|90|2",
    "Jorge Lorenzo|80|3",
    "StopForFuel - Valentino Rossi - 50 - 1",
    "Overtaking - Marc Marquez - Jorge Lorenzo",
    "EngineFail - Marc Marquez - 10",
    "Finish"]);

function solve(inputArray) {
    const numberOfHeros = Number(inputArray.shift());
    const heroes = [];

    for (let i = 0; i < numberOfHeros; i++) {
        const [heroName, heroHealth, heroBullets] = inputArray.shift().split(' ');
        heroes.push({ name: heroName, health: Number(heroHealth), bullets: Number(heroBullets) });
    }

    let operation = inputArray.shift();

    while (operation !== "Ride Off Into Sunset") {
        const [command, heroName, argOne, argTwo] = operation.split(' - ');
        const hero = heroes.find(h => h.name === heroName);

        switch (command) {
            case "FireShot":
                if (heroes.some(h => h.name === heroName)) {
                    // const hero = heroes.find(h => h.name === heroName);
                    const targetHero = argOne;
                    if (hero.bullets > 0) {
                        hero.bullets--;
                        console.log(`${hero.name} has successfully hit ${targetHero} and now has ${hero.bullets} bullets!`);
                    } else {
                        console.log(`${hero.name} doesn't have enough bullets to shoot at ${targetHero}!`);
                    }
                }
                break;
            case "TakeHit":
                const damage = Number(argOne);
                const attacker = argTwo;

                hero.health -= damage;
                if (hero.health <= 0) {
                    console.log(`${hero.name} was gunned down by ${attacker}!`);
                    heroes.splice(heroes.indexOf(hero), 1);
                } else {
                    console.log(`${hero.name} took a hit for ${damage} HP from ${attacker} and now has ${hero.health} HP!`);
                }
                break;
            case "Reload":
                if (hero.bullets < 6) {
                    console.log(`${hero.name} reloaded ${6 - hero.bullets} bullets!`);
                    hero.bullets = 6;
                } else {
                    console.log(`${hero.name}'s pistol is fully loaded!`);
                }
                break;
            case "PatchUp":
                const amount = Number(argOne);
                let amountRecovered = 0;
                if (hero.health < 100) {
                    if ((hero.health - 100 + amount) <= 0) {
                        amountRecovered = amount;
                        hero.health += amount;
                    } else {
                        amountRecovered = 100 - hero.health;
                        hero.health = 100;
                    }
                    console.log(`${hero.name} patched up and recovered ${amountRecovered} HP!`);
                } else {
                    console.log(`${hero.name} is in full health!`);
                }
                break;
        }
        operation = inputArray.shift();
    }



    heroes.forEach(hero => {
        console.log(`${hero.name}`);
        console.log(` HP: ${hero.health}`);
        console.log(` Bullets: ${hero.bullets}`);
    });
}

solve(["2",
    "Jesse 100 4",
    "Walt 100 5",
    "FireShot - Jesse - Bandit",
    "TakeHit - Walt - 30 - Bandit",
    "PatchUp - Walt - 20",
    "Reload - Jesse",
    "Ride Off Into Sunset"]);


// solve(["2",
//     "Gus 100 0",
//     "Walt 100 6",
//     "FireShot - Gus - Bandit",
//     "TakeHit - Gus - 100 - Bandit",
//     "Reload - Walt",
//     "Ride Off Into Sunset"]);


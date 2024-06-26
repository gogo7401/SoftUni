function Solve(arrInput) {
  let heroes = [];

  for (const item of arrInput) {
    let [name, level, items] = item.split(" / ");
    let hero = { name, level, items: items.split(", ") };
    heroes.push(hero);
  }

  let sortedHeroes = heroes
   .sort((a, b) => a.level - b.level);

   for (const hero of sortedHeroes) {
     console.log(`Hero: ${hero.name}\nlevel => ${hero.level}\nitems => ${hero.items.join(", ")}`);
    
   }
}

Solve([
  "Isacc / 25 / Apple, GravityGun",
  "Derek / 12 / BarrelVest, DestructionSword",
  "Hes / 1 / Desolator, Sentinel, Antara",
]);
Solve([
  "Batman / 2 / Banana, Gun",
  "Superman / 18 / Sword",
  "Poppy / 28 / Sentinel, Antara",
]);

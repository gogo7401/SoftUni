function Solve(arrInput) {
  let persons = {};

  for (const item of arrInput) {
    const employeeName = item;
    const personalNum = item.length;
    persons[employeeName] = personalNum;

  }

  for (const name in persons) {
    console.log(`Name: ${name} -- Personal Number: ${persons[name]}`);
  }


}

Solve([
  "Silas Butler",
  "Adnaan Buckley",
  "Juan Peterson",
  "Brendan Villarreal",
]);
Solve(["Samuel Jackson", "Will Smith", "Bruce Willis", "Tom Holland"]);

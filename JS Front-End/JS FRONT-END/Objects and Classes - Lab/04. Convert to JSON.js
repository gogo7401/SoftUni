function Solve(firstName, lastName, hairColor) {
  const obj = {
    name: firstName,
    lastName: lastName,
    hairColor: hairColor,
  };
  let jsn = JSON.stringify(obj);

  console.log(jsn);
}

Solve("George", "Jones", "Brown");

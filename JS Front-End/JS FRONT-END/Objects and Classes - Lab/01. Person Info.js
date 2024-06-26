function Solve(firstName, lastName, age) {
  age = Number(age);
  const person = {firstName: firstName, lastName: lastName, age: age};

  return person;
}

console.log(Solve("Peter", "Pan", "20"));

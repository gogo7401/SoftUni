function Solve(arrInput) {
  let phoneBook = {};

  for (const item of arrInput) {
    let [name, phone] = item.split(" ");
    phoneBook[name] = phone;
  }

  for (const key in phoneBook) {
    console.log(`${key} -> ${phoneBook[key]}`);
  }
}

Solve([
  "Tim 0834212554",
  "Peter 0877547887",
  "Bill 0896543112",
  "Tim 0876566344",
]);

function Solve(arrInput) {
  let addressBook = {};

  for (const item of arrInput) {
    let [personName, address] = item.split(":");
    addressBook[personName] = address;
  }

  let entries = Object.entries(addressBook);
  let addressBookSorted = entries.sort((a, b) => {
    return a[0].localeCompare(b[0]);
  });

  for (const item of addressBookSorted) {
    console.log(`${item[0]} -> ${item[1]}`);
  }
}

Solve([
  "Tim:Doe Crossing",
  "Bill:Nelson Place",
  "Peter:Carlyle Ave",
  "Bill:Ornery Rd",
]);

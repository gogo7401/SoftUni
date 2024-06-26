function Solve(jsn) {
  let obj = JSON.parse(jsn);
  for (const key in obj) {
    console.log(`${key}: ${obj[key]}`);
  }
}

Solve('{"name": "George", "age": 40, "town": "Sofia"}');

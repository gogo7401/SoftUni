function Solve(arrInput) {
  
  let arr = [];

  for (const item of arrInput) {
    let towns = {};
    let [town,latitude,longitude] = item.split('|');
    let latitudeFixed = Number(latitude);
    let longitudeFixed = Number(longitude);
    towns.town = town.trimEnd();
    towns.latitude = latitudeFixed.toFixed(2);
    towns.longitude = longitudeFixed.toFixed(2);
    arr.push(towns);
  }

  for (const item of arr) {
    console.log(item);
  }
}

Solve(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"]);
Solve(['Plovdiv | 136.45 | 812.575']);

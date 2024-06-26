function Solve(arrInput) {
  let meetings = {};

  for (const item of arrInput) {
    let [weekday, personName] = item.split(" ");
    if (meetings.hasOwnProperty(weekday)) {
      console.log(`Conflict on ${weekday}!`);
    } else {
      meetings[weekday] = personName;
      console.log(`Scheduled for ${weekday}`);
    }
  }

  for (const key in meetings) {
    console.log(`${key} -> ${meetings[key]}`);
  }
}

Solve(["Monday Peter", "Wednesday Bill", "Monday Tim", "Friday Tim"]);

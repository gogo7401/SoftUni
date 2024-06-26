function Solve(arrInput) {
  class Song {
    constructor(typeList, name, time) {
      this.typeList = typeList;
      this.name = name;
      this.time = time;
    }
  }

  let playList = [];

  for (let index = 1; index <= arrInput[0]; index++) {
    let [typeList, name, time] = arrInput[index].split("_");
    let song = new Song(typeList, name, time);
    playList.push(song);
  }

  const typeForPrint = arrInput[arrInput.length - 1];

  if (typeForPrint === "all") {
    for (const song of playList) {
      console.log(song.name);
    }
  } else {
    for (const song of playList) {
      if (song.typeList === typeForPrint) {
        console.log(song.name);
      }
    }
  }
}

Solve([
  3,
  "favourite_DownTown_3:14",
  "favourite_Kiss_4:16",
  "favourite_Smooth Criminal_4:01",
  "favourite",
]);
Solve([
  4,
  "favourite_DownTown_3:14",
  "listenLater_Andalouse_3:24",
  "favourite_In To The Night_3:58",
  "favourite_Live It Up_3:48",
  "listenLater",
]);
Solve([2, "like_Replay_3:15", "ban_Photoshop_3:48", "all"]);

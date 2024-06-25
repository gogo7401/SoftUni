function Solve(text) {
  let output = [];
  const arrWords = text.toString().toLowerCase().split(" ");
  while (arrWords.length > 0) {
    let count = 1;
    const currentWord = arrWords.shift();
    while (arrWords.findIndex((x) => x === currentWord) >= 0) {
      count++;
      arrWords.splice(arrWords.findIndex((x) => x === currentWord), 1);
    }
    if (count % 2 != 0){
      output.push(currentWord);
    }
  }
  console.log(output.join(" "));
}

Solve("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
Solve("Cake IS SWEET is Soft CAKE sweet Food");

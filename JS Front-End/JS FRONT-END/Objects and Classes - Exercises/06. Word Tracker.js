function Solve(arrInput) {
  let output = [];
  let targetWords, arrContent;
  [targetWords, ...arrContent] = arrInput;
  let arrTargetWords = targetWords.split(" ");
  for (const word of arrTargetWords) {
    let count = 0;
    for (const element of arrContent) {
      if (element === word) {
        count++;
      }
    }
    const obj = {word: word, count: count};
    output.push(obj);
  }
  const orderedOutput = output.sort((a,b) => b.count - a.count);

  for (const item of orderedOutput) {
    console.log(`${item.word} - ${item.count}`);
  }

  }

Solve([
  "this sentence",
  "In",
  "this",
  "sentence",
  "you",
  "have",
  "to",
  "count",
  "the",
  "occurrences",
  "of",
  "the",
  "words",
  "this",
  "and",
  "sentence",
  "because",
  "this",
  "is",
  "your",
  "task",
]);
Solve([
  "is the",
  "first",
  "sentence",
  "Here",
  "is",
  "another",
  "the",
  "And",
  "finally",
  "the",
  "the",
  "sentence",
]);

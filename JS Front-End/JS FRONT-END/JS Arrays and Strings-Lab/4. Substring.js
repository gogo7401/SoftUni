function PrintSubstring (text, startingIndex , count){
    let sub = text.substring(startingIndex, startingIndex + count);

    console.log(sub);

}


PrintSubstring('ASentence', 1, 8);
PrintSubstring('SkipWord', 4, 7);

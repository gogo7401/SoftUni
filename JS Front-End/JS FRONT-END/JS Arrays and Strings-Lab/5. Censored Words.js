function CensoredWords (text, word){
    while (text.includes(word)){
        text = text.replace(word, '*'.repeat(word.length))
    }

    console.log(text);


}


CensoredWords('A small sentence with some words', 'small');
CensoredWords('Find the hidden word hidden', 'hidden');

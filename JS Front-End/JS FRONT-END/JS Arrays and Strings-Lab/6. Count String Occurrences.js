function CountString(text, word) {
    let count = 0;
    let words = text.split(/[ .:;?!~,`"&|()<>{}\[\]\r\n/\\]+/);
for (const item of words) {
    if (item === word){
        count ++;
    }
}

    console.log(count);


}


CountString('This is a word and it also is a sentence', 'is');
CountString('softuni is great place for learning new programming languages', 'softuni');

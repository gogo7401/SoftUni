function Rev(count, arr){
    
    let newArr = arr.slice(0,count);
    newArr.reverse();
    console.log(newArr.join(' '));

}


Rev(3, [10, 20, 30, 40, 50]);

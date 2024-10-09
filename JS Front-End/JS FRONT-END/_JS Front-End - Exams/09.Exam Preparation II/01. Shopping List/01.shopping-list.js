function solve(input) {
    let products = input.shift().split('!');

    let line = input.shift();
    while (line !== 'Go Shopping!') {
        let [command, firstArg, secondArg] = line.split(' ');

        let item, oldItem, newItem;
        switch (command) {
            case 'Urgent':
                item = firstArg;
                if (!products.includes(item)) { 
                    products.unshift(item);
                }
                break;
            
            case 'Unnecessary':
                item = firstArg;
                products = products.filter((el) => el !== item);
                break;
            
            case 'Correct':
                oldItem = firstArg;
                newItem = secondArg;
                products = products.map((el) => el === oldItem? newItem : el);
                break;
            
            case 'Rearrange':
                item = firstArg;
                let index = products.indexOf(item);
                if (index >= 0) {
                    products.splice(index, 1);
                    products.push(item);
                }
                break;
        
        }

        line = input.shift();
    }

    console.log(products.join(', '));

}

// solve(["Tomatoes!Potatoes!Bread",
//     "Unnecessary Milk",
//     "Urgent Tomatoes",
//     "Go Shopping!"]);

solve(["Milk!Pepper!Salt!Water!Banana",
    "Urgent Salt",
    "Unnecessary Grapes",
    "Correct Pepper Onion",
    "Rearrange Grapes",
    "Correct Tomatoes Potatoes",
    "Go Shopping!"]);

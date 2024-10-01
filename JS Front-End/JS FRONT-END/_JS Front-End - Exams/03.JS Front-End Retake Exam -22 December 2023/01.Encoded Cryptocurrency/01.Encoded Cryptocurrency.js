function solve(input) {
    let encodedMessage = input.shift();

    for (let i = 0; i < input.length; i++) {
        if (input[i] === 'Buy') {
            console.log(`The cryptocurrency is: ${encodedMessage}`);
            return;
        }
        let [command, arg1, arg2] = input[i].split('?');
        switch (command) {
            case "TakeEven":
                encodedMessage = Array.from(encodedMessage).filter((c, index) => index % 2 === 0).join('');
                console.log(encodedMessage);
                break;

            case "ChangeAll":
                encodedMessage = encodedMessage.replace(new RegExp(arg1, 'g'), arg2);
                console.log(encodedMessage);
                break;

            case "Reverse":
                if (encodedMessage.includes(arg1)) {
                    encodedMessage = encodedMessage.replace(arg1, '');
                    encodedMessage = encodedMessage.concat(Array.from(arg1).reverse().join(''));
                    console.log(encodedMessage);
                } else {
                    console.log("error");
                }

                break;
        }

    }
}


// solve(["z2tdsfndoctsB6z7tjc8ojzdngzhtjsyVjek!snfzsafhscs",
//     "TakeEven",
//     "Reverse?!nzahc",
//     "ChangeAll?m?g",
//     "Reverse?adshk",
//     "ChangeAll?z?i",
//     "Buy",
//     "TakeEven"]);

solve(["PZDfA2PkAsakhnefZ7aZ",
    "TakeEven",
    "TakeEven",
    "TakeEven",
    "ChangeAll?Z?X",
    "ChangeAll?A?R",
    "Reverse?PRX",
    "Buy"]);        

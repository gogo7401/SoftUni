function Solve(pass) {
    let isValid = true;
    // "Password must be between 6 and 10 characters"
    function symbolsBetween6And10(pass) {
        if (pass.length < 6 || pass.length > 10) {
            console.log("Password must be between 6 and 10 characters");
            isValid = false;
        }
    }


    // "Password must consist only of letters and digits"
    function consistOnlyOfLettersAndDigits(pass) {
        let regSymbol = /[A-Za-z\d]/g;
        let matchesSymbol = pass.match(regSymbol);
        if (matchesSymbol === null || matchesSymbol.length != pass.length) {
            console.log("Password must consist only of letters and digits");
            isValid = false;
        }

    }

    // "Password must have at least 2 digits"
    function mustHaveAtLeast2Digits(pass) {
        let regSymbol = /[\d]/g;
        let matchesSymbol = pass.match(regSymbol);
        if (matchesSymbol === null || matchesSymbol.length < 2) {
            console.log("Password must have at least 2 digits");
            isValid = false;
        }

    }



    symbolsBetween6And10(pass);
    consistOnlyOfLettersAndDigits(pass);
    mustHaveAtLeast2Digits(pass);

    if (isValid){
        console.log("Password is valid");
    }

}

// Solve('logIn');
// Solve('MyPass123');
// Solve('Pa$s$s');
 Solve('');



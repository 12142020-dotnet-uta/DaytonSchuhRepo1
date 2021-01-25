"use strict";
function coins(userInput) {
    var div = document.getElementById("output");
    var paragraph = document.createElement("p");
    var userInput2 = parseFloat(userInput.value);
    console.log("Parsed float: " + userInput2);
    // truncate values
    if (userInput2 > 0) {
        userInput2 *= 100;
        console.log("After multiplying by 100: " + userInput2);
        // round the value
        userInput2 = Math.round(userInput2);
        var d = Math.floor(userInput2 / 10); // number of dimes
        userInput2 %= 10;
        console.log("After dime calculation: " + userInput2);
        var n = Math.floor(userInput2 / 5); // number of nickels
        userInput2 %= 5;
        console.log("After nickel calculation: " + userInput2);
        var p = userInput2; // number of pennies
        console.log("After penny calculation: " + userInput2);
        paragraph.textContent = "Number of dimes: " + d + " + Number of nickles: " + n + " + Number of pennies: " + p;
        div === null || div === void 0 ? void 0 : div.appendChild(paragraph);
    }
}

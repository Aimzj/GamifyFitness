"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/gamehub").build();

//Disable send button until connection is established
document.getElementById("button").disabled = true;
var userScore = 0;
connection.on("UpdateScore", function (user, score) {
    console.log(user, score);
    document.getElementById("userScore").textContent = `(${score})`;
});

connection.start().then(function(){
    document.getElementById("button").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("button").addEventListener("click", function (event) {
    userScore++;
    var user = document.getElementById("name").textContent;
    connection.invoke("UpdateScore", user, userScore).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
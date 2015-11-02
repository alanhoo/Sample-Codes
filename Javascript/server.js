/**
 * Created by Alan Ho on 3/29/15.
 */
// card game initialization
// create card array
var cardList = [];
cardList = createCardlist();

var errStr; //global error string to pass to socket

// Generate an array that carries 52 cards in string value: face + " of " + suit
function createCardlist(){
    var arr = [];
    for (var i = 1; i<=52; i++)
    {
        var face = i%13;
        switch(face){
            case 1:
                face = "Ace";
                break;
            case 11:
                face = "Jack";
                break;
            case 12:
                face = "Queen";
                break;
            case 0:
                face = "King";
                break;
            default:
                face = face.toString();
                break;
        }

        var suit;
        switch(Math.floor(i/13)) {
            case 0:
                suit = "Spade";
                break;
            case 1:
                suit = "Diamond";
                break;
            case 2:
                suit = "Heart";
                break;
            case 3:
                suit = "Club";
                break;
            default:
                break;
        }
        arr[i-1] = face + " of " + suit;
    }
    return arr;
}

// Generate random number to assign card to players
function drawRandom(){
    var ranNumber = Math.floor(Math.random() * 52);
    return ranNumber;
}

// create ending procedure for the game
function ending(){
    // use createResult and callback to assign the full message to the variable endStr
    var endStr;
    endStr = createResult(Current.length,welcome);
    io.emit("err", endStr);
}

// add a line break and welcome message to the end of argument string
function welcome(str){
    return str + "\nPlease press Start to restart the game.";
}

// Determine the game result and return a string to conclude the game accordingly.
// callback function is used here
function createResult(num, callback){
    // if there is only one player, Current[0] is the user number
    var endStr;
    if (num === 1) {
        if (user[Current[0]].score <= 21) {
            if (user[0].score > 21) {
                endStr = "Dealer busts. Player " + Current[0] + " wins.";
            } else if (user[Current[0]].score === user[0].score) {
                endStr = "Draw game.";
            } else if (user[Current[0]].score > user[0].score) {
                endStr = "Player " + Current[0] + " wins.";
            } else {
                endStr = "Dealer wins.";
            }
        } else {
            if (user[0].score > 21) {
                endStr = "No winner. Both player and dealer bust."
            } else {
                endStr = "Player " + Current[0] + " busts. Dealer wins.";
            }
        }
    }
    // if there are two players plus a dealer
    if (num === 2) {
        var high;
        var low;

        if (user[Current[0]].score > user[Current[1]].score) {
            high = Current[0];
            low = Current[1];
        } else {
            high = Current[1];
            low = Current[0];
        }

        if (user[high].score > 21 && user[low].score > 21) {
            endStr = "Both player bust. Dealer wins.";
        } else if (user[high].score <= 21 && user[low].score <=21 && user[0].score > 21) {
            endStr = "Dealer busts. Both players win."
        } else if (user[high].score > 21) {
            if (user[0].score > user[low].score && user[0].score <= 21) {
                endStr = "Dealer wins.";
            } else if (user[0].score === user[low].score){
                endStr = "Player " + low + " and dealer push.";

            } else {
                endStr = "Player " + low + " wins.";
            }
        } else if (user[high].score === user[low].score) {
            if (user[0].score > user[high].score) {
                endStr = "Dealer wins.";
            } else {
                endStr = "Both players push and win.";
            }
        } else if (user[0].score > user[high].score) { // Players and dealers is lower
            endStr = "Dealer wins.";
        } else if (user[0].score === user[high].score) {
            endStr = "Player " + high + " draws with dealer. Player " + low + " loses.";
        } else if (user[0].score < user[high].score && user[0].score > user[low].score) {
            endStr = "Players " + high + " win!";
        } else if (user[0].score === user[low].score) {
            endStr = "Player " + high + " wins.";
        } else if (user[0].score < user[low].score) {
            endStr = "Both players win!!";
        } else {
            endStr = "Result is non conclusive.";
        }
    }
    return callback(endStr);
}

// return the highest point of the players
// access many global variables
function higherPlayer(){
    //If there is only one player, return it if not busted
    if(Current.length === 1){
        if( user[Current[0]].score <= 21){
            return Current[0];
        } else {
            return null;
        }
    }
    //Both players are under 21pt, return the higher one
    if(!(user[Current[0]].score > 21) && !(user[Current[1]].score > 21)) {
        if (user[Current[0]].score > user[Current[1]].score) {
            return Current[0];
        } else {
            return Current[1];
        }
    }
    // both players are busted
    if((user[Current[0]].score > 21) && (user[Current[1]].score > 21)){
        return null;
    }
    // One of the player busted, return the other
    if((user[Current[0]].score > 21)){
        return Current[1];
    } else if((user[Current[1]].score > 21)) {
        return Current[0];
    }
}

// take the socket.id as arguement and return the index in the Current array
function findCurrentID(socID){
    var i;
    for (i = 0; i<Current.length; i++){
        if(Current[i] === socID)
            return i + 1;
    }
    return null;
}

// Check whether this socket connection is one of the two players
function isPlayer(socID) {
    var i;
    for (i = 1; i < user.length; i++) {
        if (user[i]) {
            if (socID === user[i].socketid) {
                return true;
            }
        }
    }
    return false;
}

// Check if the player stand yet
function isStand(socID){
    if(Hit[0].id === socID)
    {
        return Hit[0].stand;
    }
    if(Hit[1]) {
        if (Hit[1].id === socID) {
            return Hit[1].stand;
        }
    }
    return false;
}

// Check if it's the player's turn to hit
function canIHit(socID){
    if(Hit[0].id === socID)
    {
        return !Hit[0].stand;
    }
    else if(Hit[1]){  //if player #2 exist
        if(Hit[1].id === socID)
        {
            //if #2 is not stand yet and #1 is stand, #2 can now go hit some cards
            return (!Hit[1].stand && Hit[0].stand);
        }
    }
    console.log("Special case in canIHit " + socID );
    return false;
}

// Create a string that contains the cards of dealer and players for the client
function createDisplayStr(){
    var strarr = [];
    if(dealerback === true){
        strarr.push(user[0].dealerHide());
    } else {
        strarr.push(user[0].cardStr);
    }
    var i;
    for(i=0; i<Current.length; i++) {
        strarr[i + 1] = user[Current[i]].cardStr;
    }
    return strarr;
}

//Objects - players and dealer
function player(){

    this.ranNum = [];  //ID in cardList
    this.ranNum[0] = drawRandom();
    this.ranNum[1] = drawRandom();
    this.cardID = [];  //Name of the card
    this.cardID[0] = cardList[this.ranNum[0]];
    this.cardID[1] = cardList[this.ranNum[1]];

    this.score = 0; //default value
    this.numberofCard = 2; //default =2, Max = 5
    this.numofAce = 0;
    this.lessAce = 0;
    this.adjustment = 0;
    this.cardStr = "";
    this.errorStr ="";
    this.socketid = 0;
    this.blackjack = false;

    this.calculatescore();
    this.testHitResult(); // to check if get two ace and have 22 pts
    this.showCardString();
}

// unrevealed dealer's card and score before sending the hand to clients
player.prototype.dealerHide = function(){
    var resultArr = [];
    resultArr[0] = this.cardID[0];
    resultArr[1] = "back";
    resultArr[2] = "XX";

    return resultArr;
}

// dealer make moves after all players stood
player.prototype.dealermove = function(point) {
    dealerback = false;
    while (this.numberofCard < 5 && this.score < 17) {
        this.addCard();
        console.log("Dealer just adds 1 card");
        if (this.score > 21) {
            console.log("Dealer bust.");
            this.checkAce();
        }
    }
    console.log("Dealermove completes. Gameover.");
    io.emit("err","Dearlmove completes. Gameover.");
}

// return the boolean value if the dealer/player has blackjack
player.prototype.isBlackJack = function(){
    this.checkblackjack();
    return this.blackjack;
};

// check if the dealer / players has blackjack
player.prototype.checkblackjack = function() {
    if( this.score === 21 && this.numberofCard === 2){
        this.blackjack = true;
        this.errorStr = "You have Black Jack.";
    }
}

//set the object's socketid key value
player.prototype.setSocketid = function(socID){
    this.socketid = socID;
}

// Convert the Ace card point from 11 to 1 to prevent busting
player.prototype.checkAce = function(){

    if(this.numofAce > 0) {
        this.adjustment -= 10;
        this.lessAce --;
        this.calculatescore();
        this.showCardString();
        return true;
    }
    this.errorStr = "You are busted!! Failed checkAce";
    return false;
}

// Add card to the player by drawing a random card
player.prototype.addCard = function(){

    this.ranNum[this.numberofCard] = drawRandom();
    this.cardID[this.numberofCard] = cardList[this.ranNum[this.numberofCard]];
    this.numberofCard++;
    this.calculatescore();
    this.showCardString();
}

player.prototype.showCardString = function(){
    var i;
    this.cardStr = [];
    for(i = 0 ; i < this.numberofCard ; i++){
        this.cardStr[i] = this.cardID[i];
    }
    this.cardStr[i] = this.score;
}

player.prototype.calculatescore = function(){
    var len = this.numberofCard;
    this.score = 0;   //reset for calculation
    this.numofAce = 0;
    this.numofAce += this.lessAce;
    this.score += this.adjustment;
    for(var i = 0; i < len; i++){
        var value = parseInt(this.cardID[i]);
        if(value >= 0)
        {
            this.score += value;
        }
        else
        {
            var spaceIndex = this.cardID[i].indexOf(" ");
            var face = this.cardID[i].substring(0,spaceIndex);
            var facePoint = 0;
            switch(face) {
                case 'Ace':
                    facePoint = 11;
                    this.numofAce++;
                    break;
                case 'Jack':
                    facePoint = 10;
                    break;
                case 'Queen':
                    facePoint = 10;
                    break;
                case 'King':
                    facePoint = 10;
                    break;
                default:
                    break;
            }
            this.score += facePoint;

        }
    }
}

// Check if the player can hit again
player.prototype.testHitResult = function(num){

    if(this.numberofCard >= 5)
    {
        if(this.score>21)
        {
            errStr = "Player " + num + " busts.";
        } else {
            errStr = "Player " + num + " have five cards. Can't draw anymore.";
        }
        return false;
    }

    if(this.score === 21){
        console.log("Player " + this.socketid + " got 21 pts. Stand.");
        errStr = "Player " + num + " got 21 pts.";
        return false;
    }

    if(this.score>21)
    {
        errStr = "Player " + num + " busts.";
        console.log(errStr);
        return (this.checkAce());
    }

    return true;
}

// initialize global variables when new game starts
function gameStart()
{
    // initialization
    gameOver = false;
    gameFull = false;
    dealerback = true;

    user = [{}];

    // id:0 is the dealer object
    user[0] = new player();

    // initilize the arrays
    Current = [];
    Hit = [];
    Stand = [];
}

// Server
var express = require('express');
var path = require('path');       //path module

var app = express();

// set static content directory
// from express.js guide
app.use(express.static(path.join(__dirname, "./static")));

// setup of template engine and view folder
// tell express from where to deliver front end file
// app.set("views", __dirname + "/views");
app.set("views",path.join(__dirname, "./views"));
app.set("view engine", "ejs");
// app.engine('html', require('ejs').renderFile);

// route to handle request
app.get("/", function(req, res){
    console.log("Hello! The server is ready.");
    res.render("index");
});

// create express server
var server = app.listen(6550, function(){
    console.log("We have started our server on port 6550.");
});

// create socket
var io = require('socket.io').listen(server);
// create socket list
var sockets = {};

// create global variables
var numofPlayer = 0;
var cardString = '';

var gameOver = true;
var gameFull = false;

// Array contains dealer and player objects
var user = [{}];
// contains two user player objects
var Current = [];
// Array for Hit button procedure
var Hit = [];
// Array for Stand button procedure
var Stand = [];

// Text string for chatroom
var chatContent ="";

// Show the back of dealer card until players stand
var dealerback;

io.sockets.on('connection', function(socket){

    numofPlayer ++;
    sockets[socket.id] = numofPlayer;

    console.log("User " + socket.id + " is connected");
    console.log("Player id is " + sockets[socket.id]);

    socket.emit("greeting", sockets[socket.id]);
    socket.emit("playernumber", 1, Current[0]);
    socket.emit("playernumber", 2, Current[1]);

    // Display current game result to any new user
    if(!gameOver) {
        socket.emit("displaycard", cardString);
    }
    // Prompt to start a new game
    if(gameOver && !gameFull){
        socket.emit("nugreeting", "Please hit Start button to start game.");
    }
    // Prompt to Join a game
    if(!gameOver && numofPlayer === 1){
        socket.emit("nugreeting", "Please hit Start button to join game.");
    }
    // Game is full. The new user can watch and wait.
    if(!gameOver && gameFull){
        socket.emit("nugreeting", "The game is full. Please wait for the next available seat." );
    }

    // When a user disconnects
    socket.on("disconnect", function(){
        console.log("Player " + sockets[socket.id] + " is disconnected.");
        socket.broadcast.emit("err","Player " + sockets[socket.id] + " is disconnected.");

        // If the player disconnects, set his status to stand
        if(isPlayer(socket.id)){
            var num = findCurrentID(sockets[socket.id]);
            Hit[num - 1].stand = true;

            // Ends the game if the only player disconnected or
            // the first player stands and the second player got disconnected
            if(Hit.length === 1 || (Hit[0].stand && Hit[1].stand) ){
                console.log("Game over due to disconnection.");
                gameOver = true;
                var point = higherPlayer();
                socket.broadcast.emit("err", "Now dealer's turn.");

                // Dealer makes move
                user[0].dealermove(point);
                cardString = createDisplayStr();
                socket.broadcast.emit("displaycard", cardString);

                ending();
            }
        }
        delete sockets[socket.id];
    });

    socket.on("deal", function(){
        if (gameOver) {
            //Player 1 starts a new game if Gameover is true
            console.log("");
            console.log("Player " + sockets[socket.id] + " starts a new game.");
            gameStart();

            // Create the first player
            user[sockets[socket.id]] = new player();
            user[sockets[socket.id]].setSocketid(socket.id);

            Current.push(sockets[socket.id]);
            cardString = createDisplayStr();

            Hit.push({id: sockets[socket.id], stand: false, blackjack: false});

            // Reset the players' display windows before sending the card string and info for their display
            io.emit("displaycard", ["", "", ""]);
            io.emit("displaycard", cardString);
            io.emit("err","");
            io.emit("playernumber",1,sockets[socket.id]);

            // As the only player of the game, the game ends immediately if player 1 has black jack
            if(user[sockets[socket.id]].isBlackJack()) {
                console.log("First player has BLACK JACK.");
                gameOver = true;
                Hit[0].blackjack = true;
                Hit[0].stand = true;
                // shows dealer's hand
                dealerback = false;
                cardString = createDisplayStr();
                io.emit("displaycard", cardString);

                if( Current.length === 1){
                    if(user[0].isBlackJack()){
                        io.emit("Both player and dealer have Black Jack. Game over.");
                    } else {
                        io.emit("err", "Player " + Current[0] + " has Black Jack. Game Over.");
                    }
                }
            } else {
                socket.emit("err", "You started the game. Now you may wait for other player to join or start playing.");
                socket.broadcast.emit("err","Player " + sockets[socket.id] + " just start the game. There is one seat available.");
            }
        }
        else if(isPlayer(socket.id)) {
            // This socket is already a game player. The input must be an error
            socket.emit("err", "The game has already begun. You can now either choose Hit or Stand.");
        }
        else if (!gameFull) {

            // Player 2 joins the game
            console.log("Player " + sockets[socket.id] + " joins game.");
            gameFull = true;

            // Create player 2 object
            user[sockets[socket.id]] = new player();
            user[sockets[socket.id]].setSocketid(socket.id);
            Current.push(sockets[socket.id]);
            Hit.push({id: sockets[socket.id], hit: false, stand: false});

            // create and emit the card string and messages to all users for display
            cardString = createDisplayStr();
            io.emit("displaycard", cardString);
            socket.broadcast.emit("err", "Player " + sockets[socket.id] + " just joined as the second player.");
            socket.emit("err", "You are now the second player.");
            io.emit("playernumber", 2, sockets[socket.id]);

            // Ends the game if the second player has blackjack
            if (user[sockets[socket.id]].isBlackJack()) {
                console.log("Player " + sockets[socket.id] + " has BLACK JACK.");
                Hit[1].blackjack = true;
                Hit[1].stand = true;
                io.emit("err", "Player " + sockets[socket.id] + " has Black Jack.");
                if(Hit[0].blackjack && Hit[1].blackjack)
                {
                    gameOver = true;
                    dealerback = false;
                    cardString = createDisplayStr();
                    io.emit("displaycard", cardString);
                    io.emit("err", "Both players have Black Jack and win!")
                }
            }
        }
        else {
            socket.emit("err", "There are already two players. You can try to join when this game is over.");
        }
    });

    // The "Hit" button is presssed
    socket.on("hit", function() {
        console.log("Player " + sockets[socket.id] + " presses Hit.");
        // The button has no effect if the game has not started
        if (gameOver) {
            socket.emit("err", "Begin the game by pressing Start button.");
        } else if (isPlayer(socket.id)) {
            // num represents the player number: 1 or 2
            var num = findCurrentID(sockets[socket.id]);

            //check whether the player has meet all the conditions to hit a card
            if (canIHit(sockets[socket.id])) {


                //add card
                user[sockets[socket.id]].addCard();

                socket.broadcast.emit("err", "Player " + num + "just hit.");

                //check if the game can continue after the card added
                if (!user[sockets[socket.id]].testHitResult(sockets[socket.id])) {
                    Hit[num - 1].stand = true;

                    // errStr is generated by function testHitResult
                    io.emit("err", errStr);

                    // Game over if the last player stands
                    if (Hit[Current.length - 1].stand === true) {

                        gameOver = true;
                        // Dealer's turn
                        console.log("Now dealer's turn");
                        io.emit("err", "Now dealer's turn.");

                        var point = higherPlayer();
                        user[0].dealermove(point);
                        cardString = createDisplayStr();
                        io.emit("displaycard", cardString);

                        ending();
                    }
                } else {
                    // prompt the user to hit another card
                    socket.emit("err", "Want to hit again?");
                }
                // display card images
                cardString = createDisplayStr();
                io.emit("displaycard", cardString);
            } else if (Hit[num - 1].stand) {
                // User error
                socket.emit("err", "You already hit the cards and stand.");
                socket.emit("err", user[sockets[socket.id]].errorStr);
            } else {
                // It is not the player's turn yet
                socket.emit("err", "Player " + Current[0] + " is making decisions.");
            }
        }
        else {
            if (!gameFull) {
                // A non player presses the button while there is still seat left
                socket.emit("err", "Press start to join the game");
            } else {
                // Game is over and someone else presses the button
                socket.emit("err", "There are already two players. You can watch while waiting for your turn.");
            }
        }
    });

    // The "Stand" button is pressed
    socket.on("stand", function(){
        console.log("Player " + sockets[socket.id] + " presses Stand.");
        if(gameOver){
            socket.emit("err", "Press Start to begins a new game.");
        } else if(isPlayer(socket.id)) {
            // If a player presses the button
            var num = findCurrentID(sockets[socket.id]);
            if(isStand(sockets[socket.id])){
                // If the player is standing
                socket.emit("err","You have already stand. Please wait for other player and dealer to make moves.");
            } else if( num === 2 && Hit[0].stand === false ){
                // Player #2 presses Stand but player 1 has not stood yet, then he needs to wait
                socket.emit("err","Player " + Hit[0].id + " has not stood yet.");
            }
            else {
                Hit[num-1].stand = true;

                socket.emit("err", "You stand. Now wait for other's moves.");
                // Next player move or dealer move
                // if this is the last player
                if(num === Current.length){
                    gameOver = true;
                    dealerback = false;

                    // dealer's move
                    if(user[0].isBlackJack()){
                        console.log("Dealer got Black Jack");
                        cardString = createDisplayStr();
                        io.emit("displaycard", cardString);
                        io.emit("err", "Dealer got Black Jack, dealer wins.");
                    } else {
                        io.emit("err", "Now dealer's turn.");

                        var point = higherPlayer();
                        user[0].dealermove(point);
                        cardString = createDisplayStr();
                        io.emit("displaycard", cardString);

                        ending();
                    }
                } else {
                    // check if the next player is able to hit
                    if(isStand(Hit[num].id)){
                        // if not, dealer can end the game
                        gameOver = true;
                        io.emit("err", "Now dealer's turn.");
                        var point = higherPlayer();
                        user[0].dealermove(point);
                        cardString = createDisplayStr();
                        io.emit("displaycard", cardString);

                        ending();

                    } else {
                        // otherwise, next player can now hit or stand
                        io.emit("err", "Player " + Hit[num].id + " now can hit.");
                    }
                }
            }
        } else {
            // non player press the button
            // emit error message
            socket.emit("err","Button disabled as you are an audience.")
        }
    });

    // Submit Text button is pressed
    socket.on("submitText",function(string){
        console.log("Received chat :" + string + " from Player " + sockets[socket.id] );
        // create the message and send it to users
        var content = "Player " + sockets[socket.id] + ": " + string;
        io.emit("sendChat", content);
        // backup the chat history. "\n" is for console log display
        chatContent += content + "\n" + "<br />";
        //console.log(chatContent);
    });
});
Created by Alan Ho alanhoyu@gmail.com in April, 2015.

Introduction-

This program is a Blackjack game with chatroom. It runs on node.js server and allows 2 players to play with the programmed dealer. I created this game as a result of my self-study.

I used javacript, jquery, node.js, express, socket.io, ejs, html and css to complete this project.

File Structure-

server.js
package.json
|
|_(views)___index.ejs
|
|_(static)__(image)
|
|_(node modules)_____(ejs)
                |____(sockets.io)
                |____(express)

Game rules-

1. Client page is opened at port 6550.
2. One or two players can join the game.
3. If more than two clients are opened, the new client is in watch mode that all button is disabled except sending text.
4. The rule is the same as Blackjack poker game.
5. The first player who joins has the right to hit and stand first. The second needs to wait for his/her turn to hit or stand.

Code highlights–

For Hack Reactor evaluations of my javascript skills, I highlight the examples of methods with line numbers at the following:

String methods

In server.js,
1. parseInt - line 358
2. indexOf – line 365
3. substring – line 366
 
In index.ejs,
1. parseInt – line 112
2. indexOf – line 120
3. substring – line 121
4. slice – line 143

Array and objects

I use Player object to store the card list, score and other information for the dealer and players. The initiation of Player object is on line 250 of server.js. The array User is used to contain the player objects. User[0] is reserved for the dealer. 

There are two other arrays being created during the game: Hit and Current. Hit array contains an object with two key value pairs: id and stand. ‘id’ indicates the number assigned to the player when he/she connects to the game. ‘stand’ is a Boolean value to show whether the player has finished his/her move for the game. Current array contains the player ids.

Callback function

The function createResult() on line 78 takes a function as an argument. I passed the function welcome() as the parameter to the function createResult. It adds a linebreak and a prompt message to the result message.

I also used callback functions in socket and jquery statements.

  

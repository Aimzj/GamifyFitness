var lastUpdate = 0;
var player, obstacle;
var playerJumpSpeed = 1;
var playerFallSpeed = 4;
var obstacleMoveSpeed = 3;
var score = 0;

var Player = function (elementName) {
    var position = [10, 80];
    var size = 54;
    var maxJump = 242;
    var isJumping = false;
    var canJump = true;
    var isFalling = false;
    var paused = true;

    var element = $("#" + elementName);

    var jump = function (y) {
        console.log("Jumping");
        position[1] += y;

        element.css('left', position[0] + 'px');
        element.css('bottom', position[1] + 'px');
    }

    var setup = function () {
        element.css('left', position[0] + 'px');
        element.css('bottom', position[1] + 'px');
    }

    var fall = function (y) {

        position[1] -= y;
        
        element.css('left', position[0] + 'px');
        element.css('bottom', position[1] + 'px');
    }

    var checkJump = function () {
        if (position[1] >= maxJump) {
            isJumping = false;
        }

        if (position[1] <= 80) {
            position[1] = 80;
            canJump = true;
        }
    }

    function pause() {
        paused = true;
    }

    function start() {
        paused = false;
    }

    function update(t) {
        if (isJumping) {
            jump(t / playerJumpSpeed)
        }
        else {
            fall(t / playerFallSpeed);
        }

        checkJump();
    }

    function toggleJumpDown() {
        if (canJump) {
            isJumping = true;
            canJump = false;
        }
    }

    function toggleJumpUp() {
        if (isJumping) {
            isJumping = false;
        }
    }

    return {
        jump: jump,
        fall: fall,
        start: start,
        pause: pause,
        update: update,
        toggleJumpDown: toggleJumpDown,
        toggleJumpUp: toggleJumpUp,
        setup: setup,
        getPosition: function () { return position; },
        getSize: function () { return size; },
        isJumping: function () { return isJumping; },
        isFalling: function () { return isFalling; },
        isPaused: function () { return paused;}
    }
}

var Obstacle = function (elementName) {
    var position = [10, 75];
    var size = [54, 108];
    var paused = true;

    var element = $("#" + elementName);
    var playArea = $("#PlayArea");

    var move = function (y) {
        if (paused) {
            return;
        }
        position[0] += y;

        if (position[0] >= innerWidth / 2 - size[0] * 4) {
            position[0] = 10;
        }

        element.css('right', position[0] + 'px');
        element.css('bottom', position[1] + 'px');
    }

    var setup = function () {
        element.css('right', position[0] + 'px');
        element.css('bottom', position[1] + 'px');
    }

    function update(t) {
        move(t / obstacleMoveSpeed);

        var playerPosition = player.getPosition();
        if ((position[0] + (size[0] / 2) > playerPosition[0] - (player.size / 2)) && (position[0] - (size[0] / 2) < playerPosition[0] - (player.size / 2))) {
            console.log("First obstacle hit!")
            if ((position[1] >= playerPosition) && (position[1] <= playerPosition[1] + player.getSize)) {
                console.log("Second obstacle hit!")
                pause();
                player.pause();
            }
        }
    }

    function pause() {
        paused = true;
    }

    function start() {
        paused = false;
    }

    return {
        update: update,
        move: move,
        pause: pause,
        start: start,
        setup: setup,
        getPosition: function () { return position; }
    }
}

function update(time) {
    var t = time - lastUpdate;
    lastUpdate = time;

    player.update(t);
    obstacle.update(t);
    requestAnimationFrame(update);
};

$(document).ready(function () {
    lastUpdate = 0;
    player = Player('Player');
    player.pause();
    obstacle = Obstacle('Obstacle');
    obstacle.pause();
    player.setup();
    obstacle.setup();

    requestAnimationFrame(update);
});

$(document).keydown(function (event) {
    var event = event || window.event;
    switch (String.fromCharCode(event.keyCode).toUpperCase()) {
        case 'W':
            if (player.isPaused()) {
                console.log("Player paused, can't jump");
                player.start();
                obstacle.start();
            }
            else {
                console.log("Trying to jump");
                player.toggleJumpDown();
            }
            break;
        case ' ':
            if (player.isPaused()) {
                console.log("Player paused, can't jump");
                player.start();
                obstacle.start();
            }
            else {
                console.log("Trying to jump");
                player.toggleJumpDown();
            }
            break;
    }
});

$(document).keyup(function (event) {
    var event = event || window.event;
    switch (String.fromCharCode(event.keyCode).toUpperCase()) {
        case 'W':
            player.toggleJumpUp();
            break;
        case ' ':
            player.toggleJumpUp();
            break;
    }
})

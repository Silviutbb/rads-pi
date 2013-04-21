var io = require('socket.io').listen(8080);
var gpio = require("pi-gpio");


io.sockets.on('connection', function (socket) {
	console.log("got a connection");
	socket.on('moveEvent', function (data) {
		console.log(data);
  });
   socket.on('disconnect', function () {
    console.log("user disconnected");
  });
});

gpio.open(16, "output", function(err) {        // Open pin 16 for output
    gpio.write(16, 1, function() {            // Set pin 16 high (1)
        gpio.close(16);                        // Close pin 16
    });
});
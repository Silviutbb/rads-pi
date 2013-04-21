var http = require('http');
var fs = require('fs');
var url = require('url');
var gpio = require("pi-gpio");
var permanenta;
var app = http.createServer(function (req, resp) {

    resp.writeHead(200);
    var url_parts = url.parse(req.url, true);
    var query = url_parts.query;
    var pathname = url_parts.pathname;
    if (pathname == '/Index') {
        resp.write("You called index");
        resp.end();
    }
    } else {
		if(pathname == "/pi.svg") resp.writeHead(200,{"Content-Type": "image/svg+xml"});
        fs.readFile('static' + req.url, 'utf8', function (err, data) {
            if (err) {
                resp.writeHead(404, {
                    "Content-Type": "text/html"
                });
                resp.write("Missing File aka 404");
                console.log('missing file ' + 'static' + req.url);
                resp.end();
            } else {
                resp.write(data);
                console.log('served ' + 'static' + req.url);
                resp.end();
            }
        });

    }
}).listen(80);

var runMotors = true;
var toggle = false;
var R1=7;
var R2=11;
var L1=15;
var L2=13;
setOutput(R1,false);
setOutput(R2,true);
setOutput(L1,false);
setOutput(L2,false);



gpio.open(7, "output", function(err) { 
	gpio.write(7, 1, function() {            // Set pin 16 high (1)
		gpio.close(7);                        // Close pin 16
	});
});


function setOutput(pin, state) {
		//
		//if(pin == 7 || pin == 11)
		//console.log(pin + " " + state);
        if (state) state = 1;
        else state = 0;
        gpio.open(pin, "output", function(err) { 
			gpio.write(pin, state, function() {            // Set pin 16 high (1)
		gpio.close(pin);                        // Close pin 16
	});
});
}

var io = require('socket.io').listen(app);



io.sockets.on('connection', function (socket) {
	console.log("got a connection");
	socket.on('moveEvent', function (data) {
	console.log(data);
	/*
	if(data.GO=="true")
	{
		setOutput(R1,false);
		setOutput(R2,false);
		setOutput(L1,true);
		setOutput(L2,false);
	}
	else
	{
		setOutput(R1,true);
		setOutput(R2,false);
		setOutput(L1,true);
		setOutput(L2,true);
	}*/
	//better left
	
	if(data.GO!="true")
	{
	console.log("one");
		setOutput(R1,true);
		setOutput(L1,true);
	}
	else
	{
	console.log("two");
		setOutput(R1,false);
		setOutput(L1,false);
	}
	
	//better keft right
	/*
	if(data.GO=="true")
	{
		setOutput(R1,true);
		setOutput(L1,false);
	}
	else
	{
		setOutput(R1,false);
		setOutput(L1,true);
	}
	
	*/
	//left right
	/*
		if(data.GO=="true")
	{
		setOutput(R1,true);
		setOutput(L1,true);
	}
	else
	{
		setOutput(R1,false);
		setOutput(L1,false);
	}
	*/
				
  });
   socket.on('disconnect', function () {
    console.log("user disconnected");
  });
});
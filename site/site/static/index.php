<html>
<head>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.0/jquery.min.js"></script>
<title>ASURO Connect</title>
</head>
<body>
Hello User!
<form>
<input type="text" id="host" value='10.10.0.32'>
</form>

<script>
	function sendCommand(key){
	var comm="";
	if(key == 119){
		comm="f100f100";}
	if(key == 97){
		comm="f040f100";}
	if(key == 115){
		comm="b100b100";}
	if(key == 100){
		comm="f100f040";}
	console.log(comm);
	console.log(key);
	if(comm != ""){
	var link = "http://" + $('#host').val() + "/Razvan?username="+comm;
	$.get(
    link,
    function(data){    
	});
	console.log(link);
	}
	}
		
	function init(){
		document.onkeypress = function(evt) {
            var keynum;

            if(window.event){ // IE					
            	keynum = evt.keyCode;
            }else
                if(evt.which){ // Netscape/Firefox/Opera					
            		keynum = evt.which;
                 }
            sendCommand(keynum);
        }
	}

    function ping() {
	var sw = false;
	var obj=document.getElementById("status");
	
	var link = "http://" + $('#host').val()+"/index.php";
	console.log(link);
	try{
  $.get(
    link,
    function(data){
	sw=true;
	obj.innerHTML="Connection worked.";
    
	});}
	catch(d){
	sw=false;
	}
	if(!sw){
	obj.innerHTML="Connection failed.";
	}
}


</script>
<button type="button" onclick="ping();">Test Connection</button>
<h3 id="status">Not tested</h3>
<button type="button" onclick="init();">Start Listen</button>
</body>
</html>
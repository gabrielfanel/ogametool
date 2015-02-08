
/**
 * Module dependencies.
 */

var express = require('express');
var http = require('http');
var path = require('path');

var app = express();

// all environments
app.set('port', process.env.PORT || 3000);
app.set('views', path.join(__dirname, 'views'));

app.use(express.static(path.join(__dirname, 'public')));
app.use("/script", express.static(__dirname + '/script'));
app.use("/view", express.static(__dirname + '/view'));
app.use("/public", express.static(__dirname + '/public'));
app.use("/js", express.static(__dirname + '/js'));
app.use("/data", express.static(__dirname + '/data'));

var server = http.createServer(app);

server.listen(app.get('port'), function()
{
    console.log('Express server listening on port ' + app.get('port'));
});

app.get('/', function(req, res) {res.sendfile('./index.html');});
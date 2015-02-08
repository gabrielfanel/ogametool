ogameJs.controller('homeController', ['$scope', 'dataservice', function ($scope, dataservice)
{
	$scope.name = "azeus";
	
	$scope.serverdata = {};
	
	$scope.loadServerInfo = function(id)
	{
		dataservice.getData(id + 'serverData').success(function(o)
		{
			$scope.$apply(function ()
			{
				$scope.serverdata = o;
			});
		});	
	};
	
	$scope.loadServerInfo(131);
}]);


ogameJs.service('dataservice', function ()
{
	this.getData = function(file)
	{
		var callbackobject = {
			cb:{},
			success:function(callback)
			{
				cb = callback;
			},
			done:function()
			{
				cb(JSON.parse(client.responseText));
			}
		};
	
		var client = new XMLHttpRequest();
		client.open('GET', '/data/' + file + '.js');
		
		client.onreadystatechange = callbackobject.done;
		client.send();
		return callbackobject;
	}
});

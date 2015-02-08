ogameJs.controller('homeController', function ($scope)
{
	$scope.name = "azeus";
	
	$scope.commit = function()
	{
		$scope.name = "mongole";
	}
});
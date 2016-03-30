'use strict';

app.controller('ticketController', ['$scope', 'ticketService', function ($scope, ticketService) {
    $scope.message = "Now viewing tickets!";
  
    
    $scope.loading = true;
    $scope.ticketsdata = {
        ticketId: "",
       R1C1: "",
	R1C2: "",
	R1C3: "",
	R1C4: "",
	R1C5: "",
	R1C6: "",
	R1C7: "",
	R1C8: "",
	R1C9: "",
	R2C1: "",
	R2C2: "",
	R2C3: "",
	R2C4: "",
	R2C5: "",
	R2C6: "",
	R2C7: "",
	R2C8: "",
	R2C9: "",
	R3C1: "",
	R3C2: "",
	R3C3: "",
	R3C4: "",
	R3C5: "",
	R3C6: "",
	R3C7: "",
	R3C8: "",
	R3C9: "",
    };

    ticketService.getTickets($scope);
    $scope.loading = false;
    document.getElementById("pickboard").style.display = 'block';
}])

app.service('ticketService', ['$http', function ($http) {
    this.getTickets = function ($scope) {
        return $http({
            method: "GET",
            url: "api/tickets",
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.ticketsdata = data;
            console.log(data);
        }).error(function (data) {
            console.log("error")
            console.log(data);
        });;
    };
}]);
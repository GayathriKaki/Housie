'use strict';


app.controller('customerController', ['$scope', '$http', function ($scope, $http) {
    $scope.message = "Registration Page";
    document.getElementById("pickboard").style.display = 'none';

        $scope.customersdata = {
            ticketId: 0,
            custId: "1",
            email:"",
           firstName:"",
          lastName :"",
            password :"",
            paypal_id :"",
           country :"",
           address:"",
           facebookLink :"",
          bool_emailstatus:"false",
          dateTImestamp :"",
           phoneNum :"",
        
        };
        $scope.submit = function () {
            alert("in Add function");
            $scope.customersdata.custId = "1";
            return $http({
                method: "POST",
                url: "api/Customers",
                data: $scope.customersdata,
                headers: { 'Content-Type': 'application/json' }
                
            }).success(function (data) {
                console.log(data);
                alert("Added Successfully!!");
                $http.addMode = false;
                $http.push(data);
                $http.loading = false;
            }).error(function (data) {
                console.log("Error in add function");
                console.log(data);
            });;
        };

}])

app.service('customerService', ['$http', function ($http) {
    this.getCustomers = function ($scope) {
        return $http({
            method: "GET",
            url: "api/customers",
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.customersdata = data;
            console.log(data);
        }).error(function (data) {
            console.log("Error :")
            console.log(data);
        });;
    };

    this.addCustomer = function ($scope) {
        alert("in Add function");
                return $http({
                    method: "POST",
                    url: "api/customers",
                    data: $scope.customersdata,
                    headers: { 'Content-Type': 'application/json' },
                }).success(function (data) {
                    console.log(data);
                    alert("Added Successfully!!");
                    $scope.addMode = false;
                    $scope.customerdata.push(data);
                    $scope.loading = false;
                }).error(function (data) {
                    console.log("gayathri there is an error in add function");
                    console.log(data);
                });;
            };

}]);
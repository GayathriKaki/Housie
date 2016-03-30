var app = angular.module('myApp', ['ngRoute'])
.config(['$routeProvider', function ($routeProvider) {
       $routeProvider
      .when('/', {
          templateUrl: 'home.html',
          controller: 'homeController'
      })
      .when('/about', {
          templateUrl: 'about.html',
          controller: 'aboutController'
      })
        .when('/tickets', {
            templateUrl: 'tickets.html',
            controller: 'ticketController'
        })
         .when('/register', {
             templateUrl: 'register.html',
             controller: 'customerController'
         })
        .when('/signin', {
            templateUrl: 'signin.html',
            controller: 'customerController'
        })
         .when('/picknumber', {
            
            templateUrl: 'picknumbers.html',
            controller: 'ticketController'
         })
      .otherwise({
          redirectTo: '/'
      });
}])
.controller('mainController', function ($scope) {
   
    $scope.message = "Main Content";
  
    console.log("loadboar false");
});;


'use strict';

app.controller('aboutController', function ($scope) {
    $scope.message = "Now viewing about!";
    document.getElementById("pickboard").style.display = 'none';
});
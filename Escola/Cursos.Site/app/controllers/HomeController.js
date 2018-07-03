'use strict';
app.controller('HomeController', ['$scope', '$interval', '$filter', '$timeout', 'homeService', 'authService', '$location', '$window',
    function ($scope, $interval, $filter, $timeout, homeService, authService, $location,$window) {
    $scope.acoes = [];
    $scope.error = {};
    homeService.getMenu().then(function (results) {
        $scope.acoes = results.data;
    }, function (error, status) {
        console.log($scope.error.message.data + ' ' +$scope.error.message.status);
    });
    $scope.usuario = authService.authentication.userName;
    $scope.clock = "loading clock..."; // initialise the time variable
    $scope.tickInterval = 1000 //ms

    var tick = function () {
        $scope.clock = $filter('date')(new Date(), 'HH:mm:ss'); // get the current time
        $timeout(tick, $scope.tickInterval); // reset the timer
    }

    // Start the timer
    $timeout(tick, $scope.tickInterval);

    $scope.ddMMMMyyyy = $filter('date')(new Date(), 'dd, MMMM yyyy');

    $scope.currentTime = $filter('date')(new Date(), 'dd/MM/yyyy');
    var updateTime = $interval(function () {
        $scope.currentTime = $filter('date')(new Date(), 'dd/MM/yyyy');
    }, 1000);

    $scope.changeClass = function (e) {
        var id = e.target.id;
        if ($("#menu" + id).hasClass("active")) {
            $("#menu" + id).removeClass("active"); 
        } else {
            $("#menu" + id).addClass("active"); 
        }
    };

}]);
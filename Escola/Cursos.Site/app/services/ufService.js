"use strict";
app.factory("ufService", ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {
    var service = {};
	var serviceBase = ngAuthSettings.apiServiceBaseUri;
    service.GetAll = function (callback) {
        $http.get(serviceBase + "uf/getall")
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.GetByUf = function (uf, callback) {
        $http.get(serviceBase + "uf/getbyyf/" + uf)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };
        
    return service;
}]);


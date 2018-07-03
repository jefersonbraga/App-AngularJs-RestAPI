"use strict";
app.factory("cepService", ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {
    var service = {};
    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    service.GetEndereco = function (cep, callback) {
        if (cep !== undefined) {
            $http.get(serviceBase + "endereco/getendereco/" + cep)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        }
    };

    return service;
}]);
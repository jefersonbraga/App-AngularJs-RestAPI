///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/3/2017 1:17:29 AM
///// Gerado automaticamente para alteracoes dos metodos comum alterar o template
///// </sumary>
"use strict";
app.factory("divulgacaoenviosService", ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {
    var service = {};
    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    service.GetAll = function (callback) {
        $http.get(serviceBase + "Divulgacaoenvios/getall")
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.GetById = function (id, callback) {
        $http.get(serviceBase + "Divulgacaoenvios/getbyid/" + id)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Post = function (Divulgacaoenvios, callback) {
        $http.post(serviceBase + "Divulgacaoenvios/post", Divulgacaoenvios)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Put = function (Divulgacaoenvios, callback) {
        $http.post(serviceBase + "Divulgacaoenvios/put", Divulgacaoenvios)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Delete = function (Divulgacaoenvios, callback) {
        $http.post(serviceBase + "Divulgacaoenvios/delete", Divulgacaoenvios)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    return service;
}]);
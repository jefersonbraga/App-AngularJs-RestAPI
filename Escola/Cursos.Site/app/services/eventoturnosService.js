///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 10/29/2017 12:46:54 AM
///// Gerado automaticamente para alteracoes dos metodos comum alterar o template
///// </sumary>
"use strict";
app.factory("eventoturnosService", ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {
    var service = {};
    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    service.GetAll = function (callback) {
        $http.get(serviceBase + "Eventoturnos/getall")
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.GetById = function (id, callback) {
        $http.get(serviceBase + "Eventoturnos/getbyid/" + id)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Post = function (Eventoturnos, callback) {
        $http.post(serviceBase + "Eventoturnos/post", Eventoturnos)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Put = function (Eventoturnos, callback) {
        $http.post(serviceBase + "Eventoturnos/put", Eventoturnos)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Delete = function (Eventoturnos, callback) {
        $http.post(serviceBase + "Eventoturnos/delete", Eventoturnos)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    return service;
}]);
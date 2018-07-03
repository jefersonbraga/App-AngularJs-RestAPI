///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 10/28/2017 8:01:24 PM
///// Gerado automaticamente para alteracoes dos metodos comum alterar o template
///// </sumary>
"use strict";
app.factory("tipoeventoService", ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {
    var service = {};
    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    service.GetAll = function (callback) {
        $http.get(serviceBase + "Tipoevento/getall")
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.GetById = function (id, callback) {
        $http.get(serviceBase + "Tipoevento/getbyid/" + id)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Post = function (Tipoevento, callback) {
        $http.post(serviceBase + "Tipoevento/post", Tipoevento)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Put = function (Tipoevento, callback) {
        $http.post(serviceBase + "Tipoevento/put", Tipoevento)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Delete = function (Tipoevento, callback) {
        $http.post(serviceBase + "Tipoevento/delete", Tipoevento)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    return service;
}]);
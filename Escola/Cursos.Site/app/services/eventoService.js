///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 9/19/2017 12:28:57 AM
///// Gerado automaticamente para alteracoes dos metodos comum alterar o template
///// </sumary>
"use strict";
app.factory("eventoService", ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {
    var service = {};
    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    service.GetAll = function (callback) {
        $http.get(serviceBase + "evento/getall")
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.GetAllCombo = function (callback) {
        $http.get(serviceBase + "evento/getallcombo")
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.GetById = function (id, callback) {
        $http.get(serviceBase + "evento/getbyid/" + id)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.GetByClientId = function (id, callback) {
        $http.get(serviceBase + "evento/getbyclientid/" + id)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };
    service.Post = function (evento, callback) {
        $http.post(serviceBase + "evento/post", evento)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Put = function (evento, callback) {
        $http.post(serviceBase + "evento/put", evento)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Delete = function (evento, callback) {
        $http.post(serviceBase + "evento/delete", evento)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    return service;
}]);
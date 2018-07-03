///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/2/2017 7:28:58 PM
///// Gerado automaticamente para alteracoes dos metodos comum alterar o template
///// </sumary>
"use strict";
app.factory("eventodatasService", ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {
    var service = {};
    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    service.GetAll = function (callback) {
        $http.get(serviceBase + "Eventodatas/getall")
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.GetById = function (id, callback) {
        $http.get(serviceBase + "Eventodatas/getbyid/" + id)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Post = function (Eventodatas, callback) {
        $http.post(serviceBase + "Eventodatas/post", Eventodatas)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Put = function (Eventodatas, callback) {
        $http.post(serviceBase + "Eventodatas/put", Eventodatas)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Delete = function (Eventodatas, callback) {
        $http.post(serviceBase + "Eventodatas/delete", Eventodatas)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    return service;
}]);
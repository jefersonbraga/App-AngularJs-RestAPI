///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 9/19/2017 12:28:57 AM
///// Gerado automaticamente para alteracoes dos metodos comum alterar o template
///// </sumary>
"use strict";
app.factory("modulosService", ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {
        var service = {};
		var serviceBase = ngAuthSettings.apiServiceBaseUri;
        service.GetAll = function (callback) {
            $http.get(serviceBase + "modulos/getall")
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.GetById = function (id, callback) {
            $http.get(serviceBase + "modulos/getbyid/" + id)
               .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.Post = function (modulos, callback) {
            $http.post(serviceBase + "modulos/post", modulos)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.Put = function (modulos, callback) {
            $http.post(serviceBase + "modulos/put", modulos)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

		service.Delete = function (modulos, callback) {
            $http.post(serviceBase + "modulos/delete", modulos)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        return service;
    }]);


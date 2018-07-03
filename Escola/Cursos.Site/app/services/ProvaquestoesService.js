///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/13/2017 11:55:26 AM
///// Gerado automaticamente para alteracoes dos metodos comum alterar o template
///// </sumary>
"use strict";
app.factory("ProvaquestoesService", ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {
        var service = {};
		var serviceBase = ngAuthSettings.apiServiceBaseUri;
        service.GetAll = function (callback) {
            $http.get(serviceBase + "Provaquestoes/getall")
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.GetById = function (id, callback) {
            $http.get(serviceBase + "Provaquestoes/getbyid/" + id)
               .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.Post = function (Provaquestoes, callback) {
            $http.post(serviceBase + "Provaquestoes/post", Provaquestoes)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.Put = function (Provaquestoes, callback) {
            $http.post(serviceBase + "Provaquestoes/put", Provaquestoes)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

		service.Delete = function (Provaquestoes, callback) {
            $http.post(serviceBase + "Provaquestoes/delete", Provaquestoes)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        return service;
    }]);


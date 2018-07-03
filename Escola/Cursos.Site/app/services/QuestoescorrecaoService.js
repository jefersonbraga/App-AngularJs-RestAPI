///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/13/2017 11:55:26 AM
///// Gerado automaticamente para alteracoes dos metodos comum alterar o template
///// </sumary>
"use strict";
app.factory("QuestoescorrecaoService", ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {
        var service = {};
		var serviceBase = ngAuthSettings.apiServiceBaseUri;
        service.GetAll = function (callback) {
            $http.get(serviceBase + "Questoescorrecao/getall")
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.GetById = function (id, callback) {
            $http.get(serviceBase + "Questoescorrecao/getbyid/" + id)
               .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.Post = function (Questoescorrecao, callback) {
            $http.post(serviceBase + "Questoescorrecao/post", Questoescorrecao)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.Put = function (Questoescorrecao, callback) {
            $http.post(serviceBase + "Questoescorrecao/put", Questoescorrecao)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

		service.Delete = function (Questoescorrecao, callback) {
            $http.post(serviceBase + "Questoescorrecao/delete", Questoescorrecao)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        return service;
    }]);


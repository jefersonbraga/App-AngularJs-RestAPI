///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 9/19/2017 12:28:57 AM
///// Gerado automaticamente para alteracoes dos metodos comum alterar o template
///// </sumary>
"use strict";
app.factory("inscricaoService", ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {
        var service = {};
		var serviceBase = ngAuthSettings.apiServiceBaseUri;
        service.GetAll = function (callback) {
            $http.get(serviceBase + "inscricao/getall")
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.GetTopInscricoes = function (callback) {
            $http.get(serviceBase + "inscricao/gettopinscricoes")
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.GetByClientId = function (id, callback) {
            $http.get(serviceBase + "inscricao/GetByClientId/" + id)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.GetById = function (id, callback) {
            $http.get(serviceBase + "inscricao/getbyid/" + id)
               .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.Post = function (inscricao, callback) {
            $http.post(serviceBase + "inscricao/post", inscricao)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        service.Put = function (inscricao, callback) {
            $http.post(serviceBase + "inscricao/put", inscricao)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

		service.Delete = function (inscricao, callback) {
            $http.post(serviceBase + "inscricao/delete", inscricao)
                .then(function (response) {
                    callback(response);
                }, function (response) {
                    callback(response);
                });
        };

        return service;
    }]);


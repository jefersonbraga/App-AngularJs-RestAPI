///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 9/19/2017 12:28:57 AM
///// Gerado automaticamente para alteracoes dos metodos comum alterar o template
///// </sumary>
"use strict";
app.factory("clienteService", ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {
    var service = {};
    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    service.GetClientes = function (avaliacaoid, callback) {
        $http.get(serviceBase + "cliente/getclientes/" + avaliacaoid)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.GetTopClientes = function (callback) {
        $http.get(serviceBase + "cliente/gettopclientes")
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.GetAll = function (callback) {
        $http.get(serviceBase + "cliente/getall")
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.GetReportCliente = function (type, filtro, callback) {
        $http({
            method: 'GET',
            url: serviceBase + "cliente/getreportclientes?filter=" + filtro + "&typeFile=" + type,
            //params: { typetypefile: type },
            responseType: 'arraybuffer'
        }).success(function (data, status, headers) {
            headers = headers();

            var filename = headers.filename;
            var contentType = headers['content-type'];

            var linkElement = document.createElement('a');
            try {
                var blob = new Blob([data], { type: contentType });
                var url = window.URL.createObjectURL(blob);

                linkElement.setAttribute('href', url);
                linkElement.setAttribute("download", filename);

                var clickEvent = new MouseEvent("click", {
                    "view": window,
                    "bubbles": true,
                    "cancelable": false
                });
                linkElement.dispatchEvent(clickEvent);
            } catch (ex) {
                console.log(ex);
            }
        }).error(function (data) {
            console.log(data);
        });
    };

    service.GetById = function (id, callback) {
        $http.get(serviceBase + "cliente/getbyid/" + id)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.GetByFilter = function (filter, callback) {
        $http.get(serviceBase + "cliente/GetFilter?filter=" + filter)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Post = function (cliente, callback) {
        $http.post(serviceBase + "cliente/post", cliente)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Put = function (cliente, callback) {
        $http.post(serviceBase + "cliente/put", cliente)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    service.Delete = function (cliente, callback) {
        $http.post(serviceBase + "cliente/delete", cliente)
            .then(function (response) {
                callback(response);
            }, function (response) {
                callback(response);
            });
    };

    return service;
}]);
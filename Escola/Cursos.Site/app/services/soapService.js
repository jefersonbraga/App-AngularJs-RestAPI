'use strict';
app.service('SoapService', ['$q', '$http',
    function($q, $http) {
         this.execute = function(metodo, params) {
            var envelope = '';
            var deferred = $q.defer();
            if (params) {
                envelope = '<ns1:'+metodo+'>'+
                                '<arg0>'+ JSON.stringify(params) +'</arg0>'+
                            '</ns1:'+metodo+'>';
            } else {
                envelope = '<ns1:'+metodo+'></ns1:'+metodo+'>';
            }
            $http({
                'url': 'https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl',
                'method': 'POST', 
                'data': '<?xml version="1.0" encoding="UTF-8"?>'+
                    '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ns1="http://schemas.xmlsoap.org/soap/http">'+
                        '<SOAP-ENV:Body>'+ envelope + '</SOAP-ENV:Body>'+
                    '</SOAP-ENV:Envelope>'
            })
            .then(function(response) {
                var result = response.data.substring(response.data.indexOf("<return>") + 8, response.data.indexOf("</return>"));
                // console.log(result);
                deferred.resolve(JSON.parse(result));
            }, function(response) {
                deferred.reject(response);
            }).catch(function(fallback) {
                console.log(fallback);
            });
            return deferred;
        };
    }
])
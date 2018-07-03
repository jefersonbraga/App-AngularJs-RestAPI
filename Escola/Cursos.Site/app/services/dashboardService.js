"use strict";
app.factory("dashboardService", ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {
    var service = {};
    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    return service;
}]);


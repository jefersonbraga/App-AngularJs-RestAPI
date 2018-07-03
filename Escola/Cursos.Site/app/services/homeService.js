'use strict';
app.factory('homeService', ['$http', 'ngAuthSettings', 'NotyService', '$window', function ($http, ngAuthSettings, notyService, $window) {
    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var homeServiceFactory = {};

    function generateNotifDashboard(content) {
        var position = 'top';
        var container = ".page-content";
        var n = $(container).noty({
            text: content,
            layout: position,
            closeWith: ['click'],
            theme: 'made',
            animation: {
                open: 'animated bounceIn',
                close: 'animated bounceOut'
            },
            //timeout: 5000,
            callback: {
                onShow: function () {
                    $('#noty_topRight_layout_container, .noty_container_type_success').css('width', 600).css('bottom', 10);
                },
                onCloseClick: function () {
                    setTimeout(function () {
                        $('#quickview-sidebar').addClass('open');
                        $window.location.href = "/#/login";
                    }, 500);
                }
            }
        });
    }

    var notifContent = '<div class="alert media fade in alert-danger"><p><strong>Serviço indisponível </strong>Url service:' + serviceBase + ' não esta disponivel.</p></div>';

    var _getMenu = function () {
        return $http.get(serviceBase + 'home/getmenu').then(function (results) {
            return results;
        }, function (result) {
            generateNotifDashboard(notifContent);
        });
    };

    homeServiceFactory.getMenu = _getMenu;

    return homeServiceFactory;
}]);
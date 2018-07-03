var app = angular.module('wescolaApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'ui.router', 'SharedServices', 'bsTable', 'dndLists']);

app.config(function ($routeProvider) {
    // HOME STATES AND NESTED VIEWS ========================================

    $routeProvider.when("/dashboard", {
        controller: "DashboardController",
        templateUrl: "/app/views/Dashboard.html"
    });

    $routeProvider.when("/home", {
        controller: "HomeController",
        templateUrl: "home.html"
    });

    $routeProvider.when("/login", {
        controller: "LoginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/acoes", {
        controller: "AcoesController",
        templateUrl: "/app/views/acoes.html"
    });

    $routeProvider.when("/avaliacao", {
        controller: "AvaliacaoController",
        templateUrl: "/app/views/avaliacao.html"
    });

    $routeProvider.when("/avaliacaopergunta", {
        controller: "AvaliacaoperguntaController",
        templateUrl: "/app/views/avaliacaopergunta.html"
    });
    $routeProvider.when("/avaliacaoobservacao", {
        controller: "AvaliacaoobservacaoController",
        templateUrl: "/app/views/avaliacaoobservacao.html"
    });

    $routeProvider.when("/cliente", {
        controller: "ClienteController",
        templateUrl: "/app/views/cliente.html"
    });

    $routeProvider.when("/controlenecessidade", {
        controller: "ControlenecessidadeController",
        templateUrl: "/app/views/controlenecessidade.html"
    });

    $routeProvider.when("/divulgacao", {
        controller: "DivulgacaoController",
        templateUrl: "/app/views/divulgacao.html"
    });

    $routeProvider.when("/escolaridade", {
        controller: "EscolaridadeController",
        templateUrl: "/app/views/escolaridade.html"
    });

    $routeProvider.when("/evento", {
        controller: "EventoController",
        templateUrl: "/app/views/evento.html"
    });

    $routeProvider.when("/inscricao", {
        controller: "InscricaoController",
        templateUrl: "/app/views/inscricao.html"
    });

    $routeProvider.when("/localprova", {
        controller: "localprovaController",
        templateUrl: "/app/views/localprova.html"
    });

    $routeProvider.when("/menu", {
        controller: "MenuController",
        templateUrl: "/app/views/menu.html"
    });

    $routeProvider.when("/modulos", {
        controller: "ModulosController",
        templateUrl: "/app/views/modulos.html"
    });

    $routeProvider.when("/necessidade", {
        controller: "NecessidadeController",
        templateUrl: "/app/views/necessidade.html"
    });

    $routeProvider.when("/salalocalprova", {
        controller: "SalalocalprovaController",
        templateUrl: "/app/views/salalocalprova.html"
    });

    $routeProvider.when("/tema", {
        controller: "temaController",
        templateUrl: "/app/views/tema.html"
    });

    $routeProvider.when("/tpnecessidade", {
        controller: "TpnecessidadeController",
        templateUrl: "/app/views/tpnecessidade.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "/app/views/refresh.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/app/views/tokens.html"
    });

    $routeProvider.when("/associate", {
        controller: "associateController",
        templateUrl: "/app/views/associate.html"
    });

    $routeProvider.when("/profile", {
        controller: "ProfileController",
        templateUrl: "/app/views/profile.html"
    });

    $routeProvider.when("/reportcliente", {
        controller: "reportclienteController",
        templateUrl: "/app/views/reports/clientes.html"
    });

    $routeProvider.when("/reportinscricao", {
        controller: "reportinscricaoController",
        templateUrl: "/app/views/reports/inscricoes.html"
    });

    $routeProvider.when("/reportnecessidade", {
        controller: "reportnecessidadeController",
        templateUrl: "/app/views/construcao.html"
    });

    $routeProvider.when("/divulgacaoenvio", {
        controller: "divulgacaoenviosController",
        templateUrl: "/app/views/divulgacaoenvio.html"
    });

    $routeProvider.when("/recurso", {
        controller: "RecursoprovaController",
        templateUrl: "/app/views/Recursoprova.html"
    });



    $routeProvider.otherwise({ redirectTo: "/login" });
});

angular.module("wescolaApp").run(["$rootScope", "$location", "$http", "$window",
    function ($rootScope, $location, $http, $window) {
        $rootScope.$on("$locationChangeStart", function (event, next, current) {
            function continueExecution() {
                if ($("#contentPage").hasClass("fadeInUp")) {
                    $("#contentPage").removeClass("fadeInUp animated");
                }
            }
            function doStuff() {
                setTimeout(continueExecution, 2000);
            }

            //redirect to login page if not logged in
            if ($location.$$absUrl.match("home.html")) {
                if ($location.path() === "/login" || $location.path() === "/Login") {
                    $location.path("/dashboard");
                    //$location.path("/orders");
                }
                $("#contentPage").addClass("fadeInUp animated");
                doStuff();
                return;
            }
            if ($location.path() === "/exit") {
                $window.location.href = "/#/login";
                return;
            }
        });
    }]);
//var serviceBase = 'http://wks-avell:3522/services/';
var serviceBase = 'http://localhost:65526/services/';
//var serviceBase = 'http://api-weventos.azurewebsites.net/services/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

//app.service('authInterceptor', function ($q, $window) {
//    var service = this;
//    service.responseError = function (response) {
//        if (response.status == 401) {
//            $window.location.href = "/Profile/#/login";
//        }
//        return $q.reject(response);
//    };
//});
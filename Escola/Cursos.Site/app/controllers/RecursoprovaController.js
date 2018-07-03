///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 18/09/2017
///// Last Update: 11/13/2017 11:24:21 AM

///// Para outros metodos implementar classe partial
///// </sumary>
"use strict";
app.controller("RecursoprovaController", ['$scope', 'RecursoprovaService', 'NotyService', 'pluginsService','eventoService', function ($scope, RecursoprovaService, notyService, pluginsService, eventoService) {
    $scope.tblData = [];
    $scope.Recursoprova = {};
    $scope.codigo = "Código";
    $scope.questoes = "Questões";
    $scope.correcao = "Correção";
    $scope.tab = "tab0";
    $scope.instrucoes = "Instruções";
    setTimeout(function () {
        pluginsService.init();
    }, 500);

    $scope.navTab = function (tab) {
        $scope.tab = "tab"+tab;
    }

    $scope.showModal = function (action) {
        if (action === "new") {
            $scope.Recursoprova = {};
            $('#instrucoes').summernote('destroy');
            $('#instrucoes').summernote('code', $scope.Recursoprova.Instrucoes);
        }
            

        document.getElementById("modal-Recursoprova").style.display = "block";
        document.getElementById("panel-pesquisa").style.display = "none";
        $("#modal-Recursoprova").removeClass().addClass("bounceInRight animated active");
        $(".header").removeClass("active");
        $(".modal").data("action", action);
    }

    $scope.exitModal = function () {

        $("#modal-Recursoprova").removeClass().addClass("bounceOut animated");
        $("#panel-pesquisa").removeClass().addClass("panel bounceIn animated");
        $("#panel-pesquisa").show();
        $(".header").removeClass("preview active");
        $(".modal").data("action", "none");
    }

    $scope.Edit = function (row) {
        //$timeout($scope.increment, 1000);
        $scope.$apply(function () {
            $scope.Recursoprova = row;
        });
        $("#name").val($scope.Recursoprova.Name);
        if (!$scope.Recursoprova.Active) {
            $("#active").parent().removeClass("checked");
        } else {
            $("#active").parent().addClass("checked");
        }
        $scope.showModal("edit");
    }

    var getAllEventos = function () {
        eventoService.GetAllCombo(function (response) {
            if (response.status === 200) {
                var emptyData = jQuery.isEmptyObject(response.data[0]);
                if (emptyData) return;
                $scope.eventos = response.data;
            } else {
                var message = "";
                for (var item in response.data) {
                    if (response.data.hasOwnProperty(item)) {
                        message += response.data[item];
                    }
                }
                if (message === "") {
                    message = "Ocorreu erro ao consultar orgaos!"
                }
                notyService.Noty("Erro", message, notyService.Type.Danger, false, function (n) { return n; });
            }
        });
    };

    var getAll = function () {
        RecursoprovaService.GetAll(function (response) {
            if (response.status === 200) {
                var emptyData = jQuery.isEmptyObject(response.data[0]);
                if (emptyData) return;
                $scope.tblData = response.data;
            } else {
                var message = "";
                for (var item in response.data) {
                    if (response.data.hasOwnProperty(item)) {
                        message += response.data[item];
                    }
                }
                notyService.Noty("Erro", message, notyService.Type.Danger, false, function (n) { return n; });
            }
        });
    };

    $scope.Save = function () {
        var action = $(".modal").data("action");
        if (action === "new") {
            RecursoprovaService.Post($scope.Recursoprova, function (response) {
                if (response.status === 200 || response.status === 201) {
                    notyService.Noty("Informação", "Cadastro realizado com sucesso! ", notyService.Type.Success, false, function (n) { return n; });
                } else {
                    var message = "";
                    for (var item in response.data) {
                        if (response.data.hasOwnProperty(item)) {
                            if (item === "$id") continue;
                            message += response.data[item];
                        }
                    }
                    notyService.Noty("Wescola ocorreu erro ao salvar registro favor contatar suporte do sistema!", message, notyService.Type.Danger, false, function (n) { return n; });
                }
            });
        } else if (action === "edit") {
            RecursoprovaService.GetById($scope.Recursoprova.Id, function (response) {
                if (response.status === 200) {
                    if (!response.data) {
                        notyService.Noty("Alerta!", "Não foi localizado o registro favor contate o suporte!", notyService.Type.Warning, false, function (n) { return n; });
                        return;
                    }

                    var equal = angular.equals($scope.Recursoprova, response.data[0]);
                    if (equal) {
                        notyService.Noty("Informacao!", "Não teve alterações no registro, não e possivel salvar.", notyService.Type.Info, false, function (n) { return n; });
                        return;
                    }
                    RecursoprovaService.Put($scope.Recursoprova, function (response) {
                        if (response.status === 200 || response.status === 201) {
                            notyService.Noty("Informação", response.data + " registro atualizado com sucesso! ", notyService.Type.Success, false, function (n) { return n; });
                            getAll();
                        } else {
                            var message = "";
                            for (var item in response.data) {
                                if (response.data.hasOwnProperty(item)) {
                                    message += response.data[item];
                                }
                            }
                            notyService.Noty("Wescola ocorreu erro ao atualizar registro favor contatar suporte do sistema!", message, notyService.Type.Danger, false, function (n) { return n; });
                        }
                    });
                } else {
                    var message = "";
                    for (var item in response.data) {
                        if (response.data.hasOwnProperty(item)) {
                            message += response.data[item];
                        }
                    }
                    notyService.Noty("Erro", message, notyService.Type.Danger, false, function (n) { return n; });
                }
            });
        }
    }

    $scope.Delete = function (nRow) {
        var entity = nRow;
        notyService.Noty("Confirmacao", "Deseja excluir este registro: " + entity.Name + "? ", notyService.Type.Warning, true, function (confimation) {
            if (confimation) {
                RecursoprovaService.Delete(entity, function (response) {
                    if (response.status === 200 || response.status === 201) {
                        oTable.fnDeleteRow(nRow);
                        notyService.Noty("Informacao", "Registro excluido com sucesso!", notyService.Type.Success, false, function (n) { return n; });
                    } else {
                        var message = "";
                        for (var item in response.data) {
                            if (response.data.hasOwnProperty(item)) {
                                message += response.data[item];
                            }
                        }
                        notyService.Noty("Wescola ocorreu erro ao excluir registro favor contatar suporte do sistema!", message, notyService.Type.Danger, false, function (n) { return n; });
                    }
                });
            }
        });
    }

    $scope.Columns = [
        { field: "Id", title: "Id", sortable: false, visible: false },
        { field: "Eventoid", title: "Eventoid", sortable: false, visible: false },
        { field: "Titulo", title: "Titulo", sortable: true },
        { field: "Dtinicio", title: "Inicio", sortable: true },
        { field: "Hrinicio", title: "Hora inicio", sortable: true, visible: true },
        { field: "Dttermino", title: "Termino", sortable: true, visible: true },
        { field: "Hrinicio", title: "Hora Termino", sortable: true, visible: true },
        { field: "Dtcadastro", title: "Cadastro", sortable: true, visible: false },
        { field: "Dtatualizacao", title: "Atualização", sortable: true, visible: false },
        { field: "Dtexclusao", title: "Exclusão", sortable: true, visible: false },
    ];
    getAllEventos();
    getAll();
}]);
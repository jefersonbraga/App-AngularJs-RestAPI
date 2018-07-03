///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 18/09/2017
///// Last Update: 11/13/2017 11:24:21 AM

///// Para outros metodos implementar classe partial
///// </sumary>
"use strict";
app.controller("ProvaquestoesController", ['$scope', 'ProvaquestoesService', 'NotyService', function ($scope, ProvaquestoesService, notyService) {
    $scope.tblData = [];
    $scope.Provaquestoes = {};
    $scope.descricao = "Descrição";
    $scope.showModal = function (action) {
        if (action === "new")
            $scope.Provaquestoes = {};

        document.getElementById("modal-Provaquestoes").style.display = "block";
        $("#modal-Provaquestoes").removeClass().addClass("modal bounceInRight animated active");
        $(".header").removeClass("active");
        $(".modal").data("action", action);
    }

    $scope.exitModal = function () {
        $("#modal-Provaquestoes").removeClass().addClass("modal bounceOut animated");
        $(".header").removeClass("preview active");
        $(".modal").data("action", "none");
    }

    $scope.Edit = function (row) {
        //$timeout($scope.increment, 1000);
        $scope.$apply(function () {
            $scope.Provaquestoes = row;
        });
        $("#name").val($scope.Provaquestoes.Name);
        if (!$scope.Provaquestoes.Active) {
            $("#active").parent().removeClass("checked");
        } else {
            $("#active").parent().addClass("checked");
        }
        $scope.showModal("edit");
    }

    var getAll = function () {
        ProvaquestoesService.GetAll(function (response) {
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
            ProvaquestoesService.Post($scope.Provaquestoes, function (response) {
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
            ProvaquestoesService.GetById($scope.Provaquestoes.Id, function (response) {
                if (response.status === 200) {
                    if (!response.data) {
                        notyService.Noty("Alerta!", "Não foi localizado o registro favor contate o suporte!", notyService.Type.Warning, false, function (n) { return n; });
                        return;
                    }

                    var equal = angular.equals($scope.Provaquestoes, response.data[0]);
                    if (equal) {
                        notyService.Noty("Informacao!", "Não teve alterações no registro, não e possivel salvar.", notyService.Type.Info, false, function (n) { return n; });
                        return;
                    }
                    ProvaquestoesService.Put($scope.Provaquestoes, function (response) {
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
                ProvaquestoesService.Delete(entity, function (response) {
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
        { field: "Id", title: "Código", sortable: false, visible: false },
        { field: "Grupoquestoesid", title: "Grupoquestoesid", sortable: false, visible: false },
        { field: "Grupoquestoes", title: "Grupo de Questões", sortable: false, visible: true },
        { field: "Descricao", title: "Descrição", sortable: true, visible: true },
        { field: "Dtcadastro", title: "Cadastro", sortable: true, visible: false },
        { field: "Dtatualizacao", title: "Atualização", sortable: true, visible: false },
        { field: "Dtexclusao", title: "Exclusão", sortable: true, visible: false },
    ];

    getAll();
}]);
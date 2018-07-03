///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 18/09/2017
///// Last Update: 11/3/2017 1:17:33 AM

///// Para outros metodos implementar classe partial
///// </sumary>
"use strict";
app.controller("divulgacaoenviosController", ['$scope', 'divulgacaoenviosService', 'NotyService', 'divulgacaoService', 'orgaosService', 'eventoService', 'pluginsService',
    function ($scope, divulgacaoenviosService, notyService, divulgacaoService, orgaosService, eventoService, pluginsService) {
        $scope.title = "Mailing";
        $scope.tblData = [];
        $scope.divulgacaoenvios = {};
        $scope.divulgacoes = [];
        $scope.orgaos = [];
        $scope.eventos = [];
        $scope.orgao = "Orgão";
        $scope.alfabeto = [{ Id: "A", Descricao: "Letra A" },
        { Id: "B", Descricao: "Letra B" },
        { Id: "C", Descricao: "Letra C" },
        { Id: "D", Descricao: "Letra D" },
        { Id: "E", Descricao: "Letra E" },
        { Id: "F", Descricao: "Letra F" },
        { Id: "H", Descricao: "Letra H" },
        { Id: "I", Descricao: "Letra I" },
        { Id: "J", Descricao: "Letra J" },
        { Id: "K", Descricao: "Letra K" },
        { Id: "L", Descricao: "Letra L" },
        { Id: "M", Descricao: "Letra M" },
        { Id: "N", Descricao: "Letra N" },
        { Id: "O", Descricao: "Letra O" },
        { Id: "P", Descricao: "Letra P" },
        { Id: "Q", Descricao: "Letra Q" },
        { Id: "R", Descricao: "Letra R" },
        { Id: "S", Descricao: "Letra S" },
        { Id: "T", Descricao: "Letra T" },
        { Id: "U", Descricao: "Letra U" },
        { Id: "V", Descricao: "Letra V" },
        { Id: "X", Descricao: "Letra X" },
        { Id: "Y", Descricao: "Letra Y" },
        { Id: "Z", Descricao: "Letra Z" }];

        $scope.filtros = [{ Id: "Alfabetica", value: "Alfabetica" },
        { Id: "Aniversarios", value: "Aniversários" },
        { Id: "Pagameto Pendente", value: "Pagameto Pendente" },
        { Id: "Pagameto Confirmado", value: "Pagameto Confirmado" }];

        setTimeout(function () {
            pluginsService.init();
        }, 500);

        $scope.showModal = function (action) {
            if (action === "new")
                $scope.Divulgacaoenvios = {};

            document.getElementById("modal-divulgacaoenvios").style.display = "block";
            document.getElementById("panel-pesquisa").style.display = "none";
            $("#modal-divulgacaoenvios").removeClass().addClass("bounceInRight animated active");
            $(".header").removeClass("active");
            $("#modal-divulgacaoenvios").data("action", action);
        }

        $scope.exitModal = function () {
            document.getElementById("panel-pesquisa").style.display = "block";
            $("#modal-divulgacaoenvios").removeClass().addClass("bounceOut animated");
            $(".header").removeClass("preview active");
            $("#modal-divulgacaoenvios").data("action", "none");
        }

        $scope.Edit = function (row) {
            //$timeout($scope.increment, 1000);
            $scope.$apply(function () {
                $("#Orgao").select2('val', row.Idorgaotrabalho);
                $("#Evento").select2('val', row.Idevento);
                $("#Letraalfabeto").select2('val', row.Dsletraalfabeto);
                $("#Divulgacao").select2('val', row.Iddivulgacao);

                $scope.divulgacaoenvios = row;
            });
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

        var getAllOrgaos = function () {
            orgaosService.GetAll(function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;
                    $scope.orgaos = response.data;
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

        var getDivulgacoes = function () {
            divulgacaoService.GetAll(function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;
                    $scope.divulgacoes = response.data;
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

        var getAll = function () {
            divulgacaoenviosService.GetAll(function (response) {
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
            if ($scope.divulgacaoenvios.Evento !== undefined && $scope.divulgacaoenvios.Evento !== null) {
                $scope.divulgacaoenvios.Idevento = $scope.divulgacaoenvios.Evento.Id;
            }
            if ($scope.divulgacaoenvios.Divulgacao !== undefined && $scope.divulgacaoenvios.Divulgacao !== null) {
                $scope.divulgacaoenvios.Iddivulgacao = $scope.divulgacaoenvios.Divulgacao.Id;
            }
            if ($scope.divulgacaoenvios.Orgao !== undefined && $scope.divulgacaoenvios.Orgao !== null) {
                $scope.divulgacaoenvios.Idorgaotrabalho = $scope.divulgacaoenvios.Orgao.Id;
            }
            if ($scope.divulgacaoenvios.Letraalfabeto !== undefined && $scope.divulgacaoenvios.Letraalfabeto !== null) {
                $scope.divulgacaoenvios.Dsletraalfabeto = $scope.divulgacaoenvios.Letraalfabeto.Id;
            }

            var action = $("#modal-divulgacaoenvios").data("action");
            if (action === "new") {
                divulgacaoenviosService.Post($scope.divulgacaoenvios, function (response) {
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
                divulgacaoenviosService.GetById($scope.Divulgacaoenvios.Id, function (response) {
                    if (response.status === 200) {
                        if (!response.data) {
                            notyService.Noty("Alerta!", "Não foi localizado o registro favor contate o suporte!", notyService.Type.Warning, false, function (n) { return n; });
                            return;
                        }

                        var equal = angular.equals($scope.Divulgacaoenvios, response.data[0]);
                        if (equal) {
                            notyService.Noty("Informacao!", "Não teve alterações no registro, não e possivel salvar.", notyService.Type.Info, false, function (n) { return n; });
                            return;
                        }
                        DivulgacaoenviosService.Put($scope.Divulgacaoenvios, function (response) {
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
                    divulgacaoenviosService.Delete(entity, function (response) {
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
            { field: "Iddivulgacao", title: "Iddivulgacao", sortable: false, visible: false },
            { field: "Idevento", title: "Idevento", sortable: false, visible: false },
            { field: "Idorgaotrabalho", title: "Idorgaotrabalho", sortable: false, visible: false },
            { field: "Dsletraalfabeto", title: "Dsletraalfabeto", sortable: true },
            { field: "Emailteste", title: "Emailteste", sortable: true },
            { field: "Emailremetente", title: "Emailremetente", sortable: true },
            { field: "Assunto", title: "Assunto", sortable: true },
            { field: "Dtcadastro", title: "Dtcadastro", sortable: true },
            { field: "Dtalteracao", title: "Dtalteracao", sortable: true },
            { field: "Dtexclusao", title: "Dtexclusao", sortable: true },
        ];

        getAll();
        getDivulgacoes();
        getAllEventos();
        getAllOrgaos();
    }]);
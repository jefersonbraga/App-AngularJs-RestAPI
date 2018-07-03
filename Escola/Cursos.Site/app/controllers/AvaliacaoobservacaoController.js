///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 18/09/2017
///// Last Update: 11/11/2017 5:17:46 PM

///// Para outros metodos implementar classe partial
///// </sumary>
"use strict";
app.controller("AvaliacaoobservacaoController", ['$scope', 'AvaliacaoobservacaoService', 'NotyService', 'avaliacaoService', 'pluginsService', 'ngAuthSettings', 'clienteService', '$route',
    function ($scope, AvaliacaoobservacaoService, notyService, avaliacaoService, pluginsService, ngAuthSettings, clienteService, $route) {
        $scope.tblData = [];
        $scope.Avaliacaoobservacao = {};
        $scope.avaliacoes = [];
        $scope.title = "Avaliação Observações";
        $scope.codigo = "Código";
        $scope.observacao = "Observação";
        $scope.atualizacao = "Atualização";
        $scope.exclusao = "Exclusão";
        $scope.clientes = [];
        var serviceBase = ngAuthSettings.apiServiceBaseUri;

        setTimeout(function () {
            pluginsService.init();
        }, 500);

        $scope.showModal = function (action) {
            if (action === "new")
                $scope.Avaliacaoobservacao = {};

            document.getElementById("modal-Avaliacaoobservacao").style.display = "block";
            $("#modal-Avaliacaoobservacao").removeClass().addClass("modal bounceInRight animated active");
            $(".header").removeClass("active");
            $(".modal").data("action", action);
        }

        $scope.exitModal = function () {
            $("#modal-Avaliacaoobservacao").removeClass().addClass("modal bounceOut animated");
            $(".header").removeClass("preview active");
            $(".modal").data("action", "none");
            $route.reload();
        }

        $scope.Edit = function (row) {
            $("#Avaliacao").select2('val', row.Avaliacaoid);
            getClientes(row.Avaliacaoid);
            setTimeout(function () {
                $("#Cliente").select2('val', row.Clienteid);
            }, 500);
            $scope.$apply(function () {
                $scope.Avaliacaoobservacao = row;
            });
            $("#name").val($scope.Avaliacaoobservacao.Name);
            if (!$scope.Avaliacaoobservacao.Active) {
                $("#active").parent().removeClass("checked");
            } else {
                $("#active").parent().addClass("checked");
            }
            $scope.showModal("edit");
        }

        $("#Avaliacao").on("change", function (e) {
            if (e.added) {
                if (e.added.id === "") {
                    $route.reload();
                    return;
                }

                getClientes(e.added.id);
                $scope.Avaliacaoobservacao.Avaliacaoid = e.added.id;
            }
        });

        $("#Cliente").on("change", function (e) {
            if (e.added) {
                if (e.added.id === "") {
                    $route.reload();
                    return;
                }

                $scope.Avaliacaoobservacao.Clienteid = parseInt(e.added.id);
            }
        });

        var getClientes = function (avaliacaoid) {
            clienteService.GetClientes(avaliacaoid, function (response) {
                if (response.status === 200) {
                    $("#Cliente").prop('disabled', true);
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;

                    $scope.clientes = response.data;

                    $("#Cliente").prop('disabled', false);
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

        var getAllAvaliacoes = function () {
            avaliacaoService.GetAll(function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;
                    $scope.avaliacoes = response.data;
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
            AvaliacaoobservacaoService.GetAll(function (response) {
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
                AvaliacaoobservacaoService.Post($scope.Avaliacaoobservacao, function (response) {
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
                AvaliacaoobservacaoService.GetById($scope.Avaliacaoobservacao.Id, function (response) {
                    if (response.status === 200) {
                        if (!response.data) {
                            notyService.Noty("Alerta!", "Não foi localizado o registro favor contate o suporte!", notyService.Type.Warning, false, function (n) { return n; });
                            return;
                        }

                        var equal = angular.equals($scope.Avaliacaoobservacao, response.data[0]);
                        if (equal) {
                            notyService.Noty("Informacao!", "Não teve alterações no registro, não e possivel salvar.", notyService.Type.Info, false, function (n) { return n; });
                            return;
                        }
                        AvaliacaoobservacaoService.Put($scope.Avaliacaoobservacao, function (response) {
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
                    AvaliacaoobservacaoService.Delete(entity, function (response) {
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
            { field: "Avaliacaoid", title: "Avaliacaoid", sortable: false, visible: false },
            { field: "Clienteid", title: "Clienteid", sortable: false, visible: false },
            { field: "Observacao", title: "Observação", sortable: true },
            { field: "Dtatualizacao", title: "Atualização", sortable: true },
            { field: "Dtcadastro", title: "Cadastro", sortable: true },
            { field: "Dtexclusao", title: "Exclusao", sortable: true, visible: false },
        ];
        //getClientes();
        getAll();
        getAllAvaliacoes();
    }]);
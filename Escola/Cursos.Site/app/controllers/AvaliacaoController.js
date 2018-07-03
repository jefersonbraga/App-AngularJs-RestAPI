"use strict";
app.controller("AvaliacaoController", ['$scope', 'avaliacaoService', 'NotyService', 'eventoService', 'ngAuthSettings', 'pluginsService', '$route',
    function ($scope, avaliacaoService, notyService, eventoService, ngAuthSettings, pluginsService, $route) {
        $scope.codigo = "Código";
        $scope.title = "Avaliação";
        $scope.descricao = "Descrição";
        $scope.titulo = "Título";
        $scope.tblData = [];
        $scope.avaliacao = {};
        $scope.eventos = [];
        var serviceBase = ngAuthSettings.apiServiceBaseUri;
        setTimeout(function () {
            pluginsService.init();
        }, 500);

        $scope.showModal = function (action) {
            if (action === "new")
                $scope.avaliacao = {};

            $("#panel-pesquisa").removeClass().addClass("panel bounceOut animated");
            setTimeout(function () {
                document.getElementById("panel-pesquisa").style.display = "none";
            }, 100);

            setTimeout(function () {
                $("#modal-avaliacao").removeClass().addClass("bounceIn animated active");
                document.getElementById("modal-avaliacao").style.display = "block";
            }, 200);

            $(".header").removeClass("active");
            $("#modal-avaliacao").data("action", action);
        }

        $scope.exitModal = function () {
            setTimeout(function () {
                $("#modal-avaliacao").removeClass().addClass("bounceOut animated");
                document.getElementById("modal-avaliacao").style.display = "none";
            }, 100);
            setTimeout(function () {
                //document.getElementById("panel-pesquisa").style.display = "block";
                //$("#panel-pesquisa").removeClass().addClass("panel bounceInRight animated");
            }, 500);

            //$("#panel-pesquisa").show();

            //$(".header").removeClass("preview active");
            $("#modal-avaliacao").data("action", "none");
            $route.reload();
        }

        $scope.Edit = function (row) {
            //$timeout($scope.increment, 1000);
            if (row.Disponivel === "NAO") {
                $scope.avaliacao.Disponivel = "NAO";
                $("#Disponivel").iCheck('uncheck');
            }
            if (row.Disponivel === "SIM") {
                $scope.avaliacao.Disponivel = "SIM";
                $("#Disponivel").iCheck('check');
            }

            $scope.$apply(function () {
                $scope.avaliacao = row;
                setTimeout(function () {
                    $("#Evento").select2('val', row.Eventoid);
                }, 1000);
            });
            $("#name").val($scope.avaliacao.Name);
            if (!$scope.avaliacao.Active) {
                $("#active").parent().removeClass("checked");
            } else {
                $("#active").parent().addClass("checked");
            }
            $scope.showModal("edit");
        }

        $("#Disponivel").on("ifChecked", function (event) {
            $scope.avaliacao.Disponivel = "SIM";
        });
        $("#Disponivel").on("ifUnchecked", function (event) {
            $scope.avaliacao.Disponivel = "NAO";
        });

        $("#Evento").on("change ", function (e) {
            $scope.avaliacao.Eventoid = e.added.id;
        });

        var getAllEventos = function () {
            eventoService.GetAll(function (response) {
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
                    notyService.Noty("Erro", message, notyService.Type.Danger, false, function (n) { return n; });
                }
            });
        };

        var getAll = function () {
            avaliacaoService.GetAll(function (response) {
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
            var action = $("#modal-avaliacao").data("action");
            if (action === "new") {
                avaliacaoService.Post($scope.avaliacao, function (response) {
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
                avaliacaoService.GetById($scope.avaliacao.Id, function (response) {
                    if (response.status === 200) {
                        if (!response.data) {
                            notyService.Noty("Alerta!", "Não foi localizado o registro favor contate o suporte!", notyService.Type.Warning, false, function (n) { return n; });
                            return;
                        }

                        var equal = angular.equals($scope.avaliacao, response.data[0]);
                        if (equal) {
                            notyService.Noty("Informação!", "Não teve alterações no registro, não e possivel salvar.", notyService.Type.Info, false, function (n) { return n; });
                            return;
                        }
                        avaliacaoService.Put($scope.avaliacao, function (response) {
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
            notyService.Noty("Confirmacao", "Deseja excluir este registro: " + entity.Id + "? ", notyService.Type.Warning, true, function (confimation) {
                if (confimation) {
                    avaliacaoService.Delete(entity, function (response) {
                        if (response.status === 200 || response.status === 201) {
                            $("#table").fnDeleteRow(nRow);
                            notyService.Noty("Informação", "Registro excluido com sucesso!", notyService.Type.Success, false, function (n) { return n; });
                        } else {
                            var message = "";
                            for (var item in response.data) {
                                if (response.data.hasOwnProperty(item)) {
                                    message += response.data[item];
                                }
                            }
                            //notyService.Noty("Informação", " registro atualizado com sucesso! ", notyService.Type.Success, false, function (n) { return n; });
                            notyService.Noty("Informação", message, notyService.Type.Success, false, function (n) { return n; });
                        }
                    });
                }
            });
        }

        $scope.Columns = [
            { field: "Id", title: "Id", sortable: false, visible: false },
            { field: "Titulo", title: "Titulo", sortable: true },
            { field: "Descricao", title: "Descrição", sortable: true },
            { field: "Eventoid", title: "Evento", sortable: false, visible: false },
            { field: "Disponivel", title: "Disponivel", sortable: true },
            { field: "Dtinicio", title: "Início", sortable: true },
            { field: "Horainicio", title: "Hora Início", sortable: true },
            { field: "Dttermino", title: "Término", sortable: true },
            { field: "Horatermino", title: "Hora Término", sortable: true },
            { field: "Dtcadastro", title: "Cadastro", sortable: true },
            { field: "Dtalteracao", title: "Alterado", sortable: true },
        ];

        getAll();
        getAllEventos();
    }]);
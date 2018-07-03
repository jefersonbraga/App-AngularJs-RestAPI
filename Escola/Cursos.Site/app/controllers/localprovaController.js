///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 18/09/2017
///// Last Update: 9/19/2017 12:34:45 AM

///// Para outros metodos implementar classe partial
///// </sumary>
"use strict";
app.controller("localprovaController", ['$scope', 'localprovaService', 'NotyService', 'cepService','$route', function ($scope, localprovaService, notyService, cepService, $route) {
    $scope.codigo = "Código";
    $scope.title = "Local de Realização de Provas";
    $scope.tblData = [];
    $scope.localprova = {};
    $scope.showModal = function (action) {
        if (action === "new")
            $scope.localprova = {};

        document.getElementById("modal-localprova").style.display = "block";
        document.getElementById("panel-pesquisa").style.display = "none";
        $("#modal-localprova").removeClass().addClass("panel bounceInRight animated active");
        $(".header").removeClass("active");
        $("#modal-localprova").data("action", action);
    }

    $scope.exitModal = function () {
        $("#modal-localprova").removeClass().addClass("panel bounceOut animated");
        //$("#panel-pesquisa").removeClass().addClass("panel bounceInRight animated");
        $(".header").removeClass("preview active");
        $("#modal-localprova").data("action", "none");
        $route.reload();
    }

    $scope.Edit = function (row) {
        //$timeout($scope.increment, 1000);
        $scope.$apply(function () {
            $scope.localprova = row;
        });
        $("#name").val($scope.localprova.Name);
        if (!$scope.localprova.Active) {
            $("#active").parent().removeClass("checked");
        } else {
            $("#active").parent().addClass("checked");
        }
        $scope.showModal("edit");
    }
    $scope.getCep = function () {
        if ($scope.localprova.Cep === undefined || $scope.localprova.Cep.lenght === 0) {
            notyService.Noty("Informação", "Favor informe cep para consulta.", notyService.Type.Info, false, function (n) { return n; });

            //var idnoty = $(".noty_bar").attr("id");
            //$("#" + idnoty).removeClass().addClass("bounceOut animated");

            //setTimeout(function () {
            //    $("#" + idnoty).remove();
            //}, 1000);
            return;
        }
        var cep = $scope.localprova.Cep.replace('.', '').replace('-', '');
        cepService.GetEndereco(cep, function (response) {
            if (response.status === 200) {
                var emptyData = jQuery.isEmptyObject(response.data);
                if (emptyData) return;
                $scope.isValidCep = true;
                $scope.localprova.Endereco = response.data.Endereco;
                $scope.localprova.Bairro = response.data.Bairro;
                $scope.localprova.Cidade = response.data.Cidade;
                $scope.localprova.Estado = response.data.Uf;
                $scope.localprova.Complemento = response.data.Complemento;
            } else {
                var message = "";
                for (var item in response.data) {
                    if (response.data.hasOwnProperty(item)) {
                        message += response.data[item];
                    }
                }
                if (message === "") {
                    message = "Ocorreu erro ao consultar municipios!"
                }
                notyService.Noty("Erro", message, notyService.Type.Danger, false, function (n) { return n; });
            }
        });
    }
    var getAll = function () {
        localprovaService.GetAll(function (response) {
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
        var action = $("#modal-localprova").data("action");
        if (action === "new") {
            localprovaService.Post($scope.localprova, function (response) {
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
            localprovaService.GetById($scope.localprova.Id, function (response) {
                if (response.status === 200) {
                    if (!response.data) {
                        notyService.Noty("Alerta!", "Não foi localizado o registro favor contate o suporte!", notyService.Type.Warning, false, function (n) { return n; });
                        return;
                    }

                    var equal = angular.equals($scope.localprova, response.data[0]);
                    if (equal) {
                        notyService.Noty("Informacao!", "Não teve alterações no registro, não e possivel salvar.", notyService.Type.Info, false, function (n) { return n; });
                        return;
                    }
                    localprovaService.Put($scope.localprova, function (response) {
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
                localprovaService.Delete(entity, function (response) {
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
        { field: "Local", title: "Local", sortable: true },
        { field: "Cep", title: "Cep", sortable: true },
        { field: "Logradouro", title: "Logradouro", sortable: true },
        { field: "Endereco", title: "Endereço", sortable: true },
        { field: "Bairro", title: "Bairro", sortable: true },
        { field: "Complemento", title: "Complemento", sortable: true },
        { field: "Numero", title: "Numero", sortable: false, visible: false },
        { field: "Cidade", title: "Cidade", sortable: true },
        { field: "Estado", title: "Estado", sortable: true },
    ];

    getAll();
}]);
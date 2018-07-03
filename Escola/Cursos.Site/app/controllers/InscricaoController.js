"use strict";
app.controller("InscricaoController", ['$scope', 'inscricaoService', 'NotyService', 'necessidadeService', 'pluginsService', 'tpnecessidadeService', 'eventoService', 'localStorageService', '$route',
    function ($scope, inscricaoService, notyService, necessidadeService, pluginsService, tpnecessidadeService, eventoService, localStorageService, $route) {
        $scope.codigo = "Código";
        $scope.title = "Inscrição";
        $scope.tblData = [];
        $scope.inscricao = {};
        $scope.necessidades = [];
        $scope.tiponecessidades = [];
        $scope.eventos = [];
        $scope.numeromatricula = "Nº Matricula";
        $scope.filtro = {};
        $scope.inscricaonome = "Inscrição";
        $scope.numero = "Número";
        $scope.deficiencia = "Deficiência";
        $scope.realizacao = "Realização";
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

        $scope.necessidadesselecao = [];

        setTimeout(function () {
            pluginsService.init();
        }, 500);

        $scope.showModal = function (action) {
            if (action === "new")
                $scope.inscricao = {};

            document.getElementById("modal-inscricao").style.display = "block";
            document.getElementById("panel-pesquisa").style.display = "none";
            $("#modal-inscricao").removeClass().addClass("bounceInRight animated active");
            $(".header").removeClass("active");
            $("#modal-inscricao").data("action", action);
        }

        $scope.exitModal = function () {
            $("#modal-inscricao").removeClass().addClass("bounceOut animated");
            $(".header").removeClass("preview active");
            $("#modal-inscricao").data("action", "none");
            $route.reload();
        }

        $scope.Edit = function (row) {
            //$timeout($scope.increment, 1000);
            $scope.$apply(function () {
                $scope.inscricao = row;
            });
            $("#name").val($scope.inscricao.Name);
            $scope.showModal("edit");
        }

        $scope.onDrop = function (srcList, srcIndex, targetList, targetIndex) {
            // Copy the item from source to target.
            targetList.items.push(srcList.items[targetIndex])
            // Remove the item from the source, possibly correcting the index first.
            // We must do this immediately, otherwise ng-repeat complains about duplicates.
            if (srcList.items == targetList.items && targetIndex <= srcIndex) srcIndex++;
            srcList.items.splice(srcIndex, 1);
            return true;
        };

        var getNecessidades = function () {
            necessidadeService.GetAll(function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;
                    //$scope.necessidades = response.data;

                    $scope.necessidadesselecao = [
                        {
                            ListName: "Necessidades Especiais",
                            items: response.data
                        },
                        {
                            ListName: "Necessidades Especiais do Candidato",
                            items: []
                        }
                    ];
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

        var getEventos = function () {
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
        }
        var getTipoNecessidades = function () {
            tpnecessidadeService.GetAll(function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;
                    $scope.tiponecessidades = response.data;
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

        $scope.Save = function () {
            var action = $(".modal").data("action");

            inscricao.Turno = $("#Turno").val();
            inscricao.Tpnecessidade = $("#Tpnecessidade").val();
            inscricao.Neespecial = $("#Neespecial").val();
            inscricao.Formapagamento = $("#Formapagamento").val();
            inscricao.Eventoid = $("#Evento").val();
            inscricao.Pago = $("#Pago").val();

            if (action === "new") {
                inscricaoService.Post($scope.inscricao, function (response) {
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
                inscricaoService.GetById($scope.inscricao.Id, function (response) {
                    if (response.status === 200) {
                        if (!response.data) {
                            notyService.Noty("Alerta!", "Não foi localizado o registro favor contate o suporte!", notyService.Type.Warning, false, function (n) { return n; });
                            return;
                        }

                        var equal = angular.equals($scope.inscricao, response.data[0]);
                        if (equal) {
                            notyService.Noty("Informacao!", "Não teve alterações no registro, não e possivel salvar.", notyService.Type.Info, false, function (n) { return n; });
                            return;
                        }
                        inscricaoService.Put($scope.inscricao, function (response) {
                            if (response.status === 200 || response.status === 201) {
                                notyService.Noty("Informação", response.data + " registro atualizado com sucesso! ", notyService.Type.Success, false, function (n) { return n; });
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
                    inscricaoService.Delete(entity, function (response) {
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

        $scope.ShowDetail = function (row) {
            var html = [];
            html.push('<div class="panel widget-member clearfix">');
            html.push('<div class="col-xs-12">');
            html.push(' <h3 class="m-t-0 member-name"><strong>' + row.Evento + '</strong></h3>');
            html.push(' <p class="member-job"><strong>Cliente:</strong> ' + row.NomeCliente + '</p>');
            html.push('<div class="panel-content">');
            html.push('	<div class="tab_left">');
            html.push('		<ul  class="nav nav-tabs nav-red">');
            html.push('		  <li class="active"><a href="#tab3_2" data-toggle="tab"><i class="icon-user"></i> Dados</a></li>');
            html.push('		  <li><a href="#tab3_3" data-toggle="tab"><i class="icon-cloud-download"></i> Descricao</a></li>');
            html.push('		</ul>');
            html.push('		<div class="tab-content">');
            html.push('		  <div class="tab-pane fade active in" id="tab3_2">');
            html.push('                 <div class="col-xlg-2 align-right">');
            html.push('                     <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Situacao:</strong> ' + row.Cargo + '</p>');
            html.push('                     <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Sala:</strong> ' + row.Sala + '</p>');
            html.push('                 </div>');
            html.push('		  </div>');
            html.push('		  <div class="tab-pane fade" id="tab3_3">');
            html.push('                 <div class="col-xlg-12 align-right">');
            html.push('                     <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Situacao:</strong> ' + row.Cargo + '</p>');
            html.push('                     <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Sala:</strong> ' + row.Sala + '</p>');
            html.push('                 </div>');
            html.push('		  </div>');
            html.push('		</div>');
            html.push('	</div>');
            html.push('</div>');
            html.push('</div>');
            html.push('</div>');

            var $detail = $(".detail-view td");
            $detail.append(html.join(""));
        };

        $scope.Columns = [
            { field: "Id", title: "Matricula", sortable: false, visible: true },
            { field: "NomeCliente", title: "Aluno", sortable: true, visible: true },
            { field: "Instituicao", title: "Instituição", sortable: false, visible: true },
            { field: "Evento", title: "Evento", sortable: false, visible: true },
            { field: "Dtinscricao", title: "Data", sortable: true, visible: true },
            { field: "Turno", title: "Turno", sortable: true, visible: true },
            { field: "Pago", title: "Pago", sortable: true, visible: true },
            { field: "Dtpagamento", title: "Data Pagamento", sortable: true, visible: true },
            { field: "Baixa", title: "Baixa", sortable: true, visible: true },
            { field: "Dtboletoemitido", title: "Data Boleto", sortable: false, visible: false },
            { field: "Boletoemitido", title: "Boleto Emitido", sortable: true, visible: false },
            { field: "Valorrecebido", title: "Valor Recebido", sortable: true, visible: false },
            { field: "Cargo", title: "Cargo", sortable: false, visible: false },
            { field: "Tpnecessidade", title: "Necessidade", sortable: false, visible: false },
            { field: "Neespecial", title: "Necessidade Especial", sortable: false, visible: false },
            { field: "Baixa", title: "Baixa", sortable: false, visible: false },
            { field: "Criado", title: "Criado", sortable: false, visible: false },
            { field: "Valor", title: "Valor", sortable: true, visible: false },
            { field: "Formapagamento", title: "Forma Pagamento", sortable: true, visible: false },
            { field: "Clienteid", title: "Cliente Id", sortable: false, visible: false },
        ];

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            $.ajaxSetup({
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", 'Bearer ' + authData.token);
                    xhr.setRequestHeader("refresh_token", authData.refresh_token);
                }
            });
        }
        getNecessidades();
        getTipoNecessidades();
        getEventos();
    }]);
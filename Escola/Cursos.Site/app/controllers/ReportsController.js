'use strict';

app.controller('reportclienteController', ['$scope', 'ordersService', 'clienteService', 'pluginsService', 'orgaosService', 'localStorageService', 'NotyService', 'escolaridadeService', 'eventoService', '$route',
    function ($scope, ordersService, clienteService, pluginsService, orgaosService, localStorageService, notyService, escolaridadeService, eventoService, $route) {
        $scope.title = "Relatório de Clientes Cadastrados";
        $scope.orgao = "Orgão onde trabalha:";
        $scope.orgaos = [];
        $scope.filtro = {};
        $scope.filtro.Columnsreport = "";
        $scope.Columnsreport = [];
        $scope.escolaridades = [];
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

        setTimeout(function () {
            pluginsService.init();
        }, 500);

        var searchFilter = function (filter) {
            clienteService.GetByFilter(filter + "&order=asc&offset=0&limit=10", function (response) {
                if (response.status === 200) {
                    $("#table").bootstrapTable("destroy")
                    var options = {
                        cache: true,
                        height: 500,
                        striped: true,
                        pagination: true,
                        pageSize: 10,
                        pageList: [10, 20, 30],
                        search: false,
                        showColumns: false,
                        showRefresh: false,
                        showExport: true,
                        minimumCountColumns: 2,
                        clickToSelect: true,
                        showToggle: true,
                        maintainSelected: true,
                        locale: "pt-BR",
                        filter: true
                    }
                    options.url = serviceBase + "cliente/getfilter?filter=" + filter;
                    options.sidePagination = "server";

                    options["columns"] = $scope.Columns;
                    options.totalRows = response.data.total;
                    $("#table").bootstrapTable(options);
                    $("#table").bootstrapTable("load", response.data);
                    $("#table").bootstrapTable("refresh");
                } else {
                    var message = "";
                    for (var item in response.data) {
                        if (response.data.hasOwnProperty(item)) {
                            message += response.data[item];
                        }
                    }
                    if (message === "") {
                        message = "Ocorreu erro ao consultar registros!"
                    }
                    notyService.Noty("Erro", message, notyService.Type.Danger, false, function (n) { return n; });
                }
            });
        }

        $scope.refresh = function () {
            $route.reload();
        }

        $("#Evento").on("change ", function (e) {
            if (e.added) {
                if (e.added.id === "") {
                    $route.reload();
                    return;
                }

                $scope.filtro.Eventoid = e.added.id;
                searchFilter(JSON.stringify($scope.filtro));
            }
        });
        $("#Orgao").on("change ", function (e) {
            if (e.added) {
                if (e.added.id === "") {
                    $route.reload();
                    return;
                }

                $scope.filtro.Orgaotrabalhoid = e.added.id;
                searchFilter(JSON.stringify($scope.filtro));
            }
        });

        $("#Sexofiltro").on("change", function (e) {
            if (e.added) {
                if (e.added.id === "") {
                    $route.reload();
                    return;
                }
                $scope.filtro.Sexo = e.added.id;
                searchFilter(JSON.stringify($scope.filtro));
            }
        });

        $("#Letraalfabeto").on("change", function (e) {
            if (e.added) {
                if (e.added.id === "") {
                    $route.reload();
                    return;
                }
                $scope.filtro.Letra = e.added.id;
                searchFilter(JSON.stringify($scope.filtro));
            }
        });

        $("#Dtaniversario").on("change", function (e) {
            var data = $("#Dtaniversario").val();
            if (data.length === 10) {
                $scope.filtro.Dtaniversario = formatDate(new Date(data), "yyyy-MM-dd");
                searchFilter(JSON.stringify($scope.filtro));
            }
        });

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
                    notyService.Noty("Erro", message, notyService.Type.Info, false, function (n) { return n; });
                }
            });
        };

        $scope.getReport = function (type) {
            var columnsSend = {};
            columnsSend = $scope.Columnsreport.filter(function (object) {
                return object.visible === true;
            });
            $scope.filtro.Columnsreport = "";
            for (var i = 0; i < columnsSend.length; i++) {
                $scope.filtro.Columnsreport += columnsSend[i].id + ";";
            }

            clienteService.GetReportCliente(type, JSON.stringify($scope.filtro), function (response) {
                if (response.status === 200) {
                    notyService.Noty("Sucesso", "Relatorio gerado com sucesso.", notyService.Type.Success, false, function (n) { return n; });
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
                    notyService.Noty("Alerta", message, notyService.Type.Info, false, function (n) { return n; });
                }
            });
            //loadColumns();
        }

        var getAllEscolaridade = function () {
            escolaridadeService.GetAll(function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;
                    $scope.escolaridades = response.data;
                } else {
                    var message = "";
                    for (var item in response.data) {
                        if (response.data.hasOwnProperty(item)) {
                            message += response.data[item];
                        }
                    }
                    if (message === "") {
                        message = "Ocorreu erro ao consultar escolaridades!"
                    }
                    notyService.Noty("Erro", message, notyService.Type.Danger, false, function (n) { return n; });
                }
            });
        };

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

        $scope.Columns = [
            { field: "Id", title: "Código", sortable: false, visible: false, ordem: 1 },
            { field: "Nome", title: "Nome", sortable: true, visible: true, ordem: 2 },
            { field: "Email", title: "Email", sortable: true, visible: true, ordem: 3 },
            { field: "Rg", title: "Rg", sortable: true, visible: true, ordem: 4 },
            { field: "Orgaoemissor", title: "Orgao Emissor", sortable: true, visible: false, ordem: 5 },
            { field: "Ufemissor", title: "Uf Emissor", sortable: true, visible: false, ordem: 6 },
            { field: "Dtemissao", title: "Emissao", sortable: true, visible: false, ordem: 7 },
            { field: "Cpf", title: "Cpf", sortable: true, visible: true, ordem: 8 },
            { field: "Nacionalidade", title: "Nacionalidade", sortable: false, visible: false, ordem: 9 },
            { field: "Naturalidade", title: "Naturalidade", sortable: true, visible: false, ordem: 10 },
            { field: "Dtnascimento", title: "Nascimento", sortable: true, visible: false, ordem: 11 },
            { field: "Sexo", title: "Sexo", sortable: true, visible: true, ordem: 12 },
            { field: "Nomepai", title: "Nome Pai", sortable: false, visible: false, ordem: 13 },
            { field: "Nomemae", title: "Nome Mãe", sortable: false, visible: false, ordem: 14 },
            { field: "Cep", title: "Cep", sortable: false, visible: false, ordem: 15 },
            { field: "Endereco", title: "Endereço", sortable: false, visible: false, ordem: 16 },
            { field: "Bairro", title: "Bairro", sortable: false, visible: false, ordem: 17 },
            { field: "Numero", title: "Numero", sortable: false, visible: false, visible: false, ordem: 18 },
            { field: "Complemento", title: "Complemento", sortable: false, visible: false, ordem: 19 },
            { field: "Cidade", title: "Cidade", sortable: true, visible: true, ordem: 20 },
            { field: "Estado", title: "Estado", sortable: true, visible: true, ordem: 21 },
            { field: "Telresidencial", title: "Tel. Residencial", sortable: false, visible: false, ordem: 22 },
            { field: "Telcomercial", title: "Tel. Comercial", sortable: false, visible: false, ordem: 23 },
            { field: "Telcelular", title: "Tel. Celular", sortable: true, visible: true, ordem: 24 },
            { field: "Cadadministracao", title: "Cad Administração", sortable: true, visible: false, ordem: 25 },
            { field: "Enviosenha", title: "Envio Senha", sortable: false, visible: false, ordem: 26 },
            { field: "Orgaotrabalhoid", title: "Orgão Trabalho", sortable: false, visible: false, ordem: 27 },
            { field: "Escolaridadeid", title: "Escolaridade", sortable: false, visible: false, ordem: 28 },
            { field: "Instituicao", title: "Instituição", sortable: false, visible: true, ordem: 29 },
            { field: "Dtconclusao", title: "Conclusão", sortable: false, visible: false, ordem: 30 },
            { field: "Dtregistro", title: "Registro", sortable: false, visible: false, ordem: 31 },
            { field: "Dtultimaalteracao", title: "Última Alteração", sortable: false, visible: false, ordem: 32 },
            { field: "Dtultimoacesso", title: "Último acesso", sortable: false, visible: false, ordem: 33 },
            { field: "Idantigo", title: "Antigo", sortable: false, visible: false, ordem: 34 },
            { field: "Qtdacesso", title: "Acesso", sortable: false, visible: false, ordem: 35 },
            { field: "Receberfeeds", title: "Receber Feeds", sortable: false, visible: false, ordem: 36 },
        ];

        var loadColumns = function () {
            $scope.Columnsreport = [];
            for (var i = 0; i < $scope.Columns.length; i++) {
                var item = $scope.Columns[i];
                //if (item.visible) continue;
                $scope.Columnsreport.push({
                    'text': item.title, "icon": "fa fa-picture-o c-red", 'id': item.field, 'ordem': item.ordem, 'visible': item.visible
                });
            }
            setTimeout(function () {
                pluginsService.init();
            }, 100);
        }

        $scope.addColumn = function () {
            var selected = $('input[class=checkColumns]:checked');
            if (selected.length == 0) {
                notyService.Noty("Atenção", "Para adicionar favor selecione uma ou mais colunas.", notyService.Type.Info, false, function (n) { return n; });
                return;
            }

            for (var i = 0; i < selected.length; i++) {
                var ordem = parseInt(selected[i].getAttribute('ordem', 0));
                var text = selected[i].getAttribute('text', 0);
                var id = selected[i].getAttribute('id', 0);
                $scope.Columnsreport[ordem - 1].visible = true;
                $("#" + id).iCheck('uncheck');
            }

            setTimeout(function () {
                pluginsService.init();
            }, 100);
        }

        $scope.removeColumn = function () {
            var selected = $('input[class=checkColumnsSelect]:checked');
            if (selected.length == 0) {
                notyService.Noty("Atenção", "Para remover favor selecione uma ou mais colunas.", notyService.Type.Info, false, function (n) { return n; });
                return;
            }
            for (var i = 0; i < selected.length; i++) {
                var ordem = parseInt(selected[i].getAttribute('ordem', 0));
                var text = selected[i].getAttribute('text', 0);
                var id = selected[i].getAttribute('id', 0);
                $scope.Columnsreport[ordem - 1].visible = false;
                $("#" + id).iCheck('uncheck');
            }

            setTimeout(function () {
                pluginsService.init();
            }, 100);
        }

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            $.ajaxSetup({
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", 'Bearer ' + authData.token);
                    xhr.setRequestHeader("refresh_token", authData.refresh_token);
                }
            });
        }
        loadColumns();
        getAllEscolaridade();
        getAllOrgaos();
        getAllEventos();
    }]);

app.controller('reportinscricaoController', ['$scope', 'ordersService', function ($scope, ordersService) {
    $scope.title = "Relatório de Inscrições";
    $scope.model = [
        {
            selected: null,
            ListName: "Não Selecionados",
            items: [
                { field: "Dtboletoemitido", title: "Data Boleto" },
                { field: "Boletoemitido", title: "Boleto Emitido" },
                { field: "Dtpagamento", title: "Data Pagamento" },
                { field: "Valorrecebido", title: "Valor Recebido" },
                { field: "Turno", title: "Turno" },
                { field: "Cargo", title: "Cargo" },
                { field: "Tpnecessidade", title: "Necessidade" },
                { field: "Neespecial", title: "Necessidade Especial" },
                { field: "Baixa", title: "Baixa" },
            ]
        },
        {
            selected: null,
            ListName: "Selecionados",
            items: [
                { field: "Id", title: "Id" },
                { field: "Evento", title: "Evento" },
                { field: "NomeCliente", title: "Cliente" },
                { field: "Dtinscricao", title: "Inscrição" },
                { field: "Valor", title: "Valor" },
                { field: "Formapagamento", title: "Forma Pagamento" },
                { field: "Pago", title: "Pago" },
                { field: "Criado", title: "Criado" },
                { field: "Ultimaateracao", title: "Última Ateração" },
            ]
        }
    ];

    $scope.onDrop = function (srcList, srcIndex, targetList, targetIndex) {
        // Copy the item from source to target.
        targetList.splice(targetIndex, 0, srcList[srcIndex]);
        // Remove the item from the source, possibly correcting the index first.
        // We must do this immediately, otherwise ng-repeat complains about duplicates.
        if (srcList == targetList && targetIndex <= srcIndex) srcIndex++;
        srcList.splice(srcIndex, 1);
        // By returning true from dnd-drop we signalize we already inserted the item.
        return true;
    };
}]);

app.controller('reportnecessidadeController', ['$scope', 'ordersService', function ($scope, ordersService) {
    $scope.title = "Relatório de Necessidades Especiais";
}]);
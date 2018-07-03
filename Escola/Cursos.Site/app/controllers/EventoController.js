"use strict";
app.controller("EventoController", ['$scope', 'eventoService', 'NotyService', 'pluginsService', '$route', 'LocaleventoService', "situacaoeventoService", "tipoeventoService", "eventoturnosService", "localStorageService",
    function ($scope, eventoService, notyService, pluginsService, $route, localeventoService, situacaoeventoService, tipoeventoService, eventoturnosService, localStorageService) {
        $scope.codigo = "Código";
        $scope.title = "Evento";
        $scope.tblData = [];
        $scope.evento = {};
        $scope.evento.Exibirlocal = "NAO";
        $scope.evento.Disponivel = "NAO";
        $scope.locaisevento = [];
        $scope.situacoes = [];
        $scope.tiposeventos = [];
        $scope.exibicao = "exibição";
        $scope.inscricao = "Inscrição";
        $scope.descricao = "Descrição";
        $scope.inicio = "Início";
        $scope.termino = "Término";
        $scope.informacoes = "Informações";
        $scope.atualizacao = "Atualização";
        $scope.realizacao = "Realização";
        $scope.endereco = "Endereço";
        $scope.TipoEvento = {};
        $scope.SituacaoEvento = {};
        $scope.eventodatas = [];
        $scope.eventoturnos = [];
        $scope.evento.Turnos = [];
        $scope.evento.Eventodatas = [];
        $scope.eventodata = {};
        $scope.acoes = "Ação";
        $scope.tab = "tab0";
        $scope.tabinfo = 0;
        $scope.Inscricao = [
            { value: "Abertas" },
            { value: "Encerradas" },
        ];
        setTimeout(function () {
            pluginsService.init();
        }, 500);

        Array.prototype.indexOfId = function (id) {
            for (var i = 0; i < this.length; i++)
                if (this[i].id === id)
                    return i;
            return -1;
        }

        $scope.navTab = function (tab) {
            $scope.tab = "tab" + tab;
        }
        $scope.navTabInfo = function (tab) {
            $scope.tabinfo = tab;
        }
        $scope.turnos = [
            {
                ListName: "Turnos",
                items: [
                    { title: "Mãnha", id: 1 },
                    { title: "Tarde", id: 2 },
                    { title: "Noite", id: 3 }
                ]
            },
            {
                ListName: "Turnos Vinculados",
                items: []
            }
        ];

        $scope.onDrop = function (srcList, srcIndex, targetList, targetIndex) {
            // Copy the item from source to target.
            targetList.items.push(srcList.items[targetIndex])
            // Remove the item from the source, possibly correcting the index first.
            // We must do this immediately, otherwise ng-repeat complains about duplicates.
            if (srcList.items == targetList.items && targetIndex <= srcIndex) srcIndex++;
            srcList.items.splice(srcIndex, 1);
            return true;
        };

        $scope.showModal = function (action) {
            if ($scope.evento.Eventodatas === undefined || $scope.evento.Eventodatas == null) {
                $scope.evento.Eventodatas = [];
            }

            if (action === "new") {
                $scope.evento = {};
                $scope.evento.Inscricao = "";
                $scope.evento.Situacao = "";
                $scope.evento.Turno = "";
                $scope.evento.Turnos = [];
                $scope.evento.Eventodatas = [];
                loadSummernote();
            }
            document.getElementById("modal-evento").style.display = "block";
            document.getElementById("panel-pesquisa").style.display = "none";
            $("#modal-evento").removeClass().addClass("panel bounceInRight animated active");
            $("#modal-evento").data("action", action);
        }

        $scope.exitModal = function () {
            $("#modal-evento").removeClass().addClass("bounceOut animated");
            $("#panel-pesquisa").removeClass().addClass("panel bounceIn animated");
            $("#panel-pesquisa").show();
            $(".header").removeClass("preview active");
            $(".modal").data("action", "none");
            $scope.isEdit = false;
            $route.reload();
        }

        var loadSummernote = function () {
            $('#Mensagemcomprovante').summernote('destroy');
            if ($scope.evento.Mensagemcomprovante !== undefined) {
                $('#Mensagemcomprovante').summernote('code', $scope.evento.Mensagemcomprovante);
                $('#Mensagemcomprovante').summernote('destroy');
            }
            $("#Mensagemcomprovante").summernote({ height: "150px" });

            $('#Mensagemboleto').summernote('destroy');
            if ($scope.evento.Descricao !== undefined) {
                $('#Mensagemboleto').summernote('code', $scope.evento.Mensagemboleto);
                $('#Mensagemboleto').summernote('destroy');
            }
            $("#Mensagemboleto").summernote({ height: "150px" });

            $('#Descricao').summernote('destroy');
            if ($scope.evento.Descricao !== undefined) {
                $('#Descricao').summernote('code', $scope.evento.Descricao);
                $('#Descricao').summernote('destroy');
            }
            $("#Descricao").summernote({ height: "150px" });
        }
        
        $scope.addEventoData = function () {
            if ($scope.eventodata.Dtinicio === undefined ||
                $scope.eventodata.Dttermino === undefined ||
                $scope.eventodata.Horainicio === undefined ||
                $scope.eventodata.Horatermino === undefined) {
                notyService.Noty("Atenção", "Favor informar as datas e horarios para o evento.", notyService.Type.Info, false, function (n) { return n; });
                return;
            }

            $scope.evento.Eventodatas.push($scope.eventodata);
            $scope.eventodata = {};
        }

        $scope.removeEventoData = function (id) {
            var index = $scope.evento.Eventodatas.indexOfId(id);
            $scope.evento.Eventodatas.splice(index);
        }

        $scope.Edit = function (row) {
            $scope.$apply(function () {
                $("#Localid").select2('val', row.Localid);
                $("#Tipoevento").select2('val', row.Tpevento);
                $("#Situacao").select2('val', row.Situacao);
                $("#Inscricao").select2('val', row.Inscricao);
                $scope.TipoEvento = row.Tpevento;
                $scope.SituacaoEvento = row.Situacao;
                $scope.Dtinicio = formatDate(new Date(row.Dtinicio), "dd/MM/yyyy");
                $scope.Dttermino = formatDate(new Date(row.Dttermino), "dd/MM/yyyy");
                $scope.Vencimentoboleto = formatDate(new Date(row.Vencimentoboleto), "dd/MM/yyyy");

                if (row.Inscricao === "Abertas") $("#Inscricao").select2('val', row.Inscricao);

                row.Dtinicio = formatDate(new Date(row.Dtinicio), "dd/MM/yyyy");
                row.Dttermino = formatDate(new Date(row.Dttermino), "dd/MM/yyyy");
                row.Dtatualizacao = formatDate(new Date(row.Dtatualizacao), "dd/MM/yyyy");
                row.Vecimentoboleto = formatDate(new Date(row.Vecimentoboleto), "dd/MM/yyyy");

                if (row.Disponivel === "NAO") {
                    $scope.evento.Disponivel = "NAO";
                    $("#Disponivel").iCheck('uncheck');
                } else {
                    $scope.evento.Disponivel = "SIM";
                    $("#Disponivel").iCheck('check');
                }
                if (row.Exibirlocal === "NAO") {
                    $scope.evento.Exibirlocal = "NAO";
                    $("#ExibirLocal").iCheck('uncheck');
                } else {
                    $scope.evento.Exibirlocal = "SIM";
                    $("#ExibirLocal").iCheck('check');
                }

                if (row.Turnos.length > 0) {
                    for (var i = 0; i < row.Turnos.length; i++) {
                        var descricao = "";
                        if (row.Turnos[i].Idturno === 1) descricao = "Manha";
                        if (row.Turnos[i].Idturno === 2) descricao = "Tarde";
                        if (row.Turnos[i].Idturno === 3) descricao = "Noite";
                        $scope.turnos[1].items.push({ title: descricao, value: row.Turnos[i].Idturno });
                        var index = $scope.turnos[0].items.indexOfId(row.Turnos[i].Idturno);
                        $scope.turnos[0].items.splice(index, 1);
                    }
                }
                for (var i = 0; i < row.Eventodatas.length; i++) {
                    row.Eventodatas[i].Dtinicio = formatDate(new Date(row.Eventodatas[i].Dtinicio), "dd/MM/yyyy");
                    row.Eventodatas[i].Dttermino = formatDate(new Date(row.Eventodatas[i].Dttermino), "dd/MM/yyyy");
                }
                $scope.evento = row;
            });
            $("#name").val($scope.evento.Name);
            $scope.showModal("edit");
            loadSummernote();
        }

        var getEventoTurnos = function () {
            eventoturnosService.GetAll(function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;
                    $scope.eventoturnos = response.data;
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

        var getSituacoes = function () {
            situacaoeventoService.GetAll(function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;
                    $scope.situacoes = response.data;
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

        var getTiposEventos = function () {
            tipoeventoService.GetAll(function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;
                    $scope.tiposeventos = response.data;
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

        var getLocaisEvento = function () {
            localeventoService.GetAll(function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;
                    $scope.locaisevento = response.data;
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

        var validate = function () {
            $("#formEvento").validate({
                ignore: '',
                rules: {
                    Nome: {
                        required: true,
                        minlength: 6,
                        maxlength: 250
                    },
                    Quantidadevagas: {
                        required: true,
                        min: 1,
                        max: 1000
                    },
                    Frequencia: {
                        required: true,
                        min: 50,
                        max: 100
                    }
                },
                messages: {
                    Horainicio: {
                        required: "Informe hora início"
                    },
                    Horatermino: {
                        required: "Informe hora término"
                    },
                    Dtinicio: {
                        required: "Informe Data início"
                    },
                    Dttermino: {
                        required: "Informe Data término"
                    },

                    Quantidadevagas: {
                        required: "Este campo e obrigatório"
                    },
                    Endereco: {
                        required: "Informe o endereço do local"
                    },
                    Frequencia: {
                        required: "Este campo e obrigatório"
                    },
                    Vecimentoboleto: {
                        required: "Informe o vencimento do boleto"
                    },
                    Localid: {
                        required: "Por favor selecione o local.",
                    },
                    Nome: {
                        required: "Informe o nome.",
                        minlength: "O nome deve ter pelo menos 6 caracteres",
                        maxlength: "O nome deve ter no máximo 6 caracteres"
                    },
                    Inscricao: {
                        required: "Por favor selecione inscrições.",
                    },
                    Situacao: {
                        required: "Por favor selecione uma situação.",
                    },
                    Tipoevento: {
                        required: "Por favor selecione um tipo de evento",
                    }
                }
            });
        }

        $('#Disponivel').on('ifChecked', function (event) {
            $scope.evento.Disponivel = "SIM";
        });

        $('#Disponivel').on('ifUnchecked', function (event) {
            $scope.evento.Disponivel = "NAO";
        });

        $('#ExibirLocal').on('ifChecked', function (event) {
            $scope.evento.ExibirLocal = "SIM";
        });

        $('#ExibirLocal').on('ifUnchecked', function (event) {
            $scope.evento.ExibirLocal = "NAO";
        });

        $("#Localid").on("change ", function (e) {
            if (e.added) {
                if (e.added.id === "") return;
                $scope.evento.Localid = e.added.id;
            }
        });

        $("#Inscricao").on("change ", function (e) {
            if (e.added) {
                if (e.added.id === "") return;
                $scope.evento.Inscricao = e.added.id;
            }
        });

        $("#Situacao").on("change ", function (e) {
            if (e.added) {
                if (e.added.id === "") return;
                $scope.evento.Situacao = e.added.id;
            }
        });

        $("#Tipoevento").on("change ", function (e) {
            if (e.added) {
                if (e.added.id === "") return;
                $scope.evento.Tpevento = e.added.id;
            }
        });

        $scope.Save = function () {
            if ($scope.evento.Localid === undefined) {
                notyService.Noty("Atenção", "Favor informar o local de realização do evento.", notyService.Type.Info, false, function (n) { return n; });
                $("#Localid").focus();
                return;
            }
            if ($scope.evento.Inscricao === undefined || $scope.evento.Inscricao === "") {
                notyService.Noty("Atenção", "Favor informar status da inscrição aberta ou encerradas.", notyService.Type.Info, false, function (n) { return n; });
                $("#Inscricao").focus();
                return;
            }
            if ($scope.evento.Situacao === undefined || $scope.evento.Situacao === "") {
                notyService.Noty("Atenção", "Favor informar status situacao.", notyService.Type.Info, false, function (n) { return n; });
                $("#Situacao").focus();
                return;
            }
            if ($scope.evento.Tpevento === undefined || $scope.evento.Tpevento === "") {
                notyService.Noty("Atenção", "Favor informar tipo do evento.", notyService.Type.Info, false, function (n) { return n; });
                $("#Situacao").focus();
                return;
            }

            if ($scope.evento.Valorevento === undefined || $scope.evento.Valorevento <= 0) {
                notyService.Noty("Atenção", "Favor informar valor do evento.", notyService.Type.Info, false, function (n) { return n; });
                $("#Valorevento").focus();
                return;
            }

            try {
                var dateParts = $scope.Dtinicio.split("/");
                $scope.evento.Dtinicio = new Date(dateParts[2], dateParts[1] - 1, dateParts[0]);
            } catch (e) {
            }
            try {
                var dateParts1 = $scope.Dttermino.split("/");
                $scope.evento.Dttermino = new Date(dateParts1[2], dateParts1[1] - 1, dateParts1[0]);
            } catch (e) {
            }
            try {
                var dateParts3 = $scope.Vecimentoboleto.split("/");
                $scope.evento.Vecimentoboleto = new Date(dateParts3[2], dateParts3[1] - 1, dateParts3[0]);
            } catch (e) {
            }

            for (var i = 0; i < $scope.evento.Eventodatas.length; i++) {
                try {
                    var dateParts = $scope.evento.Eventodatas[i].Dtinicio.split("/");
                    $scope.evento.Eventodatas[i].Dtinicio = new Date(dateParts[2], dateParts[1] - 1, dateParts[0]);
                } catch (e) {
                }
                try {
                    var dateParts1 = $scope.evento.Eventodatas[i].Dttermino.split("/");
                    $scope.evento.Eventodatas[i].Dttermino = new Date(dateParts1[2], dateParts1[1] - 1, dateParts1[0]);
                } catch (e) {
                }
            }

            $scope.evento.Descricao = $("#Descricao").summernote("code");
            $scope.evento.Mensagemcomprovante = $("#Mensagemcomprovante").summernote("code");

            if ($scope.turnos[1].items.length > 0) {
                for (var i = 0; i < $scope.turnos[1].items.length; i++) {
                    if ($scope.evento.Turnos.indexOfId($scope.turnos[1].items[i].id) < 0) {
                        $scope.evento.Turnos.push({ Idevento: $scope.evento.Id, Idturno: $scope.turnos[1].items[i].id });
                    }
                }
            }

            if (!$scope.formEvento.$valid) return;

            var action = $("#modal-evento").data("action");
            if (action === "new") {
                eventoService.Post($scope.evento, function (response) {
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
                eventoService.GetById($scope.evento.Id, function (response) {
                    if (response.status === 200) {
                        if (!response.data) {
                            notyService.Noty("Alerta!", "Não foi localizado o registro favor contate o suporte!", notyService.Type.Warning, false, function (n) { return n; });
                            return;
                        }

                        var equal = angular.equals($scope.evento, response.data[0]);
                        if (equal) {
                            notyService.Noty("Informacao!", "Não teve alterações no registro, não e possivel salvar.", notyService.Type.Info, false, function (n) { return n; });
                            return;
                        }
                        eventoService.Put($scope.evento, function (response) {
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
                    eventoService.Delete(entity, function (response) {
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
            { field: "Nome", title: "Nome", sortable: true },
            { field: "Situacao", title: "Situação", sortable: true },
            { field: "Disponivel", title: "Disponível", sortable: true },
            { field: "Exibirlocal", title: "Exibir Local", sortable: false, visible: false },
            { field: "Inscricao", title: "Inscrição", sortable: true },
            { field: "Temaid", title: "Tema", sortable: false, visible: false },
            { field: "Valorevento", title: "Valor Evento", sortable: true },
            { field: "Qtdvagas", title: "Vagas", sortable: false, visible: true },
            { field: "Frequencia", title: "Frequência", sortable: false, visible: false },
            { field: "DataInicio", title: "Início", sortable: true },
            { field: "DataTermino", title: "Término", sortable: true },
            { field: "Horainicio", title: "Hora Início", sortable: false, visible: false },
            { field: "Horatermino", title: "Hora Término", sortable: false, visible: false },
            { field: "Local", title: "Local", sortable: false, visible: false },
            { field: "Endereco", title: "Endereço", sortable: false, visible: false },
            { field: "Descricao", title: "Descrição", sortable: true, visible: false },
            { field: "Mensagemboleto", title: "Mensagem Boleto", sortable: true, visible: false },
            { field: "Mensagemcomprovante", title: "Mensagem Comprovante", sortable: true, visible: false }
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

        validate();
        getLocaisEvento();
        getTiposEventos();
        getSituacoes();
        getEventoTurnos();
    }]);
"use strict";
app.controller("ClienteController", ['$scope', 'clienteService', 'NotyService', 'orgaoemissorService', 'ufService',
    'orgaosService', 'escolaridadeService', 'municipioService', 'pluginsService', '$route', 'cepService', 'localStorageService', 'eventoService', 'ngAuthSettings',
    function ($scope, clienteService, notyService, orgaoemissorService, ufService, orgaosService, escolaridadeService,
        municipioService, pluginsService, $route, cepService, localStorageService, eventoService, ngAuthSettings) {
        var serviceBase = ngAuthSettings.apiServiceBaseUri;

        setTimeout(function () {
            pluginsService.init();
        }, 500);
        $scope.inscricao = "Inscrições";
        $scope.isValidCep = false;
        $scope.codigo = "Código";
        $scope.title = "Cliente";
        $scope.tblData = [];
        $scope.orgaosEmissor = [];
        $scope.ufs = [];
        $scope.municipios = [];
        $scope.cliente = {};
        $scope.informacoes = "Informações";
        $scope.instituicao = "Instituição";
        $scope.orgao = "Orgão";
        $scope.administrador = 0;
        $scope.tab = "tab1";
        $scope.orgaos = [];
        $scope.escolaridades = [];
        $scope.isEdit = false;
        $scope.cpfvalid = true;
        $scope.invalido = "Inválido";
        $scope.endereco = "Endereço";
        $scope.filtro = {};

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

        $scope.confirmarSenha = function () {
            if ($scope.cliente.Senha !== $scope.cliente.Senha2) return false;
            return true;
        }

        $scope.showModal = function (action) {
            if (action === "new") {
                $scope.cliente = {};
                $scope.cliente.Nacionalidade = "Brasileiro";
                $scope.isEdit = false;
            }
            $scope.cliente.Senha2 = $scope.cliente.Senha;
            document.getElementById("modal-cliente").style.display = "block";
            document.getElementById("panel-pesquisa").style.display = "none";
            $("#modal-cliente").removeClass().addClass("bounceInRight animated active");
            $(".header").removeClass("active");
            $("#modal-cliente").data("action", action);
        }

        $scope.exitModal = function () {
            $("#modal-cliente").removeClass().addClass("bounceOut animated");
            $("#panel-pesquisa").removeClass().addClass("panel bounceIn animated");
            $("#panel-pesquisa").show();
            //$("#panel-pesquisa").removeClass().addClass("bounceOut animated");
            $(".header").removeClass("preview active");
            $("#modal-cliente").data("action", "none");
            $scope.isEdit = false;
            $route.reload();
        }

        $scope.Edit = function (row) {
            $scope.$apply(function () {
                if (row.Nacionalidade === null) {
                    row.Nacionalidade = "Brasileiro";
                }
                //bind select
                $("#Orgaoemissor").select2('val', row.Orgaoemissor);
                $("#Ufemissor").select2('val', row.Ufemissor);
                $("#Ufemissor").select2('val', row.Ufemissor);
                $("#Naturalidade").select2('val', row.Naturalidade);
                $("#Orgaotrabalhoid").select2('val', row.Orgaotrabalhoid);
                $("#Escolaridadeid").select2('val', row.Escolaridadeid);

                if (row.Enviosenha === "NAO") {
                    $scope.cliente.Enviosenha = "NAO";
                    $("#Enviosenha").iCheck('uncheck');
                } else {
                    $scope.cliente.Enviosenha = "SIM";
                    $("#Enviosenha").iCheck('check');
                }
                if (row.Receberfeeds === 0) {
                    $scope.cliente.Receberfeeds = 0;
                    $("#Receberfeeds").iCheck('uncheck');
                } else {
                    $scope.cliente.Enviosenha = 1;
                    $("#Receberfeeds").iCheck('check');
                }
                if (row.Sexo === "MASCULINO") {
                    $("#SexoMasculino").iCheck('check');
                } else {
                    $("#SexoFeminino").iCheck('check');
                }

                row.Dtconclusao = formatDate(new Date(row.Dtconclusao), "dd/MM/yyyy");
                row.Dtregistro = formatDate(new Date(row.Dtregistro), 'dd/MM/yyyy');
                if (row.Inscricoes.length > 0) {
                    for (var item in row.Inscricoes) {
                        if (item.hasOwnProperty) {
                            row.Inscricoes[item]["Dtinscricao"] = formatDate(new Date(row.Inscricoes[item]["Dtinscricao"]), "dd/MM/yyyy");
                        }
                    }
                }
                $("#Enviosenha").val()
                $scope.cliente = row;
                $scope.selected = row.Orgaoemissor;
            });
            $("#name").val($scope.cliente.Nome);
            $scope.isEdit = true;
            $scope.showModal("edit");
        }

        $scope.ValidarCpf = function (str) {
            var str = $scope.cliente.Cpf;
            if (str) {
                str = str.replace('.', '');
                str = str.replace('.', '');
                str = str.replace('-', '');

                var cpf = str;
                var numeros, digitos, soma, i, resultado, digitos_iguais;
                digitos_iguais = 1;
                if (cpf.length < 11)
                    return false;
                for (i = 0; i < cpf.length - 1; i++)
                    if (cpf.charAt(i) != cpf.charAt(i + 1)) {
                        digitos_iguais = 0;
                        break;
                    }
                if (!digitos_iguais) {
                    numeros = cpf.substring(0, 9);
                    digitos = cpf.substring(9);
                    soma = 0;
                    for (i = 10; i > 1; i--)
                        soma += numeros.charAt(10 - i) * i;
                    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                    if (resultado != digitos.charAt(0))
                        return false;
                    numeros = cpf.substring(0, 10);
                    soma = 0;
                    for (i = 11; i > 1; i--)
                        soma += numeros.charAt(11 - i) * i;
                    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                    if (resultado != digitos.charAt(1))
                        return false;
                    return true;
                }
                else
                    return false;
            }
        }

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

        $("#Nomefiltro").on("keypress", function (e) {
            var nome = $("#Nomefiltro").val();
            if (nome.length > 4) {
                $scope.filtro.Nome = nome;
                searchFilter(JSON.stringify($scope.filtro));
            }
        });

        $("#Cpffiltro").on("blur", function (e) {
            var cpf = $("#Cpffiltro").val();

            if (cpf.length > 4) {
                $scope.filtro.Cpf = cpf.replace('.', '').replace('.', '').replace('-', '');;
                searchFilter(JSON.stringify($scope.filtro));
            }
        });

        $("#Emailfiltro").on("keypress", function (e) {
            var email = $("#Emailfiltro").val();
            if (email.length > 4) {
                $scope.filtro.Email = email;
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

        $("#Orgaoemissor").on("change ", function (e) {
            if (e.added) {
                if (e.added.id === "") {
                    return;
                }

                $scope.cliente.Orgaoemissor = e.added.id;
            }
        });

        $("#Ufemissor").on("change ", function (e) {
            if (e.added) {
                if (e.added.id === "") {
                    return;
                }

                $scope.cliente.Ufemissor = e.added.id;
            }
        });

        $("#Naturalidade").on("change ", function (e) {
            if (e.added) {
                if (e.added.id === "") {
                    return;
                }

                $scope.cliente.Naturalidade = e.added.id;
            }
        });
        
        $("#Orgaotrabalhoid").on("change ", function (e) {
            if (e.added) {
                if (e.added.id === "") {
                    return;
                }

                $scope.cliente.Orgaotrabalhoid = e.added.id;
            }
        });

        $("#Escolaridadeid").on("change ", function (e) {
            if (e.added) {
                if (e.added.id === "") {
                    return;
                }

                $scope.cliente.Escolaridadeid = e.added.id;
            }
        });

        $scope.refresh = function () {
            $route.reload();
        }

        $scope.ShowDetail = function (row) {
            var feeds = row.Receberfeeds == 0 ? 'Sim' : 'Não';
            var telressidencial = row.Telresidencial === null ? 'Sem Informação' : row.Telresidencial;
            var telcomercial = row.Telcomercial === null ? 'Sem Informação' : row.Telcomercial;
            var orgao = row.Orgaotrabalhoid === 0 ? 'Sem Informação' : row.Orgaotrabalhoid;
            var complemento = row.Complemento === null ? 'Sem Informação' : row.Complemento;
            var numero = row.Numero === 0 ? 'Sem número' : row.Numero;

            var html = [];
            html.push('<div class="panel widget-member clearfix">');
            html.push('<div class="col-xs-1">');
            if (row.Sexo === "MASCULINO") {
                html.push('<img src="../assets/global/images/avatars/avatar12@2x.png" alt="avatar 12" class="pull-left img-responsive">');
            } else {
                html.push('<img src="../assets/global/images/avatars/avatar5@2x.png" alt="avatar 12" class="pull-left img-responsive">');
            }

            html.push('</div>');
            html.push('<div class="col-xs-11">');
            html.push(' <h3 class="m-t-0 member-name"><strong>' + row.Nome + '</strong></h3>');
            html.push(' <p class="member-job"><strong>Orgão de Trabalho:</strong> ' + row.Orgaotrabalhoid + ' <strong>Acessos: </strong>' + row.Qtdacesso + '</p>');
            html.push(' <div class="row">');
            html.push('    <div class="col-xlg-2 align-right">');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i> <strong>Nas.:</strong> ' + row.Dtnascimento + '</p>');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i> <strong>Doc.:</strong> ' + row.Rg + '</p>');
            html.push('        <p><i class="icon-target c-gray-light p-r-10"></i> <strong>Orgão:</strong> ' + row.Orgaoemissor + '<strong> UF: </strong>' + row.Ufemissor + '</p>');
            html.push('    </div>');
            html.push('    <div class="col-xlg-2 align-right">');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Emissao:</strong> ' + row.Dtemissao + '</p>');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>CPF:</strong> ' + row.Cpf + '</p>');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Natural:</strong> ' + row.Naturalidade + '</p>');
            html.push('    </div>');
            html.push('    <div class="col-xlg-2 align-right">');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Res.:</strong> ' + telressidencial + '</p>');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Com.:</strong> ' + telcomercial + '</p>');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Alteracao:</strong> ' + row.Dtultimaalteracao + '</p>');
            html.push('    </div>');
            html.push('    <div class="col-xlg-2 align-right">');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Conc.:</strong> ' + row.Dtconclusao + '</p>');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Ult. Acesso:</strong> ' + row.Dtultimoacesso + '</p>');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Feeds:</strong> ' + feeds + '</p>');
            html.push('    </div>');
            html.push('    <div class="col-xlg-4 align-right">');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Cep:</strong> ' + row.Cep + '</strong></p>');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>End.:</strong> ' + row.Endereco + '<strong> Bairro: </strong>' + row.Bairro + '</p>');
            html.push('        <p><i class="icon-calendar c-gray-light p-r-10"></i><strong>Comp.:</strong> ' + complemento + ' <strong>Número: </strong>' + numero + '</p>');
            html.push('    </div>');
            html.push('</div>');
            html.push('</div>');
            html.push('</div>');
            html.push('</div>');
            var $detail = $(".detail-view td");
            $detail.append(html.join(""));
        };

        $scope.getCep = function () {
            if ($scope.cliente.Cep === undefined) return;
            var cep = $scope.cliente.Cep.replace('.', '').replace('-', '');
            cepService.GetEndereco(cep, function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data);
                    if (emptyData) return;
                    $scope.isValidCep = true;
                    $scope.cliente.Endereco = response.data.Endereco;
                    $scope.cliente.Bairro = response.data.Bairro;
                    $scope.cliente.Cidade = response.data.Cidade;
                    $scope.cliente.Estado = response.data.Uf;
                    $scope.cliente.Complemento = response.data.Complemento;
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

        var elementsEvents = function () {
            $("#Enviosenha").on("ifChecked", function (event) {
                $scope.cliente.Enviosenha = "SIM";
            });
            $("#Enviosenha").on("ifUnchecked", function (event) {
                $scope.cliente.Enviosenha = "NAO";
            });
            $("#Receberfeeds").on("ifChecked", function (event) {
                $scope.cliente.Receberfeeds = 1;
            });
            $("#Receberfeeds").on("ifUnchecked", function (event) {
                $scope.cliente.Receberfeeds = 0;
            });
            $("#SexoMasculino").on("ifChecked", function (event) {
                $scope.cliente.Sexo = "MASCULINO";
            });
            $("#SexoMasculino").on("ifUnchecked", function (event) {
                $scope.cliente.Sexo = "FEMININO";
            });
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

        var getAllMunicipio = function () {
            municipioService.GetAll(function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;
                    $scope.municipios = response.data;
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

        var getAllOrgaoEmissor = function () {
            orgaoemissorService.GetAll(function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;
                    $scope.orgaosEmissor = response.data;
                } else {
                    var message = "";
                    for (var item in response.data) {
                        if (response.data.hasOwnProperty(item)) {
                            message += response.data[item];
                        }
                    }
                    if (message === "") {
                        message = "Ocorreu erro ao consultar orgaos emissor!"
                    }
                    notyService.Noty("Erro", message, notyService.Type.Danger, false, function (n) { return n; });
                }
            });
        };

        var getAllUf = function () {
            ufService.GetAll(function (response) {
                if (response.status === 200) {
                    var emptyData = jQuery.isEmptyObject(response.data[0]);
                    if (emptyData) return;
                    $scope.ufs = response.data;
                } else {
                    var message = "";
                    for (var item in response.data) {
                        if (response.data.hasOwnProperty(item)) {
                            message += response.data[item];
                        }
                    }
                    if (message === "") {
                        message = "Ocorreu erro ao consultar UFs!"
                    }
                    notyService.Noty("Erro", message, notyService.Type.Danger, false, function (n) { return n; });
                }
            });
        };

        var getAll = function () {
            clienteService.GetAll(function (response) {
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
                    if (message === "") {
                        message = "Ocorreu erro ao consultar clientes!"
                    }
                    notyService.Noty("Erro", message, notyService.Type.Danger, false, function (n) { return n; });
                }
            });
        };

        $scope.Save = function () {
            var action = $("#modal-cliente").data("action");
            if (action === "new") {
                clienteService.Post($scope.cliente, function (response) {
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
                        notyService.Noty("Weventos ocorreu erro ao salvar registro favor contatar suporte do sistema!", message, notyService.Type.Danger, false, function (n) { return n; });
                    }
                });
            } else if (action === "edit") {
                clienteService.GetById($scope.cliente.Id, function (response) {
                    if (response.status === 200) {
                        if (!response.data) {
                            notyService.Noty("Alerta!", "Não foi localizado o registro favor contate o suporte!", notyService.Type.Warning, false, function (n) { return n; });
                            return;
                        }

                        var equal = angular.equals($scope.cliente, response.data[0]);
                        if (equal) {
                            notyService.Noty("Informacao!", "Não teve alterações no registro, não e possivel salvar.", notyService.Type.Info, false, function (n) { return n; });
                            return;
                        }
                        clienteService.Put($scope.cliente, function (response) {
                            if (response.status === 200 || response.status === 201) {
                                notyService.Noty("Informação", response.data + " registro atualizado com sucesso! ", notyService.Type.Success, false, function (n) { return n; });
                            } else {
                                var message = "";
                                for (var item in response.data) {
                                    if (response.data.hasOwnProperty(item)) {
                                        message += response.data[item];
                                    }
                                }
                                notyService.Noty("Weventos ocorreu erro ao atualizar registro favor contatar suporte do sistema!", message, notyService.Type.Danger, false, function (n) { return n; });
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
                    clienteService.Delete(entity, function (response) {
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
                            notyService.Noty("Weventos ocorreu erro ao excluir registro favor contatar suporte do sistema!", message, notyService.Type.Danger, false, function (n) { return n; });
                        }
                    });
                }
            });
        }

        $scope.Columns = [
            { field: "Id", title: "Código", sortable: false, visible: false },
            { field: "Nome", title: "Nome", sortable: true, filter: { type: "input" } },
            { field: "Email", title: "Email", sortable: true, filter: { type: "input" } },
            { field: "Rg", title: "Rg", sortable: true, filter: { type: "input" } },
            { field: "Orgaoemissor", title: "Orgao Emissor", sortable: true, visible: false },
            { field: "Ufemissor", title: "Uf Emissor", sortable: true, visible: false },
            { field: "Dtemissao", title: "Emissao", sortable: true, visible: false },
            { field: "Cpf", title: "Cpf", sortable: true, filter: { type: "input" } },
            { field: "Nacionalidade", title: "Nacionalidade", sortable: false, visible: false },
            { field: "Naturalidade", title: "Naturalidade", sortable: true, visible: false },
            { field: "Dtnascimento", title: "Nascimento", sortable: true, visible: false },
            { field: "Sexo", title: "Sexo", sortable: true, filter: { type: "input" } },
            { field: "Nomepai", title: "Nome Pai", sortable: false, visible: false },
            { field: "Nomemae", title: "Nome Mãe", sortable: false, visible: false },
            { field: "Cep", title: "Cep", sortable: false, visible: false },
            { field: "Endereco", title: "Endereço", sortable: false, visible: false },
            { field: "Bairro", title: "Bairro", sortable: false, visible: false },
            { field: "Numero", title: "Numero", sortable: false, visible: false, visible: false },
            { field: "Complemento", title: "Complemento", sortable: false, visible: false },
            { field: "Cidade", title: "Cidade", sortable: true, visible: true, filter: { type: "input" } },
            { field: "Estado", title: "Estado", sortable: true, visible: true, filter: { type: "input" } },
            { field: "Telresidencial", title: "Tel. Residencial", sortable: false, visible: false },
            { field: "Telcomercial", title: "Tel. Comercial", sortable: false, visible: false },
            { field: "Telcelular", title: "Tel. Celular", sortable: true, visible: true, filter: { type: "input" } },
            { field: "Senha", title: "Senha", sortable: false, visible: false },
            { field: "Cadadministracao", title: "Cad Administração", sortable: true, visible: false },
            { field: "Enviosenha", title: "Envio Senha", sortable: false, visible: false },
            { field: "Orgaotrabalhoid", title: "Orgão Trabalho", sortable: false, visible: false },
            { field: "Escolaridadeid", title: "Escolaridade", sortable: false, visible: false },
            { field: "Instituicao", title: "Instituição", sortable: false, visible: true, filter: { type: "input" } },
            { field: "Dtconclusao", title: "Conclusão", sortable: false, visible: false },
            { field: "Dtcadastro", title: "Registro", sortable: false, visible: false },
            { field: "Dtalteracao", title: "Última Alteração", sortable: false, visible: false },
            { field: "Dtultimoacesso", title: "Último acesso", sortable: false, visible: false },
            { field: "Idantigo", title: "Antigo", sortable: false, visible: false },
            { field: "Idorgaoantigo", title: "Orgão Antigo", sortable: false, visible: false },
            { field: "Idescolaridadeantigo", title: "Escolaridade Antigo", sortable: false, visible: false },
            { field: "Qtdacesso", title: "Acesso", sortable: false, visible: false },
            { field: "Receberfeeds", title: "Receber Feeds", sortable: false, visible: false },
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
        getAllEventos();
        getAllOrgaoEmissor();
        getAllUf();
        getAllOrgaos();
        getAllEscolaridade();
        getAllMunicipio();
        elementsEvents();
    }]);
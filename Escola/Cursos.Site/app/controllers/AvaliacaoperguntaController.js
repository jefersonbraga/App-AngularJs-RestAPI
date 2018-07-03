///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 18/09/2017
///// Last Update: 11/11/2017 5:17:46 PM

///// Para outros metodos implementar classe partial
///// </sumary>
"use strict";
app.controller("AvaliacaoperguntaController", ['$scope', 'AvaliacaoperguntaService', 'NotyService', 'avaliacaoService', 'pluginsService','$route',
    function ($scope, AvaliacaoperguntaService, notyService, avaliacaoService, pluginsService, $route) {
		$scope.tblData = [];
        $scope.Avaliacaopergunta = {};
        $scope.avaliacao = "Avaliação";
        $scope.codigo = "Código";

        setTimeout(function () {
            pluginsService.init();
        }, 500);

        $scope.showModal = function (action) {
			if(action === "new")
				$scope.Avaliacaopergunta = {};

			document.getElementById("modal-Avaliacaopergunta").style.display = "block";
            $("#modal-Avaliacaopergunta").removeClass().addClass("modal bounceInRight animated active");
            $(".header").removeClass("active");
            $(".modal").data("action", action);
        }

		$scope.exitModal = function () {
			$("#modal-Avaliacaopergunta").removeClass().addClass("modal bounceOut animated");
            $(".header").removeClass("preview active");
            $(".modal").data("action", "none");
            $route.reload();
        }

		$scope.Edit = function (row) {
			//$timeout($scope.increment, 1000);
            $scope.$apply(function () {
                $("#Avaliacao").select2('val', row.Avaliacaoid);

			  $scope.Avaliacaopergunta = row;
			});
            $("#name").val($scope.Avaliacaopergunta.Name);
            if (!$scope.Avaliacaopergunta.Active) {
                $("#active").parent().removeClass("checked");
            } else {
                $("#active").parent().addClass("checked");
            }
            $scope.showModal("edit");
        }
		
		var getAll = function () {
            AvaliacaoperguntaService.GetAll(function (response) {
                if (response.status === 200) {
					var emptyData = jQuery.isEmptyObject(response.data[0]);
					if(emptyData) return;
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

        $("#Avaliacao").on("change ", function (e) {
            if (e.added) {
                if (e.added.id === "") {
                    return;
                }
                $scope.Avaliacaopergunta.Avaliacaoid = e.added.id;
            }
        });

        $scope.Save = function () {
            var action = $(".modal").data("action");
            $scope.Avaliacaopergunta.Avaliacaoid = $scope.Avaliacaopergunta.Avaliacaoid;
            if (action === "new") {
		        AvaliacaoperguntaService.Post($scope.Avaliacaopergunta, function (response) {
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
		        AvaliacaoperguntaService.GetById($scope.Avaliacaopergunta.Id, function (response) {
		            if (response.status === 200) {
		                if (!response.data) {
		                    notyService.Noty("Alerta!", "Não foi localizado o registro favor contate o suporte!", notyService.Type.Warning, false, function (n) { return n; });
		                    return;
		                }
		               
		                var equal = angular.equals($scope.Avaliacaopergunta, response.data[0]);
		                if (equal) {
		                    notyService.Noty("Informacao!", "Não teve alterações no registro, não e possivel salvar.", notyService.Type.Info, false, function (n) { return n; });
		                    return;
		                }
		                AvaliacaoperguntaService.Put($scope.Avaliacaopergunta, function (response) {
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
		    notyService.Noty("Confirmacao", "Deseja excluir este registro: "+entity.Name+"? ", notyService.Type.Warning, true, function (confimation) {
		        if (confimation) {
		            AvaliacaoperguntaService.Delete(entity, function (response) {
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

		$scope.Columns = [
        				{ field: "Id", title: "Id", sortable: false, visible:false },
							{ field: "Avaliacaoid", title: "Avaliacaoid", sortable: false, visible:false },
							{ field: "Titulo", title: "Titulo", sortable: true },
							{ field: "Ordem", title: "Ordem", sortable: false, visible:true },
							{ field: "Dtcadastro", title: "Cadastro", sortable: true },
							{ field: "Dtatualizacao", title: "Atualização", sortable: true },
							{ field: "Dtexclusao", title: "Dtexclusao", sortable: true, visible:false },
					];

        getAll();
        getAllAvaliacoes();
    }]);


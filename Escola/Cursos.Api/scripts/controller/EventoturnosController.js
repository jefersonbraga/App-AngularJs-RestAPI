///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 18/09/2017
///// Last Update: 11/13/2017 1:58:57 PM

///// Para outros metodos implementar classe partial
///// </sumary>
"use strict";
app.controller("EventoturnosController", ['$scope', 'EventoturnosService', 'NotyService', function ($scope, EventoturnosService, notyService) {
		$scope.tblData = [];
		$scope.Eventoturnos = {};
        $scope.showModal = function (action) {
			if(action === "new")
				$scope.Eventoturnos = {};

			document.getElementById("modal-Eventoturnos").style.display = "block";
            $("#modal-Eventoturnos").removeClass().addClass("modal bounceInRight animated active");
            $(".header").removeClass("active");
            $(".modal").data("action", action);
        }

		$scope.exitModal = function () {
			$("#modal-Eventoturnos").removeClass().addClass("modal bounceOut animated");
            $(".header").removeClass("preview active");
            $(".modal").data("action", "none");
        }

		$scope.Edit = function (row) {
			//$timeout($scope.increment, 1000);
			$scope.$apply(function() {
			  $scope.Eventoturnos = row;
			});
            $("#name").val($scope.Eventoturnos.Name);
            if (!$scope.Eventoturnos.Active) {
                $("#active").parent().removeClass("checked");
            } else {
                $("#active").parent().addClass("checked");
            }
            $scope.showModal("edit");
        }
		
		var getAll = function () {
            EventoturnosService.GetAll(function (response) {
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

        $scope.Save = function () {
		    var action = $(".modal").data("action");
		    if (action === "new") {
		        EventoturnosService.Post($scope.Eventoturnos, function (response) {
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
		        EventoturnosService.GetById($scope.Eventoturnos.Id, function (response) {
		            if (response.status === 200) {
		                if (!response.data) {
		                    notyService.Noty("Alerta!", "Não foi localizado o registro favor contate o suporte!", notyService.Type.Warning, false, function (n) { return n; });
		                    return;
		                }
		               
		                var equal = angular.equals($scope.Eventoturnos, response.data[0]);
		                if (equal) {
		                    notyService.Noty("Informacao!", "Não teve alterações no registro, não e possivel salvar.", notyService.Type.Info, false, function (n) { return n; });
		                    return;
		                }
		                EventoturnosService.Put($scope.Eventoturnos, function (response) {
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
		            EventoturnosService.Delete(entity, function (response) {
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
        				{ field: "Idevento", title: "Idevento", sortable: false, visible:false },
							{ field: "Idturno", title: "Idturno", sortable: false, visible:false },
							{ field: "Dtcadastro", title: "Dtcadastro", sortable: true },
							{ field: "Dtatualizacao", title: "Dtatualizacao", sortable: true },
							{ field: "Dtexclusao", title: "Dtexclusao", sortable: true },
					];

		getAll();
    }]);


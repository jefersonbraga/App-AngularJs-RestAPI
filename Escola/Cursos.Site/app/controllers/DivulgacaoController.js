
"use strict";
app.controller("DivulgacaoController", ['$scope', 'divulgacaoService', 'NotyService', '$route', function ($scope, divulgacaoService, notyService, $route) {
    $scope.codigo = "Código";
    $scope.title = "Divulgação";
    $scope.tblData = [];
	$scope.divulgacao = {};
   
    $scope.change = function (contents) {
        console.log('contents are changed:', contents, $scope.editable);
    };

    $scope.showModal = function (action) {
        if (action === "new") {
            $scope.divulgacao = {};
            $('#Mensagem').summernote('destroy');
            $('#Mensagem').summernote('code', $scope.divulgacao.Mensagem);
            $('#Mensagem').summernote('destroy');
            $("#Mensagem").summernote({ height: "300px" });
        }
			

        document.getElementById("modal-divulgacao").style.display = "block";
        document.getElementById("panel-pesquisa").style.display = "none";
        $("#modal-divulgacao").removeClass().addClass("bounceInRight animated active");
        $(".header").removeClass("active");
        $("#modal-divulgacao").data("action", action);
    }

	$scope.exitModal = function () {
		$("#modal-divulgacao").removeClass().addClass("modal bounceOut animated");
        $(".header").removeClass("preview active");
        $("#modal-divulgacao").data("action", "none");
        $route.reload();
    }

	$scope.Edit = function (row) {
        $scope.$apply(function() {
			$scope.divulgacao = row;
		});
        $("#name").val($scope.divulgacao.Name);
        if (!$scope.divulgacao.Active) {
            $("#active").parent().removeClass("checked");
        } else {
            $("#active").parent().addClass("checked");
        }
        $scope.showModal("edit");
        $('#Mensagem').summernote('destroy');
        $('#Mensagem').summernote('code', $scope.divulgacao.Mensagem);
        $('#Mensagem').summernote('destroy');
        $("#Mensagem").summernote({ height: "300px" });
    }
		
	var getAll = function () {
        divulgacaoService.GetAll(function (response) {
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
        var action = $("#modal-divulgacao").data("action");
        $scope.divulgacao.Mensagem = $("#Mensagem").summernote("code");
		if (action === "new") {
		    divulgacaoService.Post($scope.divulgacao, function (response) {
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
		    divulgacaoService.GetById($scope.divulgacao.Id, function (response) {
		        if (response.status === 200) {
		            if (!response.data) {
		                notyService.Noty("Alerta!", "Não foi localizado o registro favor contate o suporte!", notyService.Type.Warning, false, function (n) { return n; });
		                return;
		            }
		               
		            var equal = angular.equals($scope.divulgacao, response.data[0]);
		            if (equal) {
		                notyService.Noty("Informacao!", "Não teve alterações no registro, não e possivel salvar.", notyService.Type.Info, false, function (n) { return n; });
		                return;
		            }
		            divulgacaoService.Put($scope.divulgacao, function (response) {
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
		        divulgacaoService.Delete(entity, function (response) {
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

    $scope.ShowDetail = function (row) {
        var html = [];
        html.push('<div class="panel clearfix">');
        html.push('<div class="col-xs-12">');
        html.push(' <h3 class="m-t-0 member-name"><strong>' + row.Titulo + '</strong></h3>');
        html.push(' <div class="row">');
        html.push('    <div class="col-xlg-12">');
        html.push(row.Mensagem);
        html.push('    </div>');
        html.push('</div>');
        html.push('</div>');
        html.push('</div>');
        var $detail = $(".detail-view td");
        $detail.append(html.join(""));
    };
	$scope.Columns = [
        			{ field: "Id", title: "Id", sortable: false, visible:false },
						{ field: "Titulo", title: "Titulo", sortable: true },
                        { field: "Mensagem", title: "Mensagem", sortable: false, visible: false },
						{ field: "Dtcriacao", title: "Criação", sortable: true },
						{ field: "Dtalteracao", title: "Alteração", sortable: true },
				];

	getAll();
}]);


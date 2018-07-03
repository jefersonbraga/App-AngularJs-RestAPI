angular.module("wescolaApp").directive("dmpTable", function ($parse, $window, ngAuthSettings) {
    return function (scope, element, attrs) {
        var serviceBase = ngAuthSettings.apiServiceBaseUri;
        var getOptions = function () {
            var options = {};
            var lenghtColumns = 0;

            $window.operateEvents = {
                "click .edit": function (e, value, row, index) {
                    scope.Edit(row);
                },
                "click .delete": function (e, value, row, index) {
                    scope.Delete(row);
                }
            };

            $window.operateEventsAction = {
                "click .boleto": function (e, value, row, index) {
                    scope.Boleto(row);
                },
                "click .etiqueta": function (e, value, row, index) {
                    scope.Etiqueta(row);
                },
                "click .comprovante": function (e, value, row, index) {
                    scope.Comprovante(row);
                }
            };

            function operateAnotherAction(value, row, index) {
                var elementReturn = [];
                var boletoElement = "<a class=\"boleto btn btn-sm btn-primary\" href=\"javascript:void(0)\" title=\"2º Via Boleto\" style=\"margin:1px\"><i class=\"fa fa-money\"></i></a>";
                var etiquetaElement = "<a class=\"etiqueta btn btn-sm btn-blue\" href=\"javascript:void(0)\" title=\"Etiqueta\" style=\"margin:1px\"><i class=\"fa fa-tags\"></i></a>";
                var comprovanteElement = "<a class=\"comprovante btn btn-sm btn-info\" href=\"javascript:void(0)\" title=\"Comprovante\" style=\"margin:1px\"><i class=\"fa fa-newspaper-o\"></i></a>";

                var boleto = attrs.aaEdit;
                var etiqueta = attrs.aaEtiqueta;
                var comprovante = attrs.aaComprovante;

                if (boleto === "true") elementReturn += boletoElement;
                if (etiqueta === "true") elementReturn += etiquetaElement;
                if (comprovante === "true") elementReturn += comprovanteElement;
                return elementReturn;
            }

            function operateFormatter(value, row, index) {
                var elementReturn = [];
                var editElement = "<a class=\"edit btn btn-sm btn-default\" href=\"javascript:void(0)\" title=\"Editar\" style=\"margin:1px\"><i class=\"icon-note\"></i></a>";
                var deleteElement = "<a class=\"delete btn btn-sm btn-danger\" href=\"javascript:void(0)\" title=\"Excluir\" style=\"margin:1px\"><i class=\"icons-office-52\"></i></a>";
                
                var editDelete = attrs.aaEditdelete;
                var edit = attrs.aaEdit;
                var deleteE = attrs.aaDelete;
               

                if (edit === "true" || editDelete === "2") elementReturn += editElement;
                if (deleteE === "true") elementReturn += deleteElement;
                return elementReturn;
            }

            var filter = attrs.aaFilter;
            var search = attrs.aaSearch;
            var showExport = attrs.aaExport;
            var showColumns = attrs.aaShowcolumns;
            var showToggle = attrs.aaShowtoggle;
            var height = attrs.aaHeight;
            var dataUrl = attrs.aaUrl;
            var serverSide = attrs.aaServer;

            if (search !== "true") {
                search = false;
            } else {
                search = true;
            }
            if (showExport !== "true") {
                showExport = false;
            } else {
                showExport = true;
            }
            if (showColumns !== "true") {
                showColumns = false;
            } else {
                showColumns = true;
            }
            if (showToggle !== "true") {
                showToggle = false;
            } else {
                showToggle = true;
            }
            if (typeof height === "undefined") {
                height = 500;
            }

            if (attrs.dmpTable.length > 0) {
                options = scope.$eval(attrs.dmpTable);
            } else {
                options = {
                    cache: true,
                    height: height,
                    striped: true,
                    pagination: true,
                    pageSize: 10,
                    pageList: [10, 20, 30],
                    search: search,
                    showColumns: showColumns,
                    showRefresh: false,
                    showExport: showExport,
                    minimumCountColumns: 2,
                    clickToSelect: true,
                    showToggle: showToggle,
                    maintainSelected: false,
                    locale: "pt-BR",
                    filter: filter
                };
            }
            if (dataUrl !== undefined) {
                options.url = serviceBase + dataUrl;
            }
            if (serverSide !== undefined) {
                options.sidePagination = serverSide;
            }
            // Diga o plugin datatables que colunas de usar
            // pode derivar -los do dom, ou usar a configuração do controlador
            if (scope.Columns) {

                for (var i = 0; i < scope.Columns.length; i++) {
                    if (scope.Columns[i].visible === true) lenghtColumns += 1;
                }

                if (attrs.aaAnotheraction === "true") {
                    scope.Columns.splice(lenghtColumns, 0, {
                        field: "operate",
                        title: "Opções Emissão",
                        align: "center",
                        formatter: operateAnotherAction,
                        events: operateEventsAction,
                        width: "150px"
                    });
                }

                if (attrs.aaAction === "true") {
                    scope.Columns.splice(0, 0, {
                        field: "operate",
                        title: "Ações",
                        align: "center",
                        formatter: operateFormatter,
                        events: operateEvents,
                        width: "100px"
                    });
                }

                var columns = [];
                if (scope.$eval(attrs.aoRemovecolumn)) {
                    for (var j = 0; j < scope.Columns.length; j++) {
                        var arrRemove = attrs.aoRemovecolumn.split(";");
                        if (arrRemove.indexOf(j.toString()) === -1) {
                            columns.push(scope.Columns[j]);
                        }
                    }
                } else {
                    columns = scope.Columns;
                }

                options["columns"] = columns;
                return options;
            }
        }

        var editableTable = function () {
            // apply DataTable options, use defaults if none specified by user
            var options = getOptions();

            var oTable = element.bootstrapTable(options);

            oTable.on("expand-row.bs.table", function (e, index, row, $detail) {
                scope.ShowDetail(row);
            });
            return oTable;
        };

        var dataTable = editableTable();

        scope.$watch(attrs.aaData, function (value) {
            var val = value || null;
            if (val) {
                for (x in val) {
                    for (column in val[x]) {
                        if (column === "Dtinicio" || column === "Dttermino" || column === "Dtcadastro"
                            || column === "Dtalteracao" || column === "Dtexclusao"
                            || column === "Dtcadastro" || column === "Dtconclusao" || column === "Dtatualizacao"
                            || column === "Dtboletoemitido" || column === "Dtpagamento" || column === "Dtinscricao") {
                            val[x][column] = formatDate(new Date(val[x][column]), "dd/MM/yyyy");
                        }
                        //if (isDateValue(val[x][column])) {
                        //}
                    }
                }
                dataTable.bootstrapTable("load", scope.$eval(attrs.aaData));
            }
        });
    };
});
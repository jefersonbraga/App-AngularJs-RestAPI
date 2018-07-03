app.directive("model", function ($parse, $rootScope) {

    /* find the scope of the controller using the scope passed */
    function findCtrlScope(scope) {
        /*for unit test cases, scope is rootScope, so in that case, we return*/
        if (scope.ctrlScope || scope.$id === $rootScope.$id) {
            /* able to find ctrlScope from scope */
            return;
        }

        var tScope = scope;
        do {
            tScope = tScope.$parent;
            if (tScope.ctrlScope) { /* found the ctrlScope */
                scope.ctrlScope = tScope.ctrlScope;
                /* save a reference to ctrlScope in scope */
                break;
            }
        } while (tScope.$id !== $rootScope.$id);
        /* loop exit condition */
    }
    /**
    * Calculate validity of string
    * @param {string} str
    * @returns {boolean}
    */
    function validaCPF(str) {
       
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

    return {
        link: function (scope, element, attrs) {
            var isolateScope = scope,
                ctrlScope = element.scope(),
                model = attrs.model,
                name,
                _model;

            if (model) { /* if the model is provided as an attribute on element parse it */
                _model = $parse(model);
                /* using _model we will be able to update the model in the controller */
            }

            /* not able to access ctrlScope from tScope(element.scope()). try to find it. */
            if (!ctrlScope.ctrlScope) {
                findCtrlScope(ctrlScope);
            }

            if (!ctrlScope.ctrlScope) {
                return; /* if ctrlScope not found*/
            }

            if (model) {
                dotIdx = model.indexOf(".");
                braceIdx = model.indexOf("[");
                if (dotIdx === -1 && braceIdx === -1) {
                    /* model is provided with a variable name eg. model = x, we need to update in the controller directly */
                    ctrlScope = ctrlScope.ctrlScope;
                    /* refer to the scope of controller */
                } else {
                    /* model might be provided as obj.variable name or obj[key] */
                    if (braceIdx === -1) {
                        idx = dotIdx;
                        /* dot is present in the model value*/
                    } else if (dotIdx === -1) {
                        idx = braceIdx;
                        /* brace is present in the model value*/
                    } else {
                        /* both dot and brace are present i.e a.b[x] */
                        idx = Math.min(dotIdx, braceIdx);
                        /* extract the object name from the model */
                    }
                    if (idx > 0) {
                        /* if the object specified is not defined in the controller's scope. create a new object with the extracted name */
                        name = model.substring(0, idx);
                        /* name of the object to be created */
                        if (!angular.isDefined(ctrlScope.ctrlScope[name])) { /* object is not defined in controller's scope */

							/*
							 * we will always define a Object ie. {} if the controller's scope doesn't have it.
							 * if other than Object is expected i.e, Array, user must initialize it in controller's scope
							 */
                            ctrlScope.ctrlScope[name] = {};
                            /* define the object in controller's scope */
                        }

                        if (angular.isUndefined(ctrlScope[name])) { /* not able to access object from ctrlScope */
                            Object.defineProperty(ctrlScope, name, {
                                get: function () {
                                    return ctrlScope.ctrlScope[name];
                                    /* whenever object is accessed from scope, read it from controller's scope and return */
                                }
                            });
                        }
                    }
                }
            }

            /* this method will update the view value in the controller's scope */
            function updateModel() {
                if (_model && ctrlScope) {
                    /* update the model value in the controller if the controller scope is available */
                    _model.assign(ctrlScope, isolateScope._model_);
                }
            }

            /* _onChange is a wrapper fn for onChange. */
            isolateScope._onChange = function ($event) {
                updateModel();
                /* update the view value in the controller */
                if (isolateScope.onChange) {
                    isolateScope.onChange({ $event: $event, $scope: isolateScope });
                    /* trigger the onChange fn */
                }
            };

            /* update the view value when the model is updated */
            if (model && ctrlScope) {
                /* watch the model */

                ctrlScope.$watch(model, function (newVal) {
                    /* update the view value if the model is updated */
                    isolateScope._model_ = newVal;

                }, true);
            }
        }
    }
});

app.directive("validateCpf", function () {
    return {
        restrict: "E",
        scope: {
            "value": "=",
            "onChange": "&"
        },
        template: '<input type="text" class="form-control form-white" data-ng-model="value" data-ng-change="onChange();" data-mask="999.999.999-99">',
    }
});
///**
// * @author Alvaro Paçó <alvaro@scalasoft.com.br>
// * @see {@link http://www.geradorcpf.com/javascript-validar-cpf.htm}
// */
//(function () {
//  'use strict';

//  //angular.module('validate-cpf', [])
//  /**
//   * Validate CPF directive
//   * @param {ngModel} model The Model to bind
//   * @returns {boolean/'undefined'}
//   */
//    app.directive('validateCpf', function () {
//      return {
//        require: 'ngModel',
//        link: function (scope, element, attrs, ctrl) {

//            scope.$watch('ngModel', function (newValue, oldValue) {
//                console.log(newValue);
//                //var someVar = [Do something with someVar];

//                // angular copy will preserve the reference of $scope.someVar
//                // so it will not trigger another digest 
//                //angular.copy(someVar, $scope.someVar);

//            });

//            element.bind("change", function () {
//            //valida o cpf
//            ctrl.$setValidity('validateCpf', validaCPF(ctrl.$modelValue));
//            scope.$apply();

//            //remove error-message
//            element.parent().removeClass('ng-invalid alert-danger');
//            element.parent().find('.alert-status-invalid').remove();
//            //if cpf invalido
//            if (ctrl.$dirty && ctrl.$invalid) {
//              element.parent().addClass('has-error');
//              element.parent().append(' <label class=" alert-status-invalid ' +
//                'control-label" for="inputError1">CPF Inválido</label>');
//              // Setting $valid to false
//              ctrl.$setValidity('validateCpf', false);
//              // Needle to work
//              return undefined;
//            } else {
//              //if success remove error-message
//              element.parent().removeClass('has-error');
//              element.parent().find('.alert-status-invalid').remove();
//              // Return the same value to work with ui-mask
//              // because if return another value, the ui-mask
//              // will be called again and validate too.
//              return ctrl.$viewValue;
//            }
//          });
            
//        }
//      };
//    });

//}).call(this);
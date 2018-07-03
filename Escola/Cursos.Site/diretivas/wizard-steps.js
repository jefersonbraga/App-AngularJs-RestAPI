 app.directive('wizard', [function() {
    return {
      restrict: 'EA',
      scope: {
          finishing: '=',
          stepChanging: '=',
          finished: '=',
          canceled: '='
      },
      compile: function(element, attr) {
          element.steps({
              height: "auto",
              bodyTag: attr.bodyTag,
              headerTag: attr.headerTag,
              transitionEffect: attr.transitionEffect,
              cssClass: attr.cssClass,
              labels: {
                  cancel: "Cancelar",
                  current: "current step:",
                  pagination: "Pagination",
                  finish: "Salvar",
                  next: "Próximo",
                  previous: "Anterior",
                  loading: "Carregando ..."
              }
          });
        
        return {
          //pre-link
          pre:function() {},
          //post-link
          post: function(scope, element) {
              element.on('stepChanging', scope.stepChanging).on('finishing', scope.finishing).on('finished', scope.finished);
              //element.on('finished', scope.finished);
              //element.on('canceled', scope.canceled);
          }
        }
      }
    };
  }]);
  
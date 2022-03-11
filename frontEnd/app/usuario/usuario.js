'use strict';

angular.module('myApp.usuario', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/usuario', {
    templateUrl: 'usuario/usuario.html',
    controller: 'UsuarioCtrl'
  });
}])

//Buscar Cadastro de Usuarios
.controller('UsuarioCtrl', ['$scope', '$http', '$location', function($scope, $http, $location) {
  function init() {
    var request = {
      method: 'GET',
      url: 'https://localhost:7225/Usuario'
    };
    $http(request).then(function(response) {
      $scope.usuarios = response.data;
    });
  }

  $scope.excluir = function(id) {
    if (confirm("Deseja excluir o usuário?")) {
      var request = {
        method: 'DELETE',
        url: 'https://localhost:7225/Usuario/' + id,
        headers: {
          'Content-Type': 'application/json'
        }
      };
      $http(request)
          .then(function() {
            alert("Pessoa excluída com sucesso!");
            init();
          }).catch(function() {
        alert("Erro ao excluir a pessoa!");
      });
    }
  };
  init();

}]);





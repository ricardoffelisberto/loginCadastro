'use strict';

angular.module('myApp.cadastro', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
    $routeProvider.when('/cadastro', {
        templateUrl: 'cadastro/cadastro.html',
        controller: 'CadastroCtrl'
    });
}])

//Criar Cadastro
.controller('CadastroCtrl', ['$scope', '$http', '$location', function($scope, $http, $location) {
    $scope.criar = function() {
        var user = $scope.user;
        var request = {
            method: 'POST',
            url: 'https://localhost:7225/Usuario',
            headers: {
                'Content-Type': 'application/json'
            },
            data: user
        };
        $http(request)
            .then(function() {
                alert(`Pessoa cadastrada com Sucesso ${$scope.user.cpf.substring(0,4)}`);
                $location.path("/usuario");
            }).catch(function() {
        });
    };

}]);
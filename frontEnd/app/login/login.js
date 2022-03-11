'use strict';

angular.module('myApp.login', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/login', {
    templateUrl: 'login/login.html',
    controller: 'LoginCtrl'
  });
}])

//Requisição de Usuário para Login
.controller('LoginCtrl', ['$scope', '$http', '$location', function($scope, $http, $location) {
  $scope.login = function() {
    var user = $scope.user;
    var request = {
      method: 'POST',
      url: 'https://localhost:7225/Login',
      headers: {
        'Content-Type': 'application/json'
      },
      data: user
    };
    $http(request)
        .then(function() {
          $location.path("/usuario");
        }).catch(function() {
          alert("Usuário e/ou senha incorretos.");
    });
  };

}]);
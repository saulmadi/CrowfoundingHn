angular.module("crowfoundingHn").controller("LoginController", ["$scope", "$window", "LoginService", function ($scope, $window, LoginService) {
    
    $scope.signIn = function (model) {
        
    };
    $scope.signUp = function(model) {
        LoginService.signUp(model).success(function(response) {
            $window.location = "/#/login";
        });
    };

}]);
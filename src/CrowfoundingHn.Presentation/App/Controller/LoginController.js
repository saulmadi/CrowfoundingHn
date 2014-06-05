angular.module("crowfoundingHn").controller("LoginController", ["$scope", function($scope) {
    
    $scope.signIn = function (model) {
        alert(model.Email + " " + model.Password);
    };

}]);
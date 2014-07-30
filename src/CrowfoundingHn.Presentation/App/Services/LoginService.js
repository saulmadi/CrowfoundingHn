angular.module("crowfoundingHn").factory("LoginService", ["$http", function($http) {
    var factory = {};

    factory.signUp = function(userRequest) {
        return $http({
            url: "/auth/create",
            method: "POST",
            data: userRequest
        });
    };

    factory.signIn = function(loginRequest) {

        return $http({
            url: "/auth/signin",
            method: "POST",
            data:loginRequest
        });
    };

    return factory;

}]);
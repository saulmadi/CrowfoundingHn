angular.module("crowfoundingHn").factory("LoginService", ["$http", function($http) {
    var factory = {};

    factory.signUp = function(userRequest) {
        return $http({
            url: "/auth/create",
            method: "POST",
            data: userRequest
        });
    };

    return factory;

}]);
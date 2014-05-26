angular.module("crowfoundingHn").factory("ProjectService", ["$http", function($http) {

    var factory = {};
    var getHeaders = function () {
        return {
            "Content-Type": "application/json"
        };
    };
    factory.createProject = function(project) {
        return $http({
            url: "/projects",
            method: "POST",
            data: project,
            headers: getHeaders()
        });
    };
    return factory;
}]);
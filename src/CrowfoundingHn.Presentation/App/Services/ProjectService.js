angular.module("crowfoundingHn").factory("ProjectService", ["$http", function($http) {

    var factory = {};
    
    factory.createProject = function(project) {
        return $http({
            url: "/projects",
            method: "POST",
            data: project,
    
        });
    };
    return factory;
}]);
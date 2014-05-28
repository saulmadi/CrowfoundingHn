angular.module("crowfoundingHn").controller("ProjectController", ['$scope', "ProjectService", function($scope, ProjectService) {

    $scope.addProject = function(project) {
        ProjectService.createProject(project).success(function() {

        });
    };

}]);
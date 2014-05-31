angular.module("crowfoundingHn").controller("ProjectController", ['$scope', "ProjectService", function($scope, ProjectService) {

    
    $scope.open = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.opened = true;
    };

  

    $scope.addProject = function(project) {
        ProjectService.createProject(project).success(function() {

        });
    };

}]);
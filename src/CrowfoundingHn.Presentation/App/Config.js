var app = angular.module("crowfoundingHn", ["ng", "ngRoute", "ui.bootstrap"]);

app.config(function($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: 'App/Views/home.html'
        })
        .when("/projects", {
            templateUrl: 'App/Views/project.html',
            controller: "ProjectController"
        })
        .when("/register", {
            templateUrl: 'App/Views/register.html',
            controller: "LoginController"
        });
});

app.run(function($http) {
    $http.defaults.headers.common.Accept = "application/json";
});
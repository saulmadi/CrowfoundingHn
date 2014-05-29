﻿var app = angular.module("crowfoundingHn", ["ng", "ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
        templateUrl: 'App/Views/home.html'
        })
        .when("/projects", {
            templateUrl: 'App/Views/project.html',
            controller: "ProjectController"
        });
})
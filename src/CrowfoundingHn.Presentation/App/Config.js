var app = angular.module("crowfoundingHn", ["ng", "ngRoute", "ui.bootstrap", "LocalStorageModule"]);

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

app.run(['$http','localStorageService',function($http,localStorageService) {
    $http.defaults.headers.common.Accept = "application/json";
    $http.defaults.headers.common.Authorization = "OAuth " + localStorageService.get('AuthToken');
}]);


app.run(['$rootScope', '$window', 'LoginService', 'localStorageService', function ($scope, $window, LoginService, localStorageService) {


    $scope.showMail = false;
    var token = localStorageService.get('AuthToken');

    if (token) {
        $scope.showMail = true;
        $scope.email = localStorageService.get('UserEmail');
    }
    
    $scope.logIn = function(loginModel) {

        LoginService.signIn(loginModel).success(function(response) {
            if (response.token) {
                $scope.showLoginFail = false;
                localStorageService.set('AuthToken', response.token);
                localStorageService.set('UserEmail', loginModel.Email);
                $scope.showMail = true;

                $scope.email = loginModel.Email;


            } else {
                $scope.showLoginFail = true;
                $scope.showMail = false;
            }
            
        });
    };

   
}]);
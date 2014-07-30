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


app.config(['$httpProvider', function ($httpProvider) {
    console.log("defining 401 status code interceptor");
    $httpProvider.interceptors.push(['$q', '$location', 'localStorageService', function ($q, $location, localStorageService) {
        return {
            'responseError': function(rejection) {
                console.log("Response error: "+ JSON.stringify(rejection));
                var isLogin = rejection.config.url.indexOf("login") > -1;
                if (rejection.status == 401 && !isLogin) {
                    console.log("Not logged in. Redirecting first");
                    var token = 'AuthToken';
                    localStorageService.remove(token);
                    $location.path('/');                        
                }
                return $q.reject(rejection);
            }
        };
    }]);
}])

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
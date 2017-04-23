'use strict';

var AuthApp = angular.module('AuthApp', []);

AuthApp.factory('authInterceptorService', ['$q', '$injector', '$window', '$localStorageService', function ($q, $injector, $window, $localStorageService) {

    var authInterceptorService {}; 

    var authInterceptorServiceFactory.request = function(config ){}
     
        authInterceptorServiceFactory.responseError = function(rejection){
            if(rejection === 401)
            {
                var authService  = $injector.get('authService') ; 
                var authData = localStorageService.get('authorizationData');
            }
            return $q.reject(rejection);
        } ;
        return authInterceptorServiceFactory ; 
  

}]);


AuthApp.factory( 'authService' , ['$http' , '$q' , '$localStorageService' , function($http , $q , $localStorageService){

    var authServiceFactoru = {} ; 

    var authentication = {
    }

} ]) ; 
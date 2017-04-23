var manageRoleApp = angular.module('manageRoleApp', ['LocalStorageModule' , 'AuthApp']);

manageRoleApp.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

manageRoleApp.controller('manageRoleController', ['$scope', 'manageRoleService', function ($scope, manageRoleService) {
    $scope.init = function () {
        manageRoleService.GetAllRoles().then(function (response) {

            $scope.Roles = response.data;
        }, function () {
            alert('failed!'); 
        })
    }

    $scope.init();

    $scope.CreateRole = function () {
        manageRoleService.CreateRole($scope.RoleName).then(function () {

        }, function () {

            alert('failed crreate!');; 
        })
    }


    $scope.DeleteRole = function (id) {
        manageRoleService.DeleteRole(id).the(function () {

            alert('Delete');
            $scope.init(); 
        }, function () {
            alert('failed Delete'); 
        })
    }

}])




manageRoleApp.factory('manageRoleService', ['$http', function ($http) {
    var manageRoleAppfactory = {};

    manageRoleAppfactory.GetAllRoles = function () {
      return  $http.get('/api/AspNetRoles')
    }

    manageRoleAppfactory.CreateRole = function (newRoleName) {
       return $http.post('/api/AspNetRoles' , newRoleName )
    }

    manageRoleAppfactory.DeleteRole =  function (id){
     return   $http.delete('/api/AspNetRoles/'+ id  )

    }

        return manageRoleAppfactory ; 
}])
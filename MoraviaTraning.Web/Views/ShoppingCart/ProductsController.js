var ProductsApp = angular.module('ProductsApp', [])

ProductsApp.controller('ProductsController', function ($scope) {

    $scope.message = "Welcome to ProductsController...!!!";

});



var ProductsApp = angular.module('ProductsApp', []);
ProductsApp.controller('ProductsController', function ($scope, ProductsService) {

    getProducts();
    function getProducts() {
        ProductsService.getProducts()
            .success(function (prods) {
                $scope.products = prods;
                console.log($scope.products);
            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
            });
    }
});

ProductsApp.factory('ProductsService', ['$http', function ($http) {

    var ProductsService = {};
    ProductsService.getProducts = function () {
        return $http.get('/ShoppingCart/GetProducts');
    };
    return ProductsService;

}]);




//var StudentApp = angular.module('StudentApp', []);
//StudentApp.controller('StudentController', function ($scope, StudentService) {

//    getStudents();
//    function getStudents() {
//        StudentService.getStudents()
//            .success(function (studs) {
//                $scope.students = studs;
//                console.log($scope.students);
//            })
//            .error(function (error) {
//                $scope.status = 'Unable to load customer data: ' + error.message;
//                console.log($scope.status);
//            });
//    }
//});

//StudentApp.factory('StudentService', ['$http', function ($http) {

//    var StudentService = {};
//    StudentService.getStudents = function () {
//        return $http.get('/Home/GetPersons');
//    };
//    return StudentService;

//}]);



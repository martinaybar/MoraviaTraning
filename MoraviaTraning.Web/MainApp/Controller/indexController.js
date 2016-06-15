 angular
        .module('app')
          
        .controller('indexController', ['$scope','ProductsService', function ($scope,ProductsService) {
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
        }])
 .factory('ProductsService', ['$http', function ($http) {

     var ProductsService = {};
     ProductsService.getProducts = function () {
         return $http.get('/ShoppingCart/GetProducts');
     };
     return ProductsService;

 }]);
   






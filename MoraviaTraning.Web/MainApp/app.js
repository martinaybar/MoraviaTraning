angular.module('app', ['ui.router'])
   .config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {

       // For any unmatched url, send to /route1
       $urlRouterProvider.otherwise("/home")

       $stateProvider
         .state('products', {
             url: "/index",
             templateUrl: "/ShoppingCart/Products"
         })
       $stateProvider
         .state('home', {
             url: "/index",
             templateUrl: "/home"
         })
       $stateProvider
        .state('checkout', {
            url: "/index",
            templateUrl: "/Check/GetCheckout"
        })

}]);

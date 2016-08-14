/// <reference path="D:\Work\Labs101\Lab.Bootstrap\Lab.AngularJSWebApi\Scripts/angular.js" />
(function () {
    "use strict";
    var app = angular
    .module("productManager",
    ["common.services"]);

    app
    .controller("ProductController",
    ["productResource", ProductController]);

    function ProductController(productResource) {
        var vm = this;
        vm.message = "Product Controller"
        vm.categories = [
            "Groceries",
            "Toys",
            "Hardware"
        ]
        vm.category = vm.categories[1];
        productResource.query(function (data) {
            vm.products = data;
        })

        productResource.get({ id: 2 }, function (data) {
            vm.product = data;
        })

        vm.submitForm = function () {
            vm.product.$update({ id: vm.product.Id, cat: vm.category },
                function(data){
                    vm.message="... Save Complete";
                })
        };
        vm.search = function () {
            productResource.get({ id: 2 }, function (data) {
                vm.product = data;
            })
        };

    }
}());
/**
 * Created by Prasad on 06/08/2016.
 */
(function () {
    "use strcit";
    angular
        .module("productManagement")
        .controller("ProductDetailCtrl",
            ["product","productService",
                ProductDetailCtrl]);

    function ProductDetailCtrl(product,productService) {
        var vm = this;

        vm.product = product;

        vm.title = "Product Detail: " + vm.product.productName;

        if (vm.product.tags) {
            vm.product.tagList = vm.product.tags.toString();
        }
        vm.marginPercent =
            productService.calculateMarginPercent(vm.product.price,
                vm.product.cost);
    }
}());
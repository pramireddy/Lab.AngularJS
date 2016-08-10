/**
 * Created by Prasad on 06/08/2016.
 */
(function () {
    "user strict";
    angular
        .module("common.services")
        .factory("productResource",
            ["$resource", productResource]);

    function productResource($resource) {
      return $resource("/api/products/:productId");
    };
}());
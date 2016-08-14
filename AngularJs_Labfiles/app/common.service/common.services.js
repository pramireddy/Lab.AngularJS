/// <reference path="D:\Work\Labs101\Lab.Bootstrap\Lab.AngularJSWebApi\Scripts/angular.js" />
(function () {
    "use strict";
    angular
    .module("common.services", ["ngResource"])
        .constant("appSettings",
        {
            serverPath : "http://localhost:52399"
        });

}());
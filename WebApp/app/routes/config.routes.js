﻿(function() {

    'use strict';

    angular.module('routes.module')
        .config(configRoutes);

    configRoutes.$inject = [
        '$stateProvider',
        '$urlRouterProvider',
        'routeConfigProvider'];
    function configRoutes($stateProvider, $urlRouterProvider, routeConfigProvider) {
        var routes = routeConfigProvider.$get();

        $urlRouterProvider.otherwise('/home');

        //register all states
        for (var i = 0; i < routes.length; i++) {
            var route = routes[i];
            $stateProvider
                .state(route.state, {
                    url: route.url,
                    templateUrl: route.templateUrl,
                    controller: route.controller,
                    data: {
                        displayName: route.label,
                        isFlexible: route.isFlexible,
                        innavigable: route.innavigable
                    }
                });
        }
    }


})();
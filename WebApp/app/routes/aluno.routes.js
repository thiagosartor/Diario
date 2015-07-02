﻿(function () {
    'use strict';
    var KEYS = angular.injector(['common.module']).get('CONSTANT_KEYS');

    angular
        .module('routes.module')
        .config(configRoutes);

    configRoutes.$inject = [KEYS.APP_ROUTES];
    function configRoutes(routes) {
        routes.push({
            state: 'aluno',
            url: '/aluno',
            templateUrl: '/app/templates/components/inner-view.html'
        }, {
            state: 'aluno.list',
            url: '/list',
            controller: 'alunoListCtrl as vm',
            templateUrl: '/app/views/aluno/aluno-list.html'
        }, {
            state: 'aluno.details',
            url: '/details/:alunoId',
            controller: 'alunoDetailsCtrl as vm',
            templateUrl: '/app/views/aluno/aluno-details.html'
        }, {
            state: 'aluno.create',
            url: '/create',
            controller: 'alunoCreateCtrl as vm',
            templateUrl: '/app/views/aluno/aluno-create.html'
        }
);
    }
})();
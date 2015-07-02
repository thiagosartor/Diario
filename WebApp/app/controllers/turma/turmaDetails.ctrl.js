﻿(function () {
    "use strict";
    //using
    turmaDetailsCtrl.$inject = ["turmaService", "$stateParams", "$state"];

    //namespace
    angular
        .module("controllers.module")
        .controller("turmaDetailsCtrl", turmaDetailsCtrl);

    //class
    function turmaDetailsCtrl(turmaService, params, $state) {
        var vm = this;
        vm.title = "Atualizando de Turma";
        vm.turma = {};

        //script load
        activate();
        function activate() {
            turmaService.getTurmaById(params.turmaId)
                .then(function (results) {
                    vm.turma = results;
                });     
        }

        //public methods
        vm.save = function () {
            turmaService.edit(vm.turma);
            vm.clearFields();
        };

        vm.clearFields = function () {
            vm.turma = {};
            vm.turmaForm.$setPristine();
        }
    }
})();
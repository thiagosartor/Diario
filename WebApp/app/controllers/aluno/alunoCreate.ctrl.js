﻿(function (angular) {

    'use strict';
    //using
    alunoCreateCtrl.$inject = ["alunoService", "turmaService", "cepService", "$state", "$scope"];

    //namespace
    angular
        .module("controllers.module")
        .controller("alunoCreateCtrl", alunoCreateCtrl);

    //class
    function alunoCreateCtrl(alunoService, turmaService, cepService, $state, $scope) {
        var vm = this;
        vm.aluno = { endereco: { cep: "" } }; //Graças ao DTO tive que inicializar com um CEP para o serviço funcionar
        vm.title = "Cadastro de Alunos";
        activate();

        function activate() {
            turmaService.getTurmas()
                .then(function (data){
                    vm.turmas = data;
                });        
        }

        vm.save = function () {
            alunoService.save(convertDto(vm.aluno));
            vm.clearFields();
        };

        vm.clearFields = function () {
            vm.aluno = {};
            vm.aluno = { endereco: { cep: "" } };
            vm.alunoForm.$setPristine();
        }

        $scope.$watch(angular.bind(this, function () {
            if(vm.aluno)
            return vm.aluno.endereco.cep;
        }), function (newVal) {
            if (newVal) {
                cepService.getEndereco(newVal).then(function (result) {
                    vm.aluno.endereco.bairro = result.bairro;
                    vm.aluno.endereco.localidade = result.localidade;
                    vm.aluno.endereco.uf = result.uf;
                }).catch(function () {
                    vm.clearFields();
                    console.clear();
                    alert("CEP INVÁLIDO!");
                });
            }
        });

        function convertDto(aluno) {
            return {
                turmaId: aluno.turma.id,
                descricao: aluno.nome + ": Presenças: 0, Faltas: 0 ",
                cep: aluno.endereco.cep,
                bairro: aluno.endereco.bairro,
                localidade: aluno.endereco.localidade,
                uf: aluno.endereco.uf
            };
        }
    }
}(window.angular));

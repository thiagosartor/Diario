﻿(function () {
    'use strict';

    //using
    turmaService.$inject = ['$http', 'logger', 'BASEURL'];

    //namespace
    angular.module('services.module')
       .service('turmaService', turmaService);

    //class
    function turmaService($http, logger, baseUrl) {
        var self = this;
        var serviceUrl = baseUrl + "api/turma";

        self.getTurmas = function () {
            return $http.get(serviceUrl)
                .then(function (response) {
                return response.data;
            });
        };

        self.save = function (turma) {
            logger.success("Salvo com sucesso", turma);
            return $http.post(serviceUrl, turma);
        };

        self.delete = function (turma) {
            logger.error("Excluido com sucesso!", turma, "Delete");

            $http.delete(serviceUrl + "/" + turma.id);

        };

        self.getTurmaById = function (id) {
            logger.success("Turma com id " + id + " encontrada", null, "Busca");

            return $http.get(serviceUrl + "/" + id)
                .then(function (response) {
            return response.data;
        });
        };

        self.edit = function (turma) {
            logger.success("Turma " + turma.descricao + " editada", null, "Edição");

            $http.put(serviceUrl + "/" +  turma.id, turma);
        };
    }
})(window.angular);
﻿(function (angular) {
    'use strict';

    logger.$inject = ['$log'];
    angular
        .module('services.module')
        .factory('logger', logger);


    function logger($log) {
        var service = {
            showToasts: true,

            error: error
            , info: info
            , success: success
            ,warning: warning
            
            // straight to console; bypass toastr
            ,log: $log.log
            
            , successCallback: successCallback
            ,errorCallback:errorCallback

        };

        return service;
        ///////////////////// loggers

        function error(message, data, title) {
            toastr.error(message, title);
            $log.error('Error: ' + message, data);
        }

        function info(message, data, title) {
            toastr.info(message, title);
            $log.info('Info: ' + message, data);
        }

        function success(message, data, title) {
            toastr.success(message, title);
            $log.info('Success: ' + message, data);
        }

        function warning(message, data, title) {
            toastr.warning(message, title);
            $log.warn('Warning: ' + message, data);
        }
        

        ///////////////////// callback functions
        
        function  successCallback (response) {
            success("Request realizado com sucesso!", response.data, response.status + " - " + response.statusText);
            return response.data.results || response.data;
        }

        
         function   errorCallback (response) {
             if (response.status) {

                 var infolog = {                     
                     message: response.data.message || response.data.errors[0].errorMessage,
                     content: response.data,
                     title: response.status + " - " + response.statusText,
                     type: "error"
                 };

                 service[infolog.type](infolog.message, info.content, infolog.title);
                 
                } else
                    error(response.message,null,"Servidor Indisponível.");
                throw new Error(response);
            }
    }
}(window.angular));

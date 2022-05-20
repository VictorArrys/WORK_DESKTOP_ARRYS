'use strict';

var utils = require('../utils/writer.js');
var ContratacionesAspirante = require('../service/ContratacionesAspiranteService');

module.exports.getContratacionEmpleoAspirante = function getContratacionEmpleoAspirante (req, res, next, idPerfilAspirante, idContratacionEmpleoAspirante) {
  ContratacionesAspirante.getContratacionEmpleoAspirante(idPerfilAspirante, idContratacionEmpleoAspirante)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getContratacionesEmpleoAspirante = function getContratacionesEmpleoAspirante (req, res, next, idPerfilAspirante) {
  ContratacionesAspirante.getContratacionesEmpleoAspirante(idPerfilAspirante)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getContratacionesServicioAspirante = function getContratacionesServicioAspirante (req, res, next, idPerfilAspirante) {
  ContratacionesAspirante.getContratacionesServicioAspirante(idPerfilAspirante)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.registrarEvaluacionAspirante = function registrarEvaluacionAspirante (req, res, next, body, idPerfilDemandante, idContratacionServicio) {
  ContratacionesAspirante.registrarEvaluacionAspirante(body, idPerfilDemandante, idContratacionServicio)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.registrarEvaluacionEmpleador = function registrarEvaluacionEmpleador (req, res, next, body, idPerfilAspirante, idContratacionEmpleoAspirante) {
  ContratacionesAspirante.registrarEvaluacionEmpleador(body, idPerfilAspirante, idContratacionEmpleoAspirante)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

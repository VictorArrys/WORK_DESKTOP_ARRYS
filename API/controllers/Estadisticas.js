'use strict';

var utils = require('../utils/writer.js');
var Estadisticas = require('../service/EstadisticasService');

module.exports.getEstadisticasEmpleos = function getEstadisticasEmpleos (req, res, next) {
  Estadisticas.getEstadisticasEmpleos()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getEstadisticasOfertasEmpleo = function getEstadisticasOfertasEmpleo (req, res, next) {
  Estadisticas.getEstadisticasOfertasEmpleo()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getEstadisticasUsoPlataforma = function getEstadisticasUsoPlataforma (req, res, next) {
  Estadisticas.getEstadisticasUsoPlataforma()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getValoracionesAspirantes = function getValoracionesAspirantes (req, res, next) {
  Estadisticas.getValoracionesAspirantes()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getValoracionesEmpleadores = function getValoracionesEmpleadores (req, res, next) {
  Estadisticas.getValoracionesEmpleadores()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

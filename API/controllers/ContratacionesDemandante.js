'use strict';

var utils = require('../utils/writer.js');
var ContratacionesDemandante = require('../service/ContratacionesDemandanteService');

module.exports.finalizarContratacionServicio = function finalizarContratacionServicio (req, res, next, idPerfilDemandante, idContratacionServicio) {
  ContratacionesDemandante.finalizarContratacionServicio(idPerfilDemandante, idContratacionServicio)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getContratacionesServicioDemandante = function getContratacionesServicioDemandante (req, res, next, idPerfilDemandante) {
  ContratacionesDemandante.getContratacionesServicioDemandante(idPerfilDemandante)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

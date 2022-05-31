'use strict';

var utils = require('../utils/writer.js');
var ContratacionesEmpleador = require('../service/ContratacionesEmpleadorService');

module.exports.getContratacionEmpleo = function getContratacionEmpleo (req, res, next, idOfertaEmpleo) {
  ContratacionesEmpleador.getContratacionEmpleo(idOfertaEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.patchEvaluarAspirante = function patchEvaluarAspirante (req, res, next, body, idAspirante, idOfertaEmpleo) {
  ContratacionesEmpleador.patchEvaluarAspirante(body, idAspirante, idOfertaEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

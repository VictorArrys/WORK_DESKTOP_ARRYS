'use strict';

var utils = require('../utils/writer.js');
var SolicitudDeEmpleoAspirante = require('../service/SolicitudDeEmpleoAspiranteService');

module.exports.patchSolicitarVacante = function patchSolicitarVacante (req, res, next, body, idOfertaEmpleo) {
  SolicitudDeEmpleoAspirante.patchSolicitarVacante(body, idOfertaEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

'use strict';

var utils = require('../utils/writer.js');
var SolicitudDeEmpleoEmpleador = require('../service/SolicitudDeEmpleoEmpleadorService');

module.exports.getSolicitudEmpleo = function getSolicitudEmpleo (req, res, next, idSolicitudEmpleo) {
  SolicitudDeEmpleoEmpleador.getSolicitudEmpleo(idSolicitudEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getSolicitudesEmpleo = function getSolicitudesEmpleo (req, res, next, idOfertaEmpleo) {
  SolicitudDeEmpleoEmpleador.getSolicitudesEmpleo(idOfertaEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.patchSolicitudEmpleoAceptada = function patchSolicitudEmpleoAceptada (req, res, next, idSolicitudEmpleo) {
  SolicitudDeEmpleoEmpleador.patchSolicitudEmpleoAceptada(idSolicitudEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.patchSolicitudEmpleoRechazada = function patchSolicitudEmpleoRechazada (req, res, next, idSolicitudEmpleo) {
  SolicitudDeEmpleoEmpleador.patchSolicitudEmpleoRechazada(idSolicitudEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

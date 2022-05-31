'use strict';

var utils = require('../utils/writer.js');
var ReporteOfertaEmpleoAdminstrador = require('../service/ReporteOfertaEmpleoAdminstradorService');

module.exports.getReporteEmpleo = function getReporteEmpleo (req, res, next, idReporteEmpleo) {
  ReporteOfertaEmpleoAdminstrador.getReporteEmpleo(idReporteEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getReportesEmpleos = function getReportesEmpleos (req, res, next) {
  ReporteOfertaEmpleoAdminstrador.getReportesEmpleos()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.patchReporteEmpleoAceptado = function patchReporteEmpleoAceptado (req, res, next, idReporteEmpleo) {
  ReporteOfertaEmpleoAdminstrador.patchReporteEmpleoAceptado(idReporteEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.patchReporteEmpleoRechazado = function patchReporteEmpleoRechazado (req, res, next, idReporteEmpleo) {
  ReporteOfertaEmpleoAdminstrador.patchReporteEmpleoRechazado(idReporteEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

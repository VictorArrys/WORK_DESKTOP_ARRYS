'use strict';

var utils = require('../utils/writer.js');
var ReporteOfertaEmpleoAspirante = require('../service/ReporteOfertaEmpleoAspiranteService');

module.exports.postReportesEmpleos = function postReportesEmpleos (req, res, next, body) {
  ReporteOfertaEmpleoAspirante.postReportesEmpleos(body)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

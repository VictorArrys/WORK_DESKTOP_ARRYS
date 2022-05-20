'use strict';

var utils = require('../utils/writer.js');
var OfertaDeEmpleoAspirante = require('../service/OfertaDeEmpleoAspiranteService');

module.exports.getOfertaEmpleoAspirante = function getOfertaEmpleoAspirante (req, res, next, idOfertaEmpleo) {
  OfertaDeEmpleoAspirante.getOfertaEmpleoAspirante(idOfertaEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getOfertasEmpleoAsprante = function getOfertasEmpleoAsprante (req, res, next, categoriasEmpleo) {
  OfertaDeEmpleoAspirante.getOfertasEmpleoAsprante(categoriasEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

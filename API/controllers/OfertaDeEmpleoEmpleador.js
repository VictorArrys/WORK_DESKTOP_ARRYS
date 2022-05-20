'use strict';

var utils = require('../utils/writer.js');
var OfertaDeEmpleoEmpleador = require('../service/OfertaDeEmpleoEmpleadorService');

module.exports.getOfertaEmpleoEmpleador = function getOfertaEmpleoEmpleador (req, res, next, idOfertaEmpleo) {
  OfertaDeEmpleoEmpleador.getOfertaEmpleoEmpleador(idOfertaEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getOfertasEmpleoEmpleador = function getOfertasEmpleoEmpleador (req, res, next, idPerfilEmpleador) {
  OfertaDeEmpleoEmpleador.getOfertasEmpleoEmpleador(idPerfilEmpleador)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.postOfertaEmpleo = function postOfertaEmpleo (req, res, next, body) {
  OfertaDeEmpleoEmpleador.postOfertaEmpleo(body)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.putOfertaEmpleoEmpleador = function putOfertaEmpleoEmpleador (req, res, next, body, idOfertaEmpleo) {
  OfertaDeEmpleoEmpleador.putOfertaEmpleoEmpleador(body, idOfertaEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

'use strict';

var utils = require('../utils/writer.js');
var GestionDeCategorasDeEmpleo = require('../service/GestionDeCategorasDeEmpleoService');

module.exports.categoriasEmpleoIdCategoriaEmpleoDELETE = function categoriasEmpleoIdCategoriaEmpleoDELETE (req, res, next, idCategoriaEmpleo) {
  GestionDeCategorasDeEmpleo.categoriasEmpleoIdCategoriaEmpleoDELETE(req, idCategoriaEmpleo)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    });
};

module.exports.categoriasEmpleoIdCategoriaEmpleoPATCH = function categoriasEmpleoIdCategoriaEmpleoPATCH (req, res, next, body, idCategoriaEmpleo) {
  GestionDeCategorasDeEmpleo.categoriasEmpleoIdCategoriaEmpleoPATCH(body, idCategoriaEmpleo)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    });
};

module.exports.categoriasEmpleoPOST = function categoriasEmpleoPOST (req, res, next, body) {
  GestionDeCategorasDeEmpleo.categoriasEmpleoPOST(req)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    });
};

module.exports.getCategoriasEmpleo = function getCategoriasEmpleo (req, res, next) {
  GestionDeCategorasDeEmpleo.getCategoriasEmpleo(req)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    });
};

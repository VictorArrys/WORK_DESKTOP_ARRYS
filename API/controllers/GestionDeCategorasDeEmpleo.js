'use strict';

var utils = require('../utils/writer.js');
var GestionDeCategorasDeEmpleo = require('../service/GestionDeCategorasDeEmpleoService');

module.exports.categoriasEmpleoIdCategoriaEmpleoDELETE = function categoriasEmpleoIdCategoriaEmpleoDELETE (req, res, next, idCategoriaEmpleo) {
  GestionDeCategorasDeEmpleo.categoriasEmpleoIdCategoriaEmpleoDELETE(idCategoriaEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.categoriasEmpleoIdCategoriaEmpleoPATCH = function categoriasEmpleoIdCategoriaEmpleoPATCH (body, res, next, idCategoriaEmpleo) {
  GestionDeCategorasDeEmpleo.categoriasEmpleoIdCategoriaEmpleoPATCH(req, idCategoriaEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.categoriasEmpleoPOST = function categoriasEmpleoPOST (reqBody, res, next, body) {
  GestionDeCategorasDeEmpleo.categoriasEmpleoPOST(reqBody)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    });
};

module.exports.getCategoriasEmpleo = function getCategoriasEmpleo (req, res, next) {
  GestionDeCategorasDeEmpleo.getCategoriasEmpleo()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

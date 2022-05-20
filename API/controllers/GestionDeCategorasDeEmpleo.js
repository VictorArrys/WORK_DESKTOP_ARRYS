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

module.exports.categoriasEmpleoIdCategoriaEmpleoPATCH = function categoriasEmpleoIdCategoriaEmpleoPATCH (req, res, next, body, idCategoriaEmpleo) {
  GestionDeCategorasDeEmpleo.categoriasEmpleoIdCategoriaEmpleoPATCH(body, idCategoriaEmpleo)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.categoriasEmpleoPOST = function categoriasEmpleoPOST (req, res, next, body) {
  GestionDeCategorasDeEmpleo.categoriasEmpleoPOST(body)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
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

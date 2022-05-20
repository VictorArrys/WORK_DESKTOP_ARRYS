'use strict';

var utils = require('../utils/writer.js');
var AccesoAlSistema = require('../service/AccesoAlSistemaService');

module.exports.cerrarSesion = function cerrarSesion (req, res, next) {
  AccesoAlSistema.cerrarSesion()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.iniciarSesion = function iniciarSesion (req, res, next, nombreUsuario, clave) {
  AccesoAlSistema.iniciarSesion(nombreUsuario, clave)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.patchRestablecer = function patchRestablecer (req, res, next, correoElectronico) {
  AccesoAlSistema.patchRestablecer(correoElectronico)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

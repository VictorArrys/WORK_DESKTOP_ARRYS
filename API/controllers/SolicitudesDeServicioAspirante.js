'use strict';

var utils = require('../utils/writer.js');
var SolicitudesDeServicioAspirante = require('../service/SolicitudesDeServicioAspiranteService');

module.exports.aceptarSolicitudServicio = function aceptarSolicitudServicio (req, res, next, idPerfilAspirante, idSolicitudServicio) {
  SolicitudesDeServicioAspirante.aceptarSolicitudServicio(idPerfilAspirante, idSolicitudServicio)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getAspiranteSolicitudServicio = function getAspiranteSolicitudServicio (req, res, next, idPerfilAspirante, idSolicitudServicio) {
  SolicitudesDeServicioAspirante.getAspiranteSolicitudServicio(idPerfilAspirante, idSolicitudServicio)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getAspiranteSolicitudesServicio = function getAspiranteSolicitudesServicio (req, res, next, idPerfilAspirante, estatus) {
  SolicitudesDeServicioAspirante.getAspiranteSolicitudesServicio(idPerfilAspirante, estatus)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.rechazarSolicitudServicio = function rechazarSolicitudServicio (req, res, next, idPerfilAspirante, idSolicitudServicio) {
  SolicitudesDeServicioAspirante.rechazarSolicitudServicio(idPerfilAspirante, idSolicitudServicio)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

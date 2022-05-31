'use strict';

var utils = require('../utils/writer.js');
var SolicitudesDeServicioDemandante = require('../service/SolicitudesDeServicioDemandanteService');

module.exports.getDemandanteSolicitudesServicio = function getDemandanteSolicitudesServicio (req, res, next, idPerfilDemandante) {
  SolicitudesDeServicioDemandante.getDemandanteSolicitudesServicio(idPerfilDemandante)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.postDemandanteSolicitudesServicio = function postDemandanteSolicitudesServicio (req, res, next, body, idPerfilDemandante) {
  SolicitudesDeServicioDemandante.postDemandanteSolicitudesServicio(body, idPerfilDemandante)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

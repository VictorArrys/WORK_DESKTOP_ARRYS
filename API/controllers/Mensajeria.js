'use strict';

var utils = require('../utils/writer.js');
var Mensajeria = require('../service/MensajeriaService');

module.exports.getConversacionAspirante = function getConversacionAspirante (req, res, next, idPerfilAspirante, idConversacion) {
  Mensajeria.getConversacionAspirante(idPerfilAspirante, idConversacion)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getConversacionDemandate = function getConversacionDemandate (req, res, next, idPerfilDemandante, idConversacion) {
  Mensajeria.getConversacionDemandate(idPerfilDemandante, idConversacion)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getConversacionEmpleador = function getConversacionEmpleador (req, res, next, idPerfilEmpleador, idConversacion) {
  Mensajeria.getConversacionEmpleador(idPerfilEmpleador, idConversacion)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getConversacioneAspirante = function getConversacioneAspirante (req, res, next, idPerfilAspirante) {
  Mensajeria.getConversacioneAspirante(idPerfilAspirante)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getConversacionesDemandate = function getConversacionesDemandate (req, res, next, idPerfilDemandante) {
  Mensajeria.getConversacionesDemandate(idPerfilDemandante)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getConversacionesEmpleador = function getConversacionesEmpleador (req, res, next, idPerfilEmpleador) {
  Mensajeria.getConversacionesEmpleador(idPerfilEmpleador)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.postConversacionAspirante = function postConversacionAspirante (req, res, next, body, idPerfilAspirante, idConversacion) {
  Mensajeria.postConversacionAspirante(body, idPerfilAspirante, idConversacion)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.postMensajeConversacionEmpleador = function postMensajeConversacionEmpleador (req, res, next, body, idPerfilEmpleador, idConversacion) {
  Mensajeria.postMensajeConversacionEmpleador(body, idPerfilEmpleador, idConversacion)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.postMensajeConversacionesDemandate = function postMensajeConversacionesDemandate (req, res, next, body, idPerfilDemandante, idConversacion) {
  Mensajeria.postMensajeConversacionesDemandate(body, idPerfilDemandante, idConversacion)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

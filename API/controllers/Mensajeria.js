'use strict';

var utils = require('../utils/writer.js');
var Mensajeria = require('../service/MensajeriaService');

module.exports.getConversacionAspirante = function getConversacionAspirante (req, res, next, idPerfilAspirante, idConversacion) {

  Mensajeria.getConversacionAspirante(req, idPerfilAspirante, idConversacion)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    });
};

module.exports.getConversacionDemandate = function getConversacionDemandate (req, res, next, idPerfilDemandante, idConversacion) {

  Mensajeria.getConversacionDemandate(req, idPerfilDemandante, idConversacion)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);

    });
};

module.exports.getConversacionEmpleador = function getConversacionEmpleador (req, res, next, idPerfilEmpleador, idConversacion) {

  Mensajeria.getConversacionEmpleador(req, idPerfilEmpleador, idConversacion)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);

    });
};

module.exports.getConversacioneAspirante = function getConversacioneAspirante (req, res, next, idPerfilAspirante) {

  Mensajeria.getConversacioneAspirante(req, idPerfilAspirante)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);

    });
};

module.exports.getConversacionesDemandate = function getConversacionesDemandate (req, res, next, idPerfilDemandante) {

  Mensajeria.getConversacionesDemandate(req, idPerfilDemandante)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);

    });
};

module.exports.getConversacionesEmpleador = function getConversacionesEmpleador (req, res, next, idPerfilEmpleador) {

  Mensajeria.getConversacionesEmpleador(req, idPerfilEmpleador)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    });
};

module.exports.postConversacionAspirante = function postConversacionAspirante (req, res, next, idPerfilAspirante, idConversacion) {
  Mensajeria.postConversacionAspirante(req, idPerfilAspirante, idConversacion)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    });
};

module.exports.postMensajeConversacionEmpleador = function postMensajeConversacionEmpleador (req, res, next,  idPerfilEmpleador, idConversacion) {
  Mensajeria.postMensajeConversacionEmpleador(req, idPerfilEmpleador, idConversacion)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    });
};

module.exports.postMensajeConversacionesDemandate = function postMensajeConversacionesDemandate (req, res, next, idPerfilDemandante, idConversacion) {
  Mensajeria.postMensajeConversacionDemandate(req, idPerfilDemandante, idConversacion)
    .then(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);
    })
    .catch(function (response) {
      utils.writeJson(res, response['resBody'], response['statusCode']);

    });
};

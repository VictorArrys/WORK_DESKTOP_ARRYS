'use strict';


/**
 * Aceptar una solicitud de servicio y crear contratación de servicio
 * Cambia de estatus a una solicitud de servicio para crear una contratación de servicio internamente
 *
 * idPerfilAspirante Integer ID del aspirante que recibe la solicitud
 * idSolicitudServicio Integer ID de la solicitud de servicio que se esta consultando
 * no response value expected for this operation
 **/
exports.aceptarSolicitudServicio = function(idPerfilAspirante,idSolicitudServicio) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


/**
 * Consulta solicitud de empleo
 * Consulta la informacion de una solicitud de servicio realizada por un demandante
 *
 * idPerfilAspirante Integer ID del aspirante
 * idSolicitudServicio Integer ID de la solicitud de servicio que se esta consultando
 * returns SolicitudServicio
 **/
exports.getAspiranteSolicitudServicio = function(idPerfilAspirante,idSolicitudServicio) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "descripcion" : "Instalacion completa de plemeria para baño. Pago de 200 peso diarios. Ubicado en Fracc. Lomas de Santa Fé, Santa Lourdes #4, Xalapa.",
  "idSolicitudServicio" : 12,
  "estatus" : 1,
  "fechaRegistro" : { },
  "idPerfilDemandante" : 19,
  "titulo" : "Intalación plemaria para baño",
  "idPerfilAspirante" : 22
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consultar lista de solicitudes de servicios
 * solicita la lista de las solicitudes de servicios que ha realizado el demandante
 *
 * idPerfilAspirante Integer ID de Aspirante
 * estatus String  (optional)
 * returns inline_response_200
 **/
exports.getAspiranteSolicitudesServicio = function(idPerfilAspirante,estatus) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "resultado" : [ {
    "descripcion" : "Instalacion completa de plemeria para baño. Pago de 200 peso diarios. Ubicado en Fracc. Lomas de Santa Fé, Santa Lourdes #4, Xalapa.",
    "idSolicitudServicio" : 12,
    "estatus" : 1,
    "fechaRegistro" : { },
    "idPerfilDemandante" : 19,
    "titulo" : "Intalación plemaria para baño",
    "idPerfilAspirante" : 22
  }, {
    "descripcion" : "Instalacion completa de plemeria para baño. Pago de 200 peso diarios. Ubicado en Fracc. Lomas de Santa Fé, Santa Lourdes #4, Xalapa.",
    "idSolicitudServicio" : 12,
    "estatus" : 1,
    "fechaRegistro" : { },
    "idPerfilDemandante" : 19,
    "titulo" : "Intalación plemaria para baño",
    "idPerfilAspirante" : 22
  } ]
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Rechaza una solicitud de servicio
 * Cambia de estatus a una solicitud de servicio
 *
 * idPerfilAspirante Integer ID del aspirante que recibe la solicitud
 * idSolicitudServicio Integer ID de la solicitud de servicio que se esta consultando
 * no response value expected for this operation
 **/
exports.rechazarSolicitudServicio = function(idPerfilAspirante,idSolicitudServicio) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


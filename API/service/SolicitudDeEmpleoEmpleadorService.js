'use strict';


/**
 * Consulta solicitud de empleo
 * Consulta la informacion de una solicitud de empleo realizada por un aspirante
 *
 * idSolicitudEmpleo Integer ID de la solicitud de empleo que se esta consultando
 * returns List
 **/
exports.getSolicitudEmpleo = function(idSolicitudEmpleo) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "idSolicitudEmpleo" : 21,
  "estatus" : "Rechazada",
  "idAspirante" : "22",
  "fechaRegistro" : { }
}, {
  "idSolicitudEmpleo" : 21,
  "estatus" : "Rechazada",
  "idAspirante" : "22",
  "fechaRegistro" : { }
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consultar lista de solicitudes de empleo
 * solicita la lista de las solicitudes de empleo que ha recibido la **idOfertaEmpleo**
 *
 * idOfertaEmpleo Integer ID de la oferta de empleo que tendra las solcitudes
 * returns List
 **/
exports.getSolicitudesEmpleo = function(idOfertaEmpleo) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "idSolicitudEmpleo" : 21,
  "estatus" : "Rechazada",
  "idAspirante" : "22",
  "fechaRegistro" : { }
}, {
  "idSolicitudEmpleo" : 21,
  "estatus" : "Rechazada",
  "idAspirante" : "22",
  "fechaRegistro" : { }
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Aceptar una solicitud de empleo y agrega el aspirante aceptado a la contratación
 * Cambia de estatus a una solicitud para agregar el aspirante aceptado a la contratació internamente
 *
 * idSolicitudEmpleo Integer ID de la solicitud de empleo que se cambiara su estado a aceptado
 * no response value expected for this operation
 **/
exports.patchSolicitudEmpleoAceptada = function(idSolicitudEmpleo) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


/**
 * Rechazar una solicitud de empleo
 * Cambia de estatus a una solicitud
 *
 * idSolicitudEmpleo Integer ID de la solicitud de empleo que se cambiara su estado a rechazado
 * no response value expected for this operation
 **/
exports.patchSolicitudEmpleoRechazada = function(idSolicitudEmpleo) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


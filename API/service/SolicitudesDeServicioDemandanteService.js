'use strict';


/**
 * Consultar lista de solicitudes de servicios
 * solicita la lista de las solicitudes de servicios que ha realizado el demandante
 *
 * idPerfilDemandante Integer Tipo de usuario Demandante o Aspirante
 * returns inline_response_200
 **/
exports.getDemandanteSolicitudesServicio = function(idPerfilDemandante) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "resultado" : [ {
    "descripcion" : "Instalacion completa de plemeria para baño. Pago de 200 peso diarios. Ubicado en Fracc. Lomas de Santa Fé, Santa Lourdes #4, Xalapa.",
    "idSolicitudServicio" : 12,
    "estatus" : 1,
    "fechaRegistro" : "2022-05-04T00:00:00.000+00:00",
    "idPerfilDemandante" : 19,
    "titulo" : "Intalación plemaria para baño",
    "idPerfilAspirante" : 22
  }, {
    "descripcion" : "Instalacion completa de plemeria para baño. Pago de 200 peso diarios. Ubicado en Fracc. Lomas de Santa Fé, Santa Lourdes #4, Xalapa.",
    "idSolicitudServicio" : 12,
    "estatus" : 1,
    "fechaRegistro" : "2022-05-04T00:00:00.000+00:00",
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
 * Registrar solicitud de servicio en catalogo de solicitudes de servicios
 * Se agrega una nueva solicitud de servicio enviando la información de la solicitud de servicio
 *
 * body Object  (optional)
 * idPerfilDemandante Integer Tipo de usuario Demandante o Aspirante
 * returns SolicitudServicio
 **/
exports.postDemandanteSolicitudesServicio = function(body,idPerfilDemandante) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "descripcion" : "Instalacion completa de plemeria para baño. Pago de 200 peso diarios. Ubicado en Fracc. Lomas de Santa Fé, Santa Lourdes #4, Xalapa.",
  "idSolicitudServicio" : 12,
  "estatus" : 1,
  "fechaRegistro" : "2022-05-04T00:00:00.000+00:00",
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


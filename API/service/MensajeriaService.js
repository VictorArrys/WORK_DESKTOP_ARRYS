'use strict';


/**
 * Consultar conversación con empleador o demandante
 * Cosulta la informacion de la conversación del aspirante y la lista de mensajes
 *
 * idPerfilAspirante Integer 
 * idConversacion Integer 
 * returns ConversacionAspirante
 **/
exports.getConversacionAspirante = function(idPerfilAspirante,idConversacion) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "idConversacion" : 1,
  "mensajes" : [ {
    "idMensaje" : 1,
    "idUsuarioRemitente" : 1,
    "fechaRegistro" : "2022-05-04T00:00:00.000+00:00",
    "remitente" : "Pedro Sanchez Gómez",
    "contenidoMensaje" : "Este es un mensaje para el usuario",
    "tipoUsuario" : "Empleador"
  }, {
    "idMensaje" : 1,
    "idUsuarioRemitente" : 1,
    "fechaRegistro" : "2022-05-04T00:00:00.000+00:00",
    "remitente" : "Pedro Sanchez Gómez",
    "contenidoMensaje" : "Este es un mensaje para el usuario",
    "tipoUsuario" : "Empleador"
  } ],
  "tituloOfertaEmpleo" : "Construccion de edificio departamental"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consultar conversación con aspirante contratado
 * Consulta la informacion de la conversacion entre un demandante y un aspirante contratado, y la lista de mensajes
 *
 * idPerfilDemandante Integer ID del demandante que participa en una conversación
 * idConversacion Integer ID de la conversacion en donde participa el demandante
 * returns ConversacionDemandante
 **/
exports.getConversacionDemandate = function(idPerfilDemandante,idConversacion) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "tituloSolicitud" : "Reemplazo de tuberias de cobre",
  "idConversacion" : 1,
  "mensajes" : [ {
    "idMensaje" : 1,
    "idUsuarioRemitente" : 1,
    "fechaRegistro" : "2022-05-04T00:00:00.000+00:00",
    "remitente" : "Pedro Sanchez Gómez",
    "contenidoMensaje" : "Este es un mensaje para el usuario",
    "tipoUsuario" : "Empleador"
  }, {
    "idMensaje" : 1,
    "idUsuarioRemitente" : 1,
    "fechaRegistro" : "2022-05-04T00:00:00.000+00:00",
    "remitente" : "Pedro Sanchez Gómez",
    "contenidoMensaje" : "Este es un mensaje para el usuario",
    "tipoUsuario" : "Empleador"
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
 * Consultar los mensajes de la conversación entre el empleador y los aspirantes contratados de una oferta de empleo
 * Consulta datos de la conversacion de un empleador con los aspirantes que contrato en una oferta de empleo y la lista de mensajes
 *
 * idPerfilEmpleador Integer 
 * idConversacion Integer 
 * returns ConversacionEmpleador
 **/
exports.getConversacionEmpleador = function(idPerfilEmpleador,idConversacion) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "idConversacion" : 1,
  "mensajes" : [ {
    "idMensaje" : 1,
    "idUsuarioRemitente" : 1,
    "fechaRegistro" : "2022-05-04T00:00:00.000+00:00",
    "remitente" : "Pedro Sanchez Gómez",
    "contenidoMensaje" : "Este es un mensaje para el usuario",
    "tipoUsuario" : "Empleador"
  }, {
    "idMensaje" : 1,
    "idUsuarioRemitente" : 1,
    "fechaRegistro" : "2022-05-04T00:00:00.000+00:00",
    "remitente" : "Pedro Sanchez Gómez",
    "contenidoMensaje" : "Este es un mensaje para el usuario",
    "tipoUsuario" : "Empleador"
  } ],
  "tituloOfertaEmpleo" : "Construccion de edificio departamental"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 *
 * idPerfilAspirante Integer 
 * returns List
 **/
exports.getConversacioneAspirante = function(idPerfilAspirante) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "idConversacion" : 1,
  "categoriaEmpleo" : "Plomeria",
  "tituloOfertaEmpleo" : "Construccion de edificio departamental"
}, {
  "idConversacion" : 1,
  "categoriaEmpleo" : "Plomeria",
  "tituloOfertaEmpleo" : "Construccion de edificio departamental"
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consultar una lista de conversaciones del demandante con los aspirantes contratados
 * Consulta una lista de las conversaciones del del demandante con los aspirante que han aceptado su solicitud de servicio
 *
 * idPerfilDemandante Integer ID del demandante que participa en una conversación
 * returns List
 **/
exports.getConversacionesDemandate = function(idPerfilDemandante) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "tituloSolicitud" : "Reemplazo de tuberias de cobre",
  "fechaContratacion" : "2022-12-04T00:00:00.000+00:00",
  "idConversacion" : 1,
  "nombreAspirante" : "Raúl Gomez Perez"
}, {
  "tituloSolicitud" : "Reemplazo de tuberias de cobre",
  "fechaContratacion" : "2022-12-04T00:00:00.000+00:00",
  "idConversacion" : 1,
  "nombreAspirante" : "Raúl Gomez Perez"
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consultar conversaciones de las diferentes ofertas de empleo
 * Consulta lista de conversaciones de un empleador por cada oferta de empleo
 *
 * idPerfilEmpleador Integer 
 * returns List
 **/
exports.getConversacionesEmpleador = function(idPerfilEmpleador) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "idConversacion" : 1,
  "categoriaEmpleo" : "Plomeria",
  "tituloOfertaEmpleo" : "Construccion de edificio departamental"
}, {
  "idConversacion" : 1,
  "categoriaEmpleo" : "Plomeria",
  "tituloOfertaEmpleo" : "Construccion de edificio departamental"
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Registrar mensaje en conversación
 * Registra mensaje para empleador o demandante en la conversación
 *
 * body Conversaciones_idConversacion_body_2 Mensaje de Empleador
 * idPerfilAspirante Integer 
 * idConversacion Integer 
 * returns Mensaje
 **/
exports.postConversacionAspirante = function(body,idPerfilAspirante,idConversacion) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "idMensaje" : 1,
  "idUsuarioRemitente" : 1,
  "fechaRegistro" : "2022-05-04T00:00:00.000+00:00",
  "remitente" : "Pedro Sanchez Gómez",
  "contenidoMensaje" : "Este es un mensaje para el usuario",
  "tipoUsuario" : "Empleador"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Registrar mensaje para aspirante contratado
 * Registra un mensaje de aspirante un una conversacion
 *
 * body Conversaciones_idConversacion_body_1 Mensaje de Empleador
 * idPerfilEmpleador Integer 
 * idConversacion Integer 
 * returns Mensaje
 **/
exports.postMensajeConversacionEmpleador = function(body,idPerfilEmpleador,idConversacion) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "idMensaje" : 1,
  "idUsuarioRemitente" : 1,
  "fechaRegistro" : "2022-05-04T00:00:00.000+00:00",
  "remitente" : "Pedro Sanchez Gómez",
  "contenidoMensaje" : "Este es un mensaje para el usuario",
  "tipoUsuario" : "Empleador"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Registrar mensaje en conversacion con aspirante contratado
 * Registra el mensaje de un demandante en una conversacion con un aspirante
 *
 * body Conversaciones_idConversacion_body Mensaje registrado por el demnadante en una conversación
 * idPerfilDemandante Integer ID del demandante que participa en una conversación
 * idConversacion Integer ID de la conversacion en donde participa el demandante
 * returns Mensaje
 **/
exports.postMensajeConversacionesDemandate = function(body,idPerfilDemandante,idConversacion) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "idMensaje" : 1,
  "idUsuarioRemitente" : 1,
  "fechaRegistro" : "2022-05-04T00:00:00.000+00:00",
  "remitente" : "Pedro Sanchez Gómez",
  "contenidoMensaje" : "Este es un mensaje para el usuario",
  "tipoUsuario" : "Empleador"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


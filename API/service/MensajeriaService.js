'use strict';

const jwt = require('jsonwebtoken');
const mysqlConnection = require('../utils/conexion');
const keys = require('../settings/keys');


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
    "fechaRegistro" : { },
    "remitente" : "Pedro Sanchez Gómez",
    "contenidoMensaje" : "Este es un mensaje para el usuario",
    "tipoUsuario" : "Empleador"
  }, {
    "idMensaje" : 1,
    "idUsuarioRemitente" : 1,
    "fechaRegistro" : { },
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
    "fechaRegistro" : { },
    "remitente" : "Pedro Sanchez Gómez",
    "contenidoMensaje" : "Este es un mensaje para el usuario",
    "tipoUsuario" : "Empleador"
  }, {
    "idMensaje" : 1,
    "idUsuarioRemitente" : 1,
    "fechaRegistro" : { },
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
    "fechaRegistro" : { },
    "remitente" : "Pedro Sanchez Gómez",
    "contenidoMensaje" : "Este es un mensaje para el usuario",
    "tipoUsuario" : "Empleador"
  }, {
    "idMensaje" : 1,
    "idUsuarioRemitente" : 1,
    "fechaRegistro" : { },
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
  "fechaContratacion" : { },
  "idConversacion" : 1,
  "nombreAspirante" : "Raúl Gomez Perez"
}, {
  "tituloSolicitud" : "Reemplazo de tuberias de cobre",
  "fechaContratacion" : { },
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

    //Validación de token
    const token = body.headers['x-access-token'];
    try{
      const tokenData = jwt.verify(token, keys.key);

      //Validar que el token le pertenezca al aspirante que quiere registrar el mensaje
      if (tokenData['idTipoUsuario'] == idPerfilAspirante && tokenData['tipo'] == "Aspirante") {
        //Registrar mensaje en bd
        var queryInsert = "INSERT INTO mensaje (id_conversación_mensaje, id_usuario_remitente, mensaje, fechaRegistro) VALUES (?, ?, ?, NOW());"
        const mensaje = body.body["mensaje"];
        const idUsuario = tokenData['idUsuario'];
        mysqlConnection.query(queryInsert, [idConversacion, idUsuario, mensaje], function (error, results, fields){
          if(error){
            //Error al registrar
            reject({
              "resBody" : {
                "menssage" : "Error interno desde el servidor", 
              }, 
              "statusCode" : 500
            });
          } else {
            //registro exitoso
            var querySelect = "SELECT M.*, PA.nombre, PU.tipo_usuario FROM perfil_usuario AS PU JOIN mensaje AS M ON PU.id_perfil_usuario = M.id_usuario_remitente JOIN perfil_aspirante AS PA ON PU.id_perfil_usuario = PA.id_perfil_usuario_aspirante WHERE M.id_mensaje = ?;"
            const idMensaje = results.insertId;
            mysqlConnection.query(querySelect, [idMensaje], function (error, results, fields){
               if (error) {
                reject({
                  "resBody" : {
                    "menssage" : "Error interno desde el servidor", 
                  }, 
                  "statusCode" : 500
                });
               } else {
                var mensaje = results[0];
                var respuesta = {};
                respuesta['application/json'] = {
                  "resBody" : {
                    "idMensaje" : mensaje['id_mensaje'],
                    "idConversacion" : mensaje['id_conversación_mensaje'],
                    "idUsuarioRemitente" : mensaje['id_usuario_remitente'],
                    "fechaRegistro" : mensaje['fechaRegistro'],
                    "remitente" : mensaje['nombre'],
                    "contenidoMensaje" : mensaje['mensaje'],
                    "tipoUsuario" : mensaje['tipo_usuario']
                  }, 
                  "statusCode" : 201
                };
                resolve(respuesta['application/json'])
               }
            });
          }
        });
      } else {
        reject({
          "resBody" : {
            "menssage" : "Token invalido", 
          }, 
          "statusCode" : 401
        });
      }
    } catch (error) {
      reject({
        "resBody" : {
          "menssage" : "Token invalido", 
        }, 
        "statusCode" : 401
      });
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

    //Validación de token
    const token = body.headers['x-access-token'];
    try{
      const tokenData = jwt.verify(token, keys.key);

      //Validar que el token le pertenezca al eempleador que quiere registrar el mensaje
      if (tokenData['idTipoUsuario'] == idPerfilEmpleador && tokenData['tipo'] == "Empleador") {
        //Registrar mensaje en bd
        var queryInsert = "INSERT INTO mensaje (id_conversación_mensaje, id_usuario_remitente, mensaje, fechaRegistro) VALUES (?, ?, ?, NOW());"
        const mensaje = body.body["mensaje"];
        const idUsuario = tokenData['idUsuario'];
        mysqlConnection.query(queryInsert, [idConversacion, idUsuario, mensaje], function (error, results, fields){
          if(error){
            //Error al registrar
            reject({
              "resBody" : {
                "menssage" : "Error interno desde el servidor", 
              }, 
              "statusCode" : 500
            });
          } else {
            //registro exitoso
            var querySelect = "SELECT M.*, PE.nombre, PU.tipo_usuario FROM perfil_usuario AS PU JOIN mensaje AS M ON PU.id_perfil_usuario = M.id_usuario_remitente JOIN perfil_empleador AS PE ON PU.id_perfil_usuario = PE.id_perfil_usuario_empleador WHERE M.id_mensaje = ?;"
            const idMensaje = results.insertId;
            mysqlConnection.query(querySelect, [idMensaje], function (error, results, fields){
               if (error) {
                reject({
                  "resBody" : {
                    "menssage" : "Error interno desde el servidor", 
                  }, 
                  "statusCode" : 500
                });
               } else {
                var mensaje = results[0];
                var respuesta = {};
                respuesta['application/json'] = {
                  "resBody" : {
                    "idMensaje" : mensaje['id_mensaje'],
                    "idConversacion" : mensaje['id_conversación_mensaje'],
                    "idUsuarioRemitente" : mensaje['id_usuario_remitente'],
                    "fechaRegistro" : mensaje['fechaRegistro'],
                    "remitente" : mensaje['nombre'],
                    "contenidoMensaje" : mensaje['mensaje'],
                    "tipoUsuario" : mensaje['tipo_usuario']
                  }, 
                  "statusCode" : 201
                };
                resolve(respuesta['application/json'])
               }
            });
          }
        });
      } else {
        reject({
          "resBody" : {
            "menssage" : "Token invalido", 
          }, 
          "statusCode" : 401
        });
      }
    } catch (error) {
      reject({
        "resBody" : {
          "menssage" : "Token invalido", 
        }, 
        "statusCode" : 401
      });

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
exports.postMensajeConversacionDemandate = function(body,idPerfilDemandante,idConversacion) {
  return new Promise(function(resolve, reject) {
    

    //Validación de token
    const token = body.headers['x-access-token'];
    try{
      const tokenData = jwt.verify(token, keys.key);

      //Validar que el token le pertenezca al demandante que quiere registrar el mensaje
      if (tokenData['idTipoUsuario'] == idPerfilDemandante && tokenData['tipo'] == "Demandante") {
        //Registrar mensaje en bd
        var queryInsert = "INSERT INTO mensaje (id_conversación_mensaje, id_usuario_remitente, mensaje, fechaRegistro) VALUES (?, ?, ?, NOW());"
        const mensaje = body.body["mensaje"];
        const idUsuario = tokenData['idUsuario'];
        mysqlConnection.query(queryInsert, [idConversacion, idUsuario, mensaje], function (error, results, fields){
          if(error){
            //Error al registrar
            reject({
              "resBody" : {
                "menssage" : "Error interno desde el servidor", 
              }, 
              "statusCode" : 500
            });
          } else {
            //registro exitoso
            var querySelect = "SELECT M.*, PD.nombre FROM perfil_usuario AS PU JOIN mensaje AS M ON PU.id_perfil_usuario = M.id_usuario_remitente JOIN perfil_demandante AS PD ON PU.id_perfil_usuario = PD.id_perfil_usuario_demandante WHERE M.id_mensaje = ?"
            const idMensaje = results.insertId;
            mysqlConnection.query(querySelect, [idMensaje], function (error, results, fields){
               if (error) {
                reject({
                  "resBody" : {
                    "menssage" : "Error interno desde el servidor", 
                  }, 
                  "statusCode" : 500
                });
               } else {
                var mensaje = results[0];
                var respuesta = {};
                respuesta['application/json'] = {
                  "resBody" : {
                    "idMensaje" : mensaje['id_mensaje'],
                    "idConversacion" : mensaje['id_conversación_mensaje'],
                    "idUsuarioRemitente" : mensaje['id_usuario_remitente'],
                    "fechaRegistro" : mensaje['fechaRegistro'],
                    "remitente" : mensaje['nombre'],
                    "contenidoMensaje" : mensaje['mensaje'],
                    "tipoUsuario" : mensaje['tipo_usuario']
                  }, 
                  "statusCode" : 201
                };
                resolve(respuesta['application/json'])
               }
            });
          }
        });
      } else {
        reject({
          "resBody" : {
            "menssage" : "Token invalido", 
          }, 
          "statusCode" : 401
        });
      }
    } catch (error) {
      reject({
        "resBody" : {
          "menssage" : "Token invalido", 
        }, 
        "statusCode" : 401
      });
    }
  });
}


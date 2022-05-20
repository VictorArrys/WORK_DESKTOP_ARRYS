'use strict';
const jsonwebtoken = require('jsonwebtoken');
const jwt = require('jsonwebtoken');
var conexionMysql = require('../utils/conexion');
const keys = require('../settings/keys');


/**
 * Cierra sesión del usuario y desecha el token
 * Cierra la sesion del usuario y desecha el token
 *
 * no response value expected for this operation
 **/
exports.cerrarSesion = function() {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


/**
 * Iniciar sesíón y obtener token
 * Comprueba que el usuario se encuentre registrado en el sistema y le retorna el perfil de usuario con el token que le permite usar el API
 *
 * nombreUsuario String 
 * clave String 
 * returns PerfilUsuarios
 **/
exports.iniciarSesion = function(nombreUsuario,clave) {
  var conn = conexionMysql.conn;
  var user = null; 
  
  conn.connect(
    function(err) {
      if (err) {
          console.error('Error de conexion: ' + err.stack);
          return;
      }
      console.log('Conectado con el identificador ' + conn.threadId);
    }
  );

  var query = 'SELECT * FROM perfil_usuario WHERE nombre_usuario = ? AND clave = ?;'

  conn.query(query,[nombreUsuario, clave], function (error, results, fields) {
    if (error)
        throw error;

    if(results.length == 1){
      var usuario = results[0];
      if(usuario != null){
        const payload = {
          nombreUsuario:usuario['nombre_usuario'],
          clave:usuario['clave'],
          tipo:usuario['tipo_usuario']
        };
    
        const token = jsonwebtoken.sign(payload, keys.key); //pendiente
        //console.log(usuario);
      }
    }

    
  });


  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
      "clave" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
      "tipo" : 3,
      "estatus" : 1,
      "idPerfilUsuario" : 1,
      "nombreUsuario" : "skylake",
      "correoElectronico" : "elcamello@outlook.com",
      "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
      "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
    };
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
      console.log(examples);
    } else {
      resolve();
    }
  });
}


/**
 * Restablecer contraseña de usuario y enviar correo para notificar la nueva contraseña del usuario
 * El usuario introduce su correo eletronico, una vez verificado que esta registrado en el sistema se le mandara un correo con una constraseña nueva para poder acceder al sistema 
 *
 * correoElectronico String correo electronico que proporciona el usuario al momento de registrarse ene le sistema
 * no response value expected for this operation
 **/
exports.patchRestablecer = function(correoElectronico) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


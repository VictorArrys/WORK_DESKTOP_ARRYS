'use strict';
const jwt = require('jsonwebtoken');
var mysqlConnection = require('../utils/conexion');
const keys = require('../settings/keys');
const { response } = require('express');

/**
 * Cierra sesión del usuario y desecha el token
 * Cierra la sesion del usuario y desecha el token
 *
 * no response value expected for this operation
 **/
exports.cerrarSesion = function() {
  return new Promise(function(resolve, reject) {
    const token = req.headers['x-access-token'];
    try{
      const tokenData = jwt.verify(token, keys.key); 
      console.log(tokenData);
    } catch (error) {
      reject({
        "resBody" : {
          "menssage" : "Token invalido", 
        }, 
        "statusCode" : 401
      });
    }
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
  return new Promise(function(resolve, reject) {
    var query = 'SELECT * FROM perfil_usuario WHERE nombre_usuario = ? AND clave = ?;'
    console.log('Conectado con el identificador ' + mysqlConnection.threadId);
    
    mysqlConnection.query(query, [nombreUsuario, clave], function (error, results, fields){
      if(error){
          reject({
            "resBody" : {
              "menssage" : "error interno desde el servidor", 
            }, 
            "statusCode" : 500
          });
      }else if(results.length == 1){
        var usuario = results[0];
        if(usuario != null){
          //Estatus = 3 - Cuenta bloqueda
          if (usuario['estatus'] == 3) {
            reject({
              "resBody" : {
                "menssage" : "Cuenta bloqueada", 
              }, 
              "statusCode" : 403
            });
          }
          const payload = {
            "idUsuario" : usuario['id_perfil_usuario'],
            "clave" : usuario['clave'],
            "tipo" : usuario['tipo_usuario']
          }
  
          const token = jwt.sign(payload, keys.key, {
            expiresIn: 60 * 60 * 24
          });


          const resultadoRes = {};
          resultadoRes['application/json'] = {
            "resBody" : {
              "clave" : usuario['clave'],
              "tipo" : usuario['tipo_usuario'],
              "estatus" : usuario['estatus'],
              "idPerfilusuario" : usuario['id_perfil_usuario'],
              "correoElectronico" : usuario['correo_electronico'],
              "fotografia" : usuario['fotografia'],
              "tipoUsuario" : usuario['tipo_usuario'],
              "token" : token
            },
            "statusCode" : 200
          };
  
          resolve(resultadoRes['application/json']);
          
        }
      }else{
        reject({
          "resBody" : {
            "menssage" : "Crendeciales invalidas.", 
          }, 
          "statusCode" : 404
        });
      }
    })
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


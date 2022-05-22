'use strict';
const jwt = require('jsonwebtoken');
var mysqlConnection = require('../utils/conexion');
const keys = require('../settings/keys');

/**
 * Eliminar categoría de empleo
 * Elimina una categoria de empleo del catalogo de categorias de empleo
 *
 * idCategoriaEmpleo Integer ID de la categoria empleo que se modificará
 * no response value expected for this operation
 **/
exports.categoriasEmpleoIdCategoriaEmpleoDELETE = function(idCategoriaEmpleo) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


/**
 * Modificar categoria de empleo en catálogo de categorias
 * Actualiza el nombre de la categoria de empploe
 *
 * body CategoriasEmpleo_idCategoriaEmpleo_body Información de la categoría
 * idCategoriaEmpleo Integer ID de la categoria empleo que se modificará
 * no response value expected for this operation
 **/
exports.categoriasEmpleoIdCategoriaEmpleoPATCH = function(body, idCategoriaEmpleo) {
  return new Promise(function(resolve, reject) {
    console.log(req.headers['x-access-token']);
    console.log(idCategoriaEmpleo);
    resolve();
  });
}


/**
 * Registrar categoria de empleo en catalogo de categorias
 * Se publica una nueva categoria de empleo enviando el nombre de la categoria de empleo a registrar
 *
 * reqBody CategoriasEmpleo_body Información de la categoría
 * returns CategoriaEmpleo
 **/
exports.categoriasEmpleoPOST = function(reqBody) {
  return new Promise(function(resolve, reject) {
    const token = reqBody.headers['x-access-token'];
    console.log(reqBody.body)
    try{
      const tokenData = jwt.verify(token, keys.key);
      if (tokenData["tipo"] == "Administrador") {
        const nombreCategoria = "Albañilería";reqBody.body.nombre;
        if (nombreCategoria == null || nombreCategoria.length == 0) {
          reject({
            "resBody" : {
              "menssage" : "Error de sintaxis", 
            }, 
            "statusCode" : 400
          });
        }
        var query = 'INSERT INTO categoria_empleo(nombre) VALUES (?);'
        mysqlConnection.query(query, [nombreCategoria], function (error, results, fields){

          if (error){
            reject({
              "resBody" : {
                "menssage" : "error interno desde el servidor", 
              }, 
              "statusCode" : 500
            });
          } else {
            const categoriaCreada = {};
            categoriaCreada['application/json'] = {
              "resBody" : {
                "idCategoriaEmpleo" : results.insertId,
                "nombreCategoria" : nombreCategoria
              }, 
              "statusCode" : 201
            }
            resolve(categoriaCreada['application/json']);
          }

        });
      } else {
        reject({
          "resBody" : {
            "menssage" : "No tienes permisos de administrador", 
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
 * Consultar lista de categorias de empleo
 * solicita la lista de todas las categorias de empleo registrada para su posterior consulta
 *
 * returns List
 **/
exports.getCategoriasEmpleo = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
    "idCategoriaEmpleo" : 1,
    "nombreCategoria" : "Plomería"
  }, {
    "idCategoriaEmpleo" : 1,
    "nombreCategoria" : "Plomería"
  } ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


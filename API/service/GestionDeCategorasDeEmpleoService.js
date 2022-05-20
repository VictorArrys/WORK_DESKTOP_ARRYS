'use strict';


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
exports.categoriasEmpleoIdCategoriaEmpleoPATCH = function(body,idCategoriaEmpleo) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


/**
 * Registrar categoria de empleo en catalogo de categorias
 * Se publica una nueva categoria de empleo enviando el nombre de la categoria de empleo a registrar
 *
 * body CategoriasEmpleo_body Información de la categoría
 * returns CategoriaEmpleo
 **/
exports.categoriasEmpleoPOST = function(body) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "idCategoriaEmpleo" : 1,
  "nombreCategoria" : "Plomería"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
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


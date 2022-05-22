'use strict';


/**
 * Consulta de estadisticas de los empleos
 * Consultar información estadistica de los empleos, tanto ofertas como solicitudes
 *
 * returns List
 **/
exports.getEstadisticasEmpleos = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "fechaAnio" : { },
  "categoria" : "Panadería",
  "solicitudes" : 390
}, {
  "fechaAnio" : { },
  "categoria" : "Panadería",
  "solicitudes" : 390
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consultar información estadistica de las ofertas de empleo
 * Consultar información estadistica de las ofertas de empleo creadas agrupadas por año
 *
 * returns List
 **/
exports.getEstadisticasOfertasEmpleo = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "fechaAnio" : { },
  "ofertas" : 1431
}, {
  "fechaAnio" : { },
  "ofertas" : 1431
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consulta de estadisticas del uso de la plataforma
 * Consultar información estadistica de los usuarios para ver el uso de la plataforma
 *
 * returns List
 **/
exports.getEstadisticasUsoPlataforma = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "fechaAnio" : { },
  "ofertas" : 891,
  "usuarios" : 349
}, {
  "fechaAnio" : { },
  "ofertas" : 891,
  "usuarios" : 349
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consulta de valoraciones de los aspirantes
 * Consultar la información de valoración de los aspirantes
 *
 * returns List
 **/
exports.getValoracionesAspirantes = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "aspirante" : "Nathan Hernandez",
  "valoracionAspirante" : 7
}, {
  "aspirante" : "Nathan Hernandez",
  "valoracionAspirante" : 7
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consulta la valoración de los empleadores
 * Consultar la información de valoración de los empleadores
 *
 * returns List
 **/
exports.getValoracionesEmpleadores = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "empleador" : "Josias García Arevalo",
  "valoracionEmpleador" : 7
}, {
  "empleador" : "Josias García Arevalo",
  "valoracionEmpleador" : 7
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


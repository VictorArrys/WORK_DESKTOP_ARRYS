'use strict';


/**
 * Consulta reporte de empleo
 * Consulta la informacion de un reporte de empleo realizado por un aspirante
 *
 * idReporteEmpleo Integer ID del reporte de empleo que se esta consultando
 * returns List
 **/
exports.getReporteEmpleo = function(idReporteEmpleo) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "motivo" : "No cumple con la paga establecida y no proporciona un correcto liderazgo ni muestra organización",
  "idReporteEmpleo" : 16,
  "estatus" : "Pendiente",
  "fechaRegistro" : { }
}, {
  "motivo" : "No cumple con la paga establecida y no proporciona un correcto liderazgo ni muestra organización",
  "idReporteEmpleo" : 16,
  "estatus" : "Pendiente",
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
 * Consultar lista de reportes de ofertas de empleo
 * Solicita la lista de todos los reportes de ofertas de empleo realizado por aspirantes a un empleo en especifico
 *
 * returns List
 **/
exports.getReportesEmpleos = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "motivo" : "No cumple con la paga establecida y no proporciona un correcto liderazgo ni muestra organización",
  "idReporteEmpleo" : 16,
  "estatus" : "Pendiente",
  "fechaRegistro" : { }
}, {
  "motivo" : "No cumple con la paga establecida y no proporciona un correcto liderazgo ni muestra organización",
  "idReporteEmpleo" : 16,
  "estatus" : "Pendiente",
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
 * Aceptar reporte de oferta de empleo y Actualizar amonestaciones de perfil empleador
 * Cambia de estatus a un reporte de oferta de empleo para actualizar integerernamente el reporte y anotar una amonestacion al Empleador
 *
 * idReporteEmpleo Integer ID del reporte de empleo que se cambiara su estado a aceptado
 * no response value expected for this operation
 **/
exports.patchReporteEmpleoAceptado = function(idReporteEmpleo) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


/**
 * Descartar reporte de oferta de empleo
 * Cambia de estatus a un reporte de oferta de empleo para actualizar integerernamente el reporte y descartar una amonestacion al Empleador
 *
 * idReporteEmpleo Integer ID del reporte de empleo que se cambiara su estado a rechazado
 * no response value expected for this operation
 **/
exports.patchReporteEmpleoRechazado = function(idReporteEmpleo) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


'use strict';


/**
 * Consultar registro de contrataciones
 * Consultar registro de contrataciones de empleo
 *
 * idPerfilAspirante Integer Id del aspirante
 * idContratacionEmpleoAspirante Integer Id de contratacion del aspirante
 * returns DetallesContratacionEmpleo
 **/
exports.getContratacionEmpleoAspirante = function(idPerfilAspirante,idContratacionEmpleoAspirante) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "estatus" : 1,
  "idContratacionEmpleo" : 3,
  "fechaContratacion" : "2022-02-04T00:00:00.000+00:00",
  "ofertaEmpleo" : {
    "descripcion" : "Realización de mesas, sillas, además de otros muebles de cocina, teniendo en cuenta que se hará lijado y pintado de los mismos muebles",
    "diasLaborales" : "[2,3,4,5]",
    "fechaDeIinicio" : "2018-02-04T00:00:00.000+00:00",
    "direccion" : "Privada Adolfo López Mateos #12, Rafael Lucio, Ver.",
    "nombre" : "Carpintería don nacho",
    "horaInicio" : "10:00",
    "fotografia" : [ {
      "imagen" : ""
    }, {
      "imagen" : ""
    } ],
    "contratados" : [ {
      "idAspirante" : 234,
      "experiencia" : 4,
      "valoracionAspirante" : 9,
      "descripcionValoracionAspirante" : "Trabaja en tiempo y forma",
      "nombreAspirante" : "Monica G. C.",
      "oficio" : "Panadero"
    }, {
      "idAspirante" : 234,
      "experiencia" : 4,
      "valoracionAspirante" : 9,
      "descripcionValoracionAspirante" : "Trabaja en tiempo y forma",
      "nombreAspirante" : "Monica G. C.",
      "oficio" : "Panadero"
    } ],
    "horaFin" : "18:30",
    "idOfertaEmpleo" : 19,
    "tipoOfertaEmpleo" : "Tiempo completo",
    "cantidadPago" : 200,
    "tipoPago" : "Por día",
    "vacantes" : 5,
    "fechaDeFinalizacion" : "2018-05-12T00:00:00.000+00:00"
  }
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consultar registro de contrataciones
 * Consultar registro de contrataciones de empleo
 *
 * idPerfilAspirante Integer 
 * returns List
 **/
exports.getContratacionesEmpleoAspirante = function(idPerfilAspirante) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "nombreEmpleo" : "Reemplazo de instalacion electrica",
  "estatus" : 0,
  "idContratacionEmpleo" : 3,
  "fechaContratacion" : "2022-02-04T00:00:00.000+00:00",
  "idOfertaEmpleo" : 3,
  "nombreEmpleador" : "PedroSanchez Gomez",
  "fechaFinalizacion" : "2022-05-04T00:00:00.000+00:00"
}, {
  "nombreEmpleo" : "Reemplazo de instalacion electrica",
  "estatus" : 0,
  "idContratacionEmpleo" : 3,
  "fechaContratacion" : "2022-02-04T00:00:00.000+00:00",
  "idOfertaEmpleo" : 3,
  "nombreEmpleador" : "PedroSanchez Gomez",
  "fechaFinalizacion" : "2022-05-04T00:00:00.000+00:00"
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consultar contrataciones de servicio del demandnte
 * Consultar contrataciones del demandante
 *
 * idPerfilAspirante Integer 
 * returns List
 **/
exports.getContratacionesServicioAspirante = function(idPerfilAspirante) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "estatus" : 34,
  "fechaContratacion" : "2022-02-04T00:00:00.000+00:00",
  "valoracionDemandante" : 34,
  "idPerfilAspirante" : 34,
  "idPErfilDemandante" : 3,
  "idContratacionServicio" : 3,
  "fechaFinalizacion" : "2022-02-04T00:00:00.000+00:00"
}, {
  "estatus" : 34,
  "fechaContratacion" : "2022-02-04T00:00:00.000+00:00",
  "valoracionDemandante" : 34,
  "idPerfilAspirante" : 34,
  "idPErfilDemandante" : 3,
  "idContratacionServicio" : 3,
  "fechaFinalizacion" : "2022-02-04T00:00:00.000+00:00"
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Registrar reporte de oferta de empleo
 *
 * body Object  (optional)
 * idPerfilDemandante Integer Id del aspirante
 * idContratacionServicio Integer Id de contratacion del aspirante
 * no response value expected for this operation
 **/
exports.registrarEvaluacionAspirante = function(body,idPerfilDemandante,idContratacionServicio) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


/**
 * Registrar reporte de oferta de empleo
 *
 * body Object  (optional)
 * idPerfilAspirante Integer Id del aspirante
 * idContratacionEmpleoAspirante Integer Id de contratacion del aspirante
 * no response value expected for this operation
 **/
exports.registrarEvaluacionEmpleador = function(body,idPerfilAspirante,idContratacionEmpleoAspirante) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


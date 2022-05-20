'use strict';


/**
 * Finalizar contratacion de aspirante
 *
 * idPerfilDemandante Integer 
 * idContratacionServicio Integer 
 * no response value expected for this operation
 **/
exports.finalizarContratacionServicio = function(idPerfilDemandante,idContratacionServicio) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


/**
 * Consultar contrataciones de servicio del demandnte
 * Consultar contrataciones del demandante
 *
 * idPerfilDemandante Integer 
 * returns List
 **/
exports.getContratacionesServicioDemandante = function(idPerfilDemandante) {
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


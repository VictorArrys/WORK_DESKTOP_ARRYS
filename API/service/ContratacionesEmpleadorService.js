'use strict';


/**
 * Consultar una contratación de empleo
 * solicita la  contratacion de empleo seleccionada
 *
 * idOfertaEmpleo Integer ID de la oferta de empleo de la contratación que consultara las contrataciones de empleo a las que pertenece
 * returns List
 **/
exports.getContratacionEmpleo = function(idOfertaEmpleo) {
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
 * Evaluar aspirante de una contratación
 * Se añade una evaluación a un aspirante que pertenece a una evaluación
 *
 * body ContratacionEmpleoAspirante Detalles de la contratación entre el aspirante y la contratación
 * idAspirante Integer ID del aspirante que se evaluara en una contratación
 * idOfertaEmpleo Integer ID de la oferta de empleo de la cual se hará una evaluación de un aspirante en una contratación
 * no response value expected for this operation
 **/
exports.patchEvaluarAspirante = function(body,idAspirante,idOfertaEmpleo) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


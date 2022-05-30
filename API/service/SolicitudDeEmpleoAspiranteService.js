'use strict';


/**
 *
 * body Object  (optional)
 * idOfertaEmpleo Integer ID de la oferta de empleo que se consultara
 * returns SolicitudVacante
 **/
exports.patchSolicitarVacante = function(body,idOfertaEmpleo) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "idSolicitudVacante" : 14,
  "estatus" : 1,
  "fechaRegistro" : { },
  "idOfertaEmpleo" : 12,
  "idPerfilAspirante" : 9
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


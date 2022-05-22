'use strict';


/**
 * Consultar una oferta de empleo
 * Solicita una oferta de empleo en especifico
 *
 * idOfertaEmpleo Integer ID de la oferta de empleo que se consultara
 * returns List
 **/
exports.getOfertaEmpleoEmpleador = function(idOfertaEmpleo) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "descripcion" : "Realización de mesas, sillas, además de otros muebles de cocina, teniendo en cuenta que se hará lijado y pintado de los mismos muebles",
  "diasLaborales" : "[2,3,4,5]",
  "fechaDeIinicio" : { },
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
  "fechaDeFinalizacion" : { }
}, {
  "descripcion" : "Realización de mesas, sillas, además de otros muebles de cocina, teniendo en cuenta que se hará lijado y pintado de los mismos muebles",
  "diasLaborales" : "[2,3,4,5]",
  "fechaDeIinicio" : { },
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
  "fechaDeFinalizacion" : { }
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consultar lista de ofertas de empleo de un empleador
 * solicita la lista de todas las ofertas de empleo registrada para su posterior consulta
 *
 * idPerfilEmpleador Integer ID del perfil empleador que consultara sus ofertas de empleo
 * returns List
 **/
exports.getOfertasEmpleoEmpleador = function(idPerfilEmpleador) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "descripcion" : "Realización de mesas, sillas, además de otros muebles de cocina, teniendo en cuenta que se hará lijado y pintado de los mismos muebles",
  "diasLaborales" : "[2,3,4,5]",
  "fechaDeIinicio" : { },
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
  "fechaDeFinalizacion" : { }
}, {
  "descripcion" : "Realización de mesas, sillas, además de otros muebles de cocina, teniendo en cuenta que se hará lijado y pintado de los mismos muebles",
  "diasLaborales" : "[2,3,4,5]",
  "fechaDeIinicio" : { },
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
  "fechaDeFinalizacion" : { }
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Registrar oferta de empleo en catalogo de ofertas empleo e internamente se crea una contratación de empleo en el catalogo contrataciones de empleo
 * Se agrega una nueva oferta de empleo enviando la información de la oferta e internamente se crea una contratación de empleo en el catalogo contrataciones de empleo
 *
 * body OfertaEmpleo Oferta de empleo
 * no response value expected for this operation
 **/
exports.postOfertaEmpleo = function(body) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


/**
 * Modificar oferta de empleo en catálogo de ofertas de empleo
 * Actualiza la información de la oferta de empleo
 *
 * body OfertaEmpleo Oferta de empleo
 * idOfertaEmpleo Integer 
 * no response value expected for this operation
 **/
exports.putOfertaEmpleoEmpleador = function(body,idOfertaEmpleo) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


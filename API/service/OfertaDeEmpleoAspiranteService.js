'use strict';


/**
 * Consultar una oferta de empleo
 * Solicita una oferta de empleo en especifico
 *
 * idOfertaEmpleo Integer ID de la oferta de empleo que se consultara
 * returns OfertaEmpleo
 **/
exports.getOfertaEmpleoAspirante = function(idOfertaEmpleo) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
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
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Buscar ofertas de empleo de empleadores con perfil habilitado
 * Buscar ofertas de empleo de empleadores con perfil habilitado y con vacantes disponibles
 *
 * categoriasEmpleo List Categorias a las que pertenece el aspirante
 * returns List
 **/
exports.getOfertasEmpleoAsprante = function(categoriasEmpleo) {
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


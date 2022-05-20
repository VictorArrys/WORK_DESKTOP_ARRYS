'use strict';


/**
 * consultar catalogo de perfiles administradores
 * Consulta del catalogo de todos los administradores registrados en el sistema 
 *
 * returns List
 **/
exports.getPerfilAdministradores = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "idPerfilAdministrador" : 2,
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "telefono" : "5561151502",
  "nombre" : "Jose gonzales"
}, {
  "idPerfilAdministrador" : 2,
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "telefono" : "5561151502",
  "nombre" : "Jose gonzales"
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * consulta el perfil de un administrador en especifico
 * consulta el perfil de un administrador en especifico buscandolo por su id 
 *
 * idPerfilAdministrador Integer identificador unico del administrador
 * returns PerfilAdministradores
 **/
exports.getPerfilAdministradoresIdPerfilAdministrador = function(idPerfilAdministrador) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "idPerfilAdministrador" : 2,
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "telefono" : "5561151502",
  "nombre" : "Jose gonzales"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consultar la lista  de los perfiles demandantes
 * Se consulta la lista de aspirantes a una oferta de empleo o servicio 
 *
 * returns List
 **/
exports.getPerfilAspirantes = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "oficios" : [ {
    "idExperienciaLaboral" : 1,
    "cantidadAnios" : 25,
    "idCategoria" : 1,
    "nombre" : "albañilería"
  }, {
    "idExperienciaLaboral" : 1,
    "cantidadAnios" : 25,
    "idCategoria" : 1,
    "nombre" : "albañilería"
  } ],
  "fechaNacimiento" : "1980-05-24T00:00:00.000+00:00",
  "direccion" : "Xalapeños ilustres #40",
  "idPerfilAspirante" : 1,
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "video" : "",
  "curriculum" : "",
  "telefono" : "2285095502",
  "nombre" : "Joaquin perez"
}, {
  "oficios" : [ {
    "idExperienciaLaboral" : 1,
    "cantidadAnios" : 25,
    "idCategoria" : 1,
    "nombre" : "albañilería"
  }, {
    "idExperienciaLaboral" : 1,
    "cantidadAnios" : 25,
    "idCategoria" : 1,
    "nombre" : "albañilería"
  } ],
  "fechaNacimiento" : "1980-05-24T00:00:00.000+00:00",
  "direccion" : "Xalapeños ilustres #40",
  "idPerfilAspirante" : 1,
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "video" : "",
  "curriculum" : "",
  "telefono" : "2285095502",
  "nombre" : "Joaquin perez"
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * consulta el perfil de un aspirante en especifico
 * consulta el perfil de un aspirante en especifico buscandolo por su id 
 *
 * idPerfilAspirante Integer identificador unico del aspirante
 * returns PerfilAspirantes
 **/
exports.getPerfilAspirantesIdPerfilAspirante = function(idPerfilAspirante) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "oficios" : [ {
    "idExperienciaLaboral" : 1,
    "cantidadAnios" : 25,
    "idCategoria" : 1,
    "nombre" : "albañilería"
  }, {
    "idExperienciaLaboral" : 1,
    "cantidadAnios" : 25,
    "idCategoria" : 1,
    "nombre" : "albañilería"
  } ],
  "fechaNacimiento" : "1980-05-24T00:00:00.000+00:00",
  "direccion" : "Xalapeños ilustres #40",
  "idPerfilAspirante" : 1,
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "video" : "",
  "curriculum" : "",
  "telefono" : "2285095502",
  "nombre" : "Joaquin perez"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consultar informacion de perfil demandante
 * Se consulta una lista de demandantes  
 *
 * returns List
 **/
exports.getPerfilDemandantes = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "fechaNacimiento" : "1968-12-11T00:00:00.000+00:00",
  "direccion" : "Xalapeños ilustres #40",
  "idPerfilDemandante" : 1,
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "telefono" : "2969621184",
  "nombre" : "Josue buendia"
}, {
  "fechaNacimiento" : "1968-12-11T00:00:00.000+00:00",
  "direccion" : "Xalapeños ilustres #40",
  "idPerfilDemandante" : 1,
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "telefono" : "2969621184",
  "nombre" : "Josue buendia"
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * consulta el perfil de un demandante en especifico
 * Consulta el perfil de un administrador en especifico buscandolo por su id 
 *
 * idPerfilDemandante Integer identificador unico del demandante
 * returns PerfilDemandantes
 **/
exports.getPerfilDemandantesIdPerfilDemandante = function(idPerfilDemandante) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "fechaNacimiento" : "1968-12-11T00:00:00.000+00:00",
  "direccion" : "Xalapeños ilustres #40",
  "idPerfilDemandante" : 1,
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "telefono" : "2969621184",
  "nombre" : "Josue buendia"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * consultar catalogo de perfiles empleadores
 * Se consulta una lista de empleadores 
 *
 * returns List
 **/
exports.getPerfilEmpleadores = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "nombreOrganizacion" : "the alchemist enterprice",
  "fechaNacimiento" : "1980-05-11T00:00:00.000+00:00",
  "idPerfilEmpleador" : 2,
  "direccion" : "Xalapeños ilustres #40",
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "advertenciaBloqueo" : 2,
  "telefono" : "5561151502",
  "nombre" : "Pedro valenzuela"
}, {
  "nombreOrganizacion" : "the alchemist enterprice",
  "fechaNacimiento" : "1980-05-11T00:00:00.000+00:00",
  "idPerfilEmpleador" : 2,
  "direccion" : "Xalapeños ilustres #40",
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "advertenciaBloqueo" : 2,
  "telefono" : "5561151502",
  "nombre" : "Pedro valenzuela"
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * consulta el perfil de un empleador en especifico
 * consulta el perfil de un empleador en especifico buscandolo por su id 
 *
 * idPerfilEmpleador Integer identificador unico del empleador
 * returns PerfilEmpleadores
 **/
exports.getPerfilEmpleadoresIdPerfilEmpleador = function(idPerfilEmpleador) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "nombreOrganizacion" : "the alchemist enterprice",
  "fechaNacimiento" : "1980-05-11T00:00:00.000+00:00",
  "idPerfilEmpleador" : 2,
  "direccion" : "Xalapeños ilustres #40",
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "advertenciaBloqueo" : 2,
  "telefono" : "5561151502",
  "nombre" : "Pedro valenzuela"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consultar perfil de usuario
 * Se consulta la informacion del usuario asi como sus datos personales 
 *
 * idPerfilUsuario Integer identificador unico de una cuenta de usuario del sistema
 * returns PerfilUsuarios
 **/
exports.getPerfilUsuarioIdPerfilUsuario = function(idPerfilUsuario) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
  "tipo" : 3,
  "estatus" : 1,
  "idPerfilUsuario" : 1,
  "nombreUsuario" : "skylake",
  "correoElectronico" : "elcamello@outlook.com",
  "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
  "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Consultar catalogo de perfiles de usuario
 * Consulta del catalogo de todos los perfiles de usuario registrados en el sistema 
 *
 * returns List
 **/
exports.getPerfilUsuarios = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
  "tipo" : 3,
  "estatus" : 1,
  "idPerfilUsuario" : 1,
  "nombreUsuario" : "skylake",
  "correoElectronico" : "elcamello@outlook.com",
  "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
  "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
}, {
  "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
  "tipo" : 3,
  "estatus" : 1,
  "idPerfilUsuario" : 1,
  "nombreUsuario" : "skylake",
  "correoElectronico" : "elcamello@outlook.com",
  "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
  "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Desabilitar perfil de usuario
 * Se Deshabilita el perfil de usuario 
 *
 * idPerfilUsuario Integer identificador unico de una cuenta de usuario del sistema
 * no response value expected for this operation
 **/
exports.patchPerfilUsuariosDeshabilitar = function(idPerfilUsuario) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


/**
 * habilitar perfil de usuario
 * se habilita el perfil de usuario que solicito anteriormente la desactivación de su perfil 
 *
 * idPerfilUsuario Integer identificador unico de una cuenta de usuario del sistema
 * no response value expected for this operation
 **/
exports.patchPerfilUsuariosHabilitar = function(idPerfilUsuario) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


/**
 * Registrar  un aspirante en catalogo de aspirantes
 * Se agrega un nuevo aspirantes enviando la información a registrar 
 *
 * body Object  (optional)
 * returns PerfilAspirantes
 **/
exports.postPerfilAspirantes = function(body) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "oficios" : [ {
    "idExperienciaLaboral" : 1,
    "cantidadAnios" : 25,
    "idCategoria" : 1,
    "nombre" : "albañilería"
  }, {
    "idExperienciaLaboral" : 1,
    "cantidadAnios" : 25,
    "idCategoria" : 1,
    "nombre" : "albañilería"
  } ],
  "fechaNacimiento" : "1980-05-24T00:00:00.000+00:00",
  "direccion" : "Xalapeños ilustres #40",
  "idPerfilAspirante" : 1,
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "video" : "",
  "curriculum" : "",
  "telefono" : "2285095502",
  "nombre" : "Joaquin perez"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Registrar demandante en catalogo de demandantes
 * Se agrega un nuevo demandante enviando la información a registrar 
 *
 * body Object  (optional)
 * returns PerfilDemandantes
 **/
exports.postPerfilDemandantes = function(body) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "fechaNacimiento" : "1968-12-11T00:00:00.000+00:00",
  "direccion" : "Xalapeños ilustres #40",
  "idPerfilDemandante" : 1,
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "telefono" : "2969621184",
  "nombre" : "Josue buendia"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Registrar empleador en catalogo de empleadores
 * Se agrega un nuevo empleador enviando la informacion a registrar
 *
 * body Object  (optional)
 * returns PerfilEmpleadores
 **/
exports.postPerfilEmpleadores = function(body) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "nombreOrganizacion" : "the alchemist enterprice",
  "fechaNacimiento" : "1980-05-11T00:00:00.000+00:00",
  "idPerfilEmpleador" : 2,
  "direccion" : "Xalapeños ilustres #40",
  "usuario" : {
    "clave" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "tipo" : 3,
    "estatus" : 1,
    "idPerfilUsuario" : 1,
    "nombreUsuario" : "skylake",
    "correoElectronico" : "elcamello@outlook.com",
    "fotografia" : "$2a$08$9ODrZxVW4w2LpaSng2AiN9btL4xGZsgP9xpATpE19OWwO7Srm",
    "token" : "$2a$08$9ODrZxVW4w2LpaSng2.1zuAiN9btL4xGZsgP9xpATpE19OWwO7Srm"
  },
  "advertenciaBloqueo" : 2,
  "telefono" : "5561151502",
  "nombre" : "Pedro valenzuela"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}


/**
 * Modificar perfil demandante
 * el demandante puede modificar la información de su perfil 
 *
 * body Object  (optional)
 * idPerfilDemandante Integer identificador unico del demandante
 * no response value expected for this operation
 **/
exports.putPerfilDemandantesIdPerfilDemandante = function(body,idPerfilDemandante) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


/**
 * Modificar perfil empleador
 * el usuario empleador puede modificar la información de su perfil de usuario 
 *
 * body Object  (optional)
 * idPerfilEmpleador Integer identificador unico del empleador
 * no response value expected for this operation
 **/
exports.putPerfilEmpleadoresIdPerfilEmpleador = function(body,idPerfilEmpleador) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


/**
 * Modificar perfil administrador
 * el usuario administrador puede modificar la información de su perfil de usuario 
 *
 * body Object  (optional)
 * idPerfilAdministrador Integer identificador unico del administrador
 * no response value expected for this operation
 **/
exports.putPerfilUsuariosIdPerfilAdminitrador = function(body,idPerfilAdministrador) {
  return new Promise(function(resolve, reject) {
    resolve();
  });
}


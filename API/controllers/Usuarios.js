'use strict';

var utils = require('../utils/writer.js');
var Usuarios = require('../service/UsuariosService');

module.exports.getPerfilAdministradores = function getPerfilAdministradores (req, res, next) {
  Usuarios.getPerfilAdministradores()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getPerfilAdministradoresIdPerfilAdministrador = function getPerfilAdministradoresIdPerfilAdministrador (req, res, next, idPerfilAdministrador) {
  Usuarios.getPerfilAdministradoresIdPerfilAdministrador(idPerfilAdministrador)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getPerfilAspirantes = function getPerfilAspirantes (req, res, next) {
  Usuarios.getPerfilAspirantes()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getPerfilAspirantesIdPerfilAspirante = function getPerfilAspirantesIdPerfilAspirante (req, res, next, idPerfilAspirante) {
  Usuarios.getPerfilAspirantesIdPerfilAspirante(idPerfilAspirante)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getPerfilDemandantes = function getPerfilDemandantes (req, res, next) {
  Usuarios.getPerfilDemandantes()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getPerfilDemandantesIdPerfilDemandante = function getPerfilDemandantesIdPerfilDemandante (req, res, next, idPerfilDemandante) {
  Usuarios.getPerfilDemandantesIdPerfilDemandante(idPerfilDemandante)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getPerfilEmpleadores = function getPerfilEmpleadores (req, res, next) {
  Usuarios.getPerfilEmpleadores()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getPerfilEmpleadoresIdPerfilEmpleador = function getPerfilEmpleadoresIdPerfilEmpleador (req, res, next, idPerfilEmpleador) {
  Usuarios.getPerfilEmpleadoresIdPerfilEmpleador(idPerfilEmpleador)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getPerfilUsuarioIdPerfilUsuario = function getPerfilUsuarioIdPerfilUsuario (req, res, next, idPerfilUsuario) {
  Usuarios.getPerfilUsuarioIdPerfilUsuario(idPerfilUsuario)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getPerfilUsuarios = function getPerfilUsuarios (req, res, next) {
  Usuarios.getPerfilUsuarios()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.patchPerfilUsuariosDeshabilitar = function patchPerfilUsuariosDeshabilitar (req, res, next, idPerfilUsuario) {
  Usuarios.patchPerfilUsuariosDeshabilitar(idPerfilUsuario)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.patchPerfilUsuariosHabilitar = function patchPerfilUsuariosHabilitar (req, res, next, idPerfilUsuario) {
  Usuarios.patchPerfilUsuariosHabilitar(idPerfilUsuario)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.postPerfilAspirantes = function postPerfilAspirantes (req, res, next, body) {
  Usuarios.postPerfilAspirantes(body)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.postPerfilDemandantes = function postPerfilDemandantes (req, res, next, body) {
  Usuarios.postPerfilDemandantes(body)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.postPerfilEmpleadores = function postPerfilEmpleadores (req, res, next, body) {
  Usuarios.postPerfilEmpleadores(body)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.putPerfilDemandantesIdPerfilDemandante = function putPerfilDemandantesIdPerfilDemandante (req, res, next, body, idPerfilDemandante) {
  Usuarios.putPerfilDemandantesIdPerfilDemandante(body, idPerfilDemandante)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.putPerfilEmpleadoresIdPerfilEmpleador = function putPerfilEmpleadoresIdPerfilEmpleador (req, res, next, body, idPerfilEmpleador) {
  Usuarios.putPerfilEmpleadoresIdPerfilEmpleador(body, idPerfilEmpleador)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.putPerfilUsuariosIdPerfilAdminitrador = function putPerfilUsuariosIdPerfilAdminitrador (req, res, next, body, idPerfilAdministrador) {
  Usuarios.putPerfilUsuariosIdPerfilAdminitrador(body, idPerfilAdministrador)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

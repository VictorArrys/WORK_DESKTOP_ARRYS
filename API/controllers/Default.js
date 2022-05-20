'use strict';

var utils = require('../utils/writer.js');
var Default = require('../service/DefaultService');

module.exports.perfilAspirantesIdPerfilAspirantePUT = function perfilAspirantesIdPerfilAspirantePUT (req, res, next, body, idPerfilAspirante) {
  Default.perfilAspirantesIdPerfilAspirantePUT(body, idPerfilAspirante)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

const mysql = require('mysql');

const mysqlConnection = mysql.createConnection({
    host : 'localhost',
    database : 'deser_el_camello',
    user : 'Camello',
    password: "root",
    port: 3306
});


mysqlConnection.connect(function (err) {
    if (err) {
      console.log(err)
    } else {
      console.log('BD Conectada XD')
    }
  })

  module.exports = mysqlConnection
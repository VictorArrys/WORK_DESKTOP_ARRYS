var mysql = require('mysql');

exports.conn = mysql.createConnection({
    host : 'localhost',
    database : 'deser_el_camello',
    user : 'Camello',
    password: "root",
    port: 3306
});


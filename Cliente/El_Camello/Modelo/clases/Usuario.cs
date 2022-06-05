using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class Usuario
    {
        private string clave;
        private string tipo;
        private string estatus;  //parsear en api
        private string nombreUsuario; // falta propiedad
        private int idPerfilusuario;
        private string correoElectronico;
        private byte[] fotografia;
        private string rutaFotografia; 
        private string tipoUsuario;
        private string token;

        public string Clave { get => clave; set => clave = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Estatus { get => estatus; set => estatus = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public int IdPerfilusuario { get => idPerfilusuario; set => idPerfilusuario = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public byte[] Fotografia { get => fotografia; set => fotografia = value; }
        public string RutaFotografia { get => rutaFotografia; set => rutaFotografia = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string Token { get => token; set => token = value; }

        public override string ToString()
        {
            return Clave + "\n" + Tipo + "\n" + Estatus + "\n" + Fotografia;
        }
    }
}

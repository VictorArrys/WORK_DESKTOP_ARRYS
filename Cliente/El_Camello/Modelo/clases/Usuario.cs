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
        private int estatus;
        private int idPerfilusuario;
        private string correoElectronico;
        private byte[] fotografia;
        private string tipoUsuario;
        private string token;

        public string Clave { get => clave; set => clave = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Estatus { get => estatus; set => estatus = value; }
        public int IdPerfilusuario { get => idPerfilusuario; set => idPerfilusuario = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public byte[] Fotografia { get => fotografia; set => fotografia = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string Token { get => token; set => token = value; }

        public override string ToString()
        {
            return clave + "\n" + tipo + "\n" + estatus + "\n" + fotografia;
        }
    }
}

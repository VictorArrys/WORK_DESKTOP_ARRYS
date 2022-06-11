using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    internal class Demandante :Usuario
    {
        private int idDemandante;
        private int idPerfilUsuarioDemandante;
        private int nombreUsuario;
        private int estatus;
        private string clave;
        private string correoElectronico;
        private byte[] fotografia;
        private int tipoUsuario;
        private string nombre;
        private DateTime fechaNacimiento;
        private string telefono;
        private string direccion;

        public int IdDemandante { get => idDemandante; set => idDemandante = value; }
        public int IdPerfilUsuarioDemandante { get => idPerfilUsuarioDemandante; set => idPerfilUsuarioDemandante = value; }
        public int NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public int Estatus { get => estatus; set => estatus = value; }
        public string Clave { get => clave; set => clave = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public byte[] Fotografia { get => fotografia; set => fotografia = value; }
        public int TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
    }
}

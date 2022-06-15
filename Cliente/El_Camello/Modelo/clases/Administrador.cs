using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class Administrador: Usuario
    {
        private int idPerfilAdministrador;
        private string nombre;
        private string telefono;

        public int IdPerfilAdministrador { get => idPerfilAdministrador; set => idPerfilAdministrador = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}

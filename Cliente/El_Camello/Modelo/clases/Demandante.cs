using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class Demandante :Usuario
    {
        private int idDemandante;
        private int idPerfilUsuarioDemandante;
        private string nombreDemandante;
        private DateTime fechaNacimiento;
        private string telefono;
        private string direccion;

        public int IdDemandante { get => idDemandante; set => idDemandante = value; }
        public int IdPerfilUsuarioDemandante { get => idPerfilUsuarioDemandante; set => idPerfilUsuarioDemandante = value; }
        public string NombreDemandante { get => nombreDemandante; set => nombreDemandante = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
    }
}

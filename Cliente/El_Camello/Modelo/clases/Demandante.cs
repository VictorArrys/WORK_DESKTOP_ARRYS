using System;

namespace El_Camello.Modelo.clases
{
    public class Demandante :Usuario
    {
        private int idDemandante;
        private string nombreDemandante;
        private DateTime fechaNacimiento;
        private string telefono;
        private string direccion;

        public int IdDemandante { get => idDemandante; set => idDemandante = value; }
        public string NombreDemandante { get => nombreDemandante; set => nombreDemandante = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
    }
}

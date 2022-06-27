using System;

namespace El_Camello.Modelo.clases
{
    public class Empleador: Usuario
    {
        private int idPerfilEmpleador;
        private string nombreOrganizacion;
        private string nombreEmpleador;
        private string direccion;
        private DateTime fechaNacimiento;
        private string telefono;
        private int amonestaciones;

        public int IdPerfilEmpleador { get => idPerfilEmpleador; set => idPerfilEmpleador = value; }
        public string NombreOrganizacion { get => nombreOrganizacion; set => nombreOrganizacion = value; }
        public string NombreEmpleador { get => nombreEmpleador; set => nombreEmpleador = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int Amonestaciones { get => amonestaciones; set => amonestaciones = value; }
    }
}

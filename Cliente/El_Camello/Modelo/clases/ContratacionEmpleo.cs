using System;
using System.Collections.Generic;

namespace El_Camello.Modelo.clases
{
    public class ContratacionEmpleo
    {
        private int idContratacion;
        private int estatus;
        private DateTime fechaContratacion;
        private int idOfertaEmpleo;
        private DateTime fechaFinalizacionContratacion;
        private string nombreEmpleador;
        private string nombteOfertaEmpleo;


        private List<ContratacionEmpleoAspirante> contratacionesAspirantes;

        public ContratacionEmpleo()
        {
            contratacionesAspirantes = new List<ContratacionEmpleoAspirante>();
        }

        public List<ContratacionEmpleoAspirante> ContratacionesAspirantes { get => contratacionesAspirantes; set => contratacionesAspirantes = value; }
        public int Estatus { get => estatus; set => estatus = value; }
        public DateTime FechaContratacion { get => fechaContratacion; set => fechaContratacion = value; }
        public int IdContratacion { get => idContratacion; set => idContratacion = value; }
        public int IdOfertaEmpleo { get => idOfertaEmpleo; set => idOfertaEmpleo = value; }
        public DateTime FechaFinalizacionContratacion { get => fechaFinalizacionContratacion; set => fechaFinalizacionContratacion = value; }
        public string NombreEmpleador { get => nombreEmpleador; set => nombreEmpleador = value; }
        public string NombteOfertaEmpleo { get => nombteOfertaEmpleo; set => nombteOfertaEmpleo = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class ContratacionEmpleo
    {
        private int estatus;
        private DateTime fechaContratacion;
        private int idContratacion;
        private int idOfertaEmpleo;
        private DateTime fechaFinalizacionContratacion;

        private List<ContratacionEmpleoAspirante> contratacionesAspirantes;

        public List<ContratacionEmpleoAspirante> ContratacionesAspirantes { get => contratacionesAspirantes; set => contratacionesAspirantes = value; }
        public int Estatus { get => estatus; set => estatus = value; }
        public DateTime FechaContratacion { get => fechaContratacion; set => fechaContratacion = value; }
        public int IdContratacion { get => idContratacion; set => idContratacion = value; }
        public int IdOfertaEmpleo { get => idOfertaEmpleo; set => idOfertaEmpleo = value; }
        public DateTime FechaFinalizacionContratacion { get => fechaFinalizacionContratacion; set => fechaFinalizacionContratacion = value; }
    }
}

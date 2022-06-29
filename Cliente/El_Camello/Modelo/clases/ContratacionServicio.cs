using System;

namespace El_Camello.Modelo.clases
{
    public class ContratacionServicio
    {
        private int idContratacionServicio;
        private Demandante demandante;
        private Aspirante aspirante;
        private int estatus;
        private DateTime fechaContratacion;
        private DateTime fechaFinalizacion;
        private int valoracionAspirante;
        private string tituloEmpleo;

        public ContratacionServicio()
        {
            demandante = new Demandante();
            aspirante = new Aspirante();
            estatus = -2;
            fechaContratacion = DateTime.Now;
            fechaFinalizacion = DateTime.Now;
            valoracionAspirante = 0;
            tituloEmpleo = "";
        }

        public int IdContratacionServicio { get => idContratacionServicio; set => idContratacionServicio = value; }
        public Demandante Demandante { get => demandante; set => demandante = value; }
        public Aspirante Aspirante { get => aspirante; set => aspirante = value; }
        public int Estatus { get => estatus; set => estatus = value; }
        public DateTime FechaContratacion { get => fechaContratacion; set => fechaContratacion = value; }
        public DateTime FechaFinalizacion { get => fechaFinalizacion; set => fechaFinalizacion = value; }
        public int ValoracionAspirante { get => valoracionAspirante; set => valoracionAspirante = value; }
        public string TituloEmpleo { get => tituloEmpleo; set => tituloEmpleo = value; }
    }
}

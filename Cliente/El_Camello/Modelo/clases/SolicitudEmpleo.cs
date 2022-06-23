using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class SolicitudEmpleo
    {
        private int idSolicitud;
        private int idAspirante;
        private int idOfertaEmpleo;
        private string estatus;
        private int estatusInt;
        private DateTime fechaRegistro;
        private string nombre;
        private int idUsuarioAspirante;
        private Aspirante aspiranteSolicitante;

        public SolicitudEmpleo()
        {
            this.aspiranteSolicitante = new Aspirante();
            this.idSolicitud = 0;
        }

        public int IdSolicitud { get => idSolicitud; set => idSolicitud = value; }
        public int IdAspirante { get => idAspirante; set => idAspirante = value; }
        public int IdOfertaEmpleo { get => idOfertaEmpleo; set => idOfertaEmpleo = value; }
        public string Estatus { get => estatus; set => estatus = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public int EstatusInt { get => estatusInt; set => estatusInt = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int IdUsuarioAspirante { get => idUsuarioAspirante; set => idUsuarioAspirante = value; }
        internal Aspirante AspiranteSolicitante { get => aspiranteSolicitante; set => aspiranteSolicitante = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    internal class SolicitudServicio
    {
        private int idSolicitudServicio;
        private int idPerfilAspirante;
        private int idPerfilDemandante;
        private string titulo;
        private int estatus;
        private string estatusSolicitud;
        private DateTime fechaRegistro;

        public int IdSolicitudServicio { get => idSolicitudServicio; set => idSolicitudServicio = value; }
        public int IdPerfilAspirante { get => idPerfilAspirante; set => idPerfilAspirante = value; }
        public int IdPerfilDemandante { get => idPerfilDemandante; set => idPerfilDemandante = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public int Estatus { get => estatus; set => estatus = value; }
        public string EstatusSolicitud 
        {
            get
            {
                if (estatus == -1)
                {
                    return "Rechazada";
                }else if (estatus == 0)
                {
                    return "Pendiente";
                }else if (estatus == 1)
                {
                    return "Aceptado";
                }
                else
                {
                    return "";
                }
            }
        }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
    }
}

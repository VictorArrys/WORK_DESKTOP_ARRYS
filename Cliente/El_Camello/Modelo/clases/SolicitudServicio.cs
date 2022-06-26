using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class SolicitudServicio
    {
        private int idSolicitudServicio;
        private Aspirante aspirante;
        private Demandante demandante;

        private string titulo;
        private int estatus;
        private string descripcion;
        private DateTime fechaRegistro;

        public SolicitudServicio()
        {
            idSolicitudServicio = 0;
            aspirante = new Aspirante();
            demandante = new Demandante();
            titulo = "";
            estatus = -2;
            descripcion = "";
            fechaRegistro = DateTime.Now;
        }

        public int IdSolicitudServicio { get => idSolicitudServicio; set => idSolicitudServicio = value; }
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
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Aspirante Aspirante { get => aspirante; set => aspirante = value; }
        public Demandante Demandante { get => demandante; set => demandante = value; }
    }
}

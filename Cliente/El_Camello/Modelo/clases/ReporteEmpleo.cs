using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class ReporteEmpleo
    {
        private int idReporte;
        private int idAspiranteReporte;
        private int idOfertaReportada;
        private string motivo;
        private int estatus;
        private DateTime fechaRegistro;
        private string nombreAspirante;
        private string nombreOfertaReportada;
        private string descripcionOfertaReportada;
        private string nombreEmpleador;

        public int IdReporte { get => idReporte; set => idReporte = value; }
        public int IdAspiranteReporte { get => idAspiranteReporte; set => idAspiranteReporte = value; }
        public int IdOfertaReportada { get => idOfertaReportada; set => idOfertaReportada = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public int Estatus { get => estatus; set => estatus = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string NombreAspirante { get => nombreAspirante; set => nombreAspirante = value; }
        public string NombreOfertaReportada { get => nombreOfertaReportada; set => nombreOfertaReportada = value; }
        public string NombreEmpleador { get => nombreEmpleador; set => nombreEmpleador = value; }
        public string DescripcionOfertaReportada { get => descripcionOfertaReportada; set => descripcionOfertaReportada = value; }
    }
}

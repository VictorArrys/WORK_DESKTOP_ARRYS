using System;

namespace El_Camello.Modelo.clases
{
    public class ReporteEmpleo
    {
        private int idReporte;
        private int idAspirante;
        private int idOfertaReportada;
        private string motivo;
        private int estatus;
        private DateTime fechaRegistro;
        private string nombreAspirante;
        private string nombreOfertaReportada;
        private string descripcionOfertaReportada;
        private int idEmpleador;
        private string nombreEmpleador;

        public int IdReporte { get => idReporte; set => idReporte = value; }
        public int IdAspirante { get => idAspirante; set => idAspirante = value; }
        public int IdOfertaReportada { get => idOfertaReportada; set => idOfertaReportada = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public int Estatus { get => estatus; set => estatus = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string NombreAspirante { get => nombreAspirante; set => nombreAspirante = value; }
        public string NombreOfertaReportada { get => nombreOfertaReportada; set => nombreOfertaReportada = value; }
        public string NombreEmpleador { get => nombreEmpleador; set => nombreEmpleador = value; }
        public string DescripcionOfertaReportada { get => descripcionOfertaReportada; set => descripcionOfertaReportada = value; }
        public int IdEmpleador { get => idEmpleador; set => idEmpleador = value; }
    }
}

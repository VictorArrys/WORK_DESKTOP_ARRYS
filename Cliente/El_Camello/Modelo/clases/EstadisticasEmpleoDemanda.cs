using System;

namespace El_Camello.Modelo.clases
{
    public class EstadisticasEmpleoDemanda
    {
        private int solicitudesEstadisticas;
        private string categoriaEmpleo;
        private DateTime fechaEstadisticas;

        public int SolicitudesEstadisticas { get => solicitudesEstadisticas; set => solicitudesEstadisticas = value; }
        public string CategoriaEmpleo { get => categoriaEmpleo; set => categoriaEmpleo = value; }
        public DateTime FechaEstadisticas { get => fechaEstadisticas; set => fechaEstadisticas = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

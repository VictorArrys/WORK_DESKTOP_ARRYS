using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class EstadisticasOfertasEmpleo
    {
        private string fecha;
        private int ofertasPublicadas;

        public string Fecha { get => fecha; set => fecha = value; }
        public int OfertasPublicadas { get => ofertasPublicadas; set => ofertasPublicadas = value; }
    }
}

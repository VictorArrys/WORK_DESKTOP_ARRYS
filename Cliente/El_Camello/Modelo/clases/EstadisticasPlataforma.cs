using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class EstadisticasPlataforma
    {
        private string categoriaEmpleo;
        private int ofertasPublicadas;
        private string mesFecha;
        private string yearFecha;

        public string CategoriaEmpleo { get => categoriaEmpleo; set => categoriaEmpleo = value; }
        public int OfertasPublicadas { get => ofertasPublicadas; set => ofertasPublicadas = value; }
        public string MesFecha { get => mesFecha; set => mesFecha = value; }
        public string YearFecha { get => yearFecha; set => yearFecha = value; }
    }
}

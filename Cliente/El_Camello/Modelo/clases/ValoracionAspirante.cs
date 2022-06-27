using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class ValoracionAspirante
    {
        private int idValoracionAspirante;
        private string nombreAspirante;
        private int evaluacionAspirante;
        
        public int IdValoracionAspirante { get => idValoracionAspirante; set => idValoracionAspirante = value; }
        public string NombreAspirante { get => nombreAspirante; set => nombreAspirante = value; }
        public int EvaluacionAspirante { get => evaluacionAspirante; set => evaluacionAspirante = value; }

    }
}

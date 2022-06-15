using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class ValoracionEmpleador
    {
        private int idValoracionEmpleador;
        private string nombreEmpleador;
        private int evaluacionEmpleador;

        public int IdValoracionEmpleador { get => idValoracionEmpleador; set => idValoracionEmpleador = value; }
        public string NombreEmpleador { get => nombreEmpleador; set => nombreEmpleador = value; }
        public int EvaluacionEmpleador { get => evaluacionEmpleador; set => evaluacionEmpleador = value; }
    }
}

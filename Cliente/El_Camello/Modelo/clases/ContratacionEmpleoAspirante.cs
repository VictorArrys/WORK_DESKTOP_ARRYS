using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class ContratacionEmpleoAspirante
    {
        private int idAspirante;
        private string nombreAspiranteContratado;
        private int valoracionAspirante;

        public int IdAspirante { get => idAspirante; set => idAspirante = value; }
        public string NombreAspiranteContratado { get => nombreAspiranteContratado; set => nombreAspiranteContratado = value; }
        public int ValoracionAspirante { get => valoracionAspirante; set => valoracionAspirante = value; }
    }
}

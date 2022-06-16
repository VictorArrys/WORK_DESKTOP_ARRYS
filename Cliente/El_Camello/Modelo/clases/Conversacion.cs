using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class Conversacion
    {
        private int idConversacion;
        private string titulo;
        private DateTime fechaContratacion;
        private string nombreAspirante;
        private List<Mensaje> mensajes;

        public Conversacion()
        {
            idConversacion = 0;
            titulo = "";
            fechaContratacion = new DateTime();
            nombreAspirante = "";
            mensajes = new List<Mensaje>();
        }

        public int IdConversacion { get => idConversacion; set => idConversacion = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public DateTime FechaContratacion { get => fechaContratacion; set => fechaContratacion = value; }
        public string NombreAspirante { get => nombreAspirante; set => nombreAspirante = value; }
        internal List<Mensaje> Mensajes { get => mensajes; set => mensajes = value; }
    }
}

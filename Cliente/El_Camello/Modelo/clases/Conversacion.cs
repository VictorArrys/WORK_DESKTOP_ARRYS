using System;
using System.Collections.Generic;

namespace El_Camello.Modelo.clases
{
    public class Conversacion
    {
        private int idConversacion;
        private string titulo;
        private DateTime fechaContratacion;
        private string nombreAspirante;
        private List<Mensaje> mensajes;
        private string categoria;

        public Conversacion()
        {
            idConversacion = 0;
            titulo = "";
            fechaContratacion = new DateTime();
            nombreAspirante = "";
            mensajes = new List<Mensaje>();
            categoria = "";
        }

        public int IdConversacion { get => idConversacion; set => idConversacion = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public DateTime FechaContratacion { get => fechaContratacion; set => fechaContratacion = value; }
        public string NombreAspirante { get => nombreAspirante; set => nombreAspirante = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public List<Mensaje> Mensajes { get => mensajes; set => mensajes = value; }
    }
}

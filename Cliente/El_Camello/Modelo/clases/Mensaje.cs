using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class Mensaje
    {
        private int idMensaje;
        private int idUsuarioRemitente;
        private DateTime fechaRegistro;
        private string remitente;
        private string contenidoMensaje;
        private string tipoUsuario;

        public int IdMensaje { get => idMensaje; set => idMensaje = value; }
        public int IdUsuarioRemitente { get => idUsuarioRemitente; set => idUsuarioRemitente = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string Remitente { get => remitente; set => remitente = value; }
        public string ContenidoMensaje { get => contenidoMensaje; set => contenidoMensaje = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
    }
}

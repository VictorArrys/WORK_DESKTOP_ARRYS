using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class Aspirante : Usuario  
    {
        private int idAspirante;
        private int idUsuario;
        private string nombreAspirante;
        private string direccion;
        private DateTime fechaNacimiento;
        private List<Oficio> oficios;
        private string telefono;
        private byte[] curriculum;
        private string rutaCurriculum;
        private MemoryStream video;
        private string rutaVideo;

        public int IdAspirante { get => idAspirante; set => idAspirante = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NombreAspirante { get => nombreAspirante; set => nombreAspirante = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public byte[] Curriculum { get => curriculum; set => curriculum = value; }
        public string RutaCurriculum { get => rutaCurriculum; set => rutaCurriculum = value; }
        public string RutaVideo { get => rutaVideo; set => rutaVideo = value; }
        public MemoryStream Video { get => video; set => video = value; }
        internal List<Oficio> Oficios { get => oficios; set => oficios = value; }
    }
}

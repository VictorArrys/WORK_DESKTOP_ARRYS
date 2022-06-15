using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Camello.Modelo.clases
{
    public class FotografiaOferta
    {
        private int idFotografia;
        private byte[] imagen;

        public int IdFotografia { get => idFotografia; set => idFotografia = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
    }
}


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

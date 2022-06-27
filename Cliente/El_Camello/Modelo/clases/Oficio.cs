
namespace El_Camello.Modelo.clases
{
    internal class Oficio
    {
        private int idAspirante;
        private int idCategoria;
        private string experiencia;
        private string nombreCategoria;

        public int IdAspirante { get => idAspirante; set => idAspirante = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string Experiencia { get => experiencia; set => experiencia = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }
    }
}

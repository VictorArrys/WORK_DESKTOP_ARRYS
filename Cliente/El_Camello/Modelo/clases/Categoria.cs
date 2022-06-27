namespace El_Camello.Modelo.clases
{
    internal class Categoria
    {
        private int idCategoria;
        private string nombreCategoria;

        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }

        public override string ToString()
        {
            return nombreCategoria;
        }


    }


}

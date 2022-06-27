using El_Camello.Modelo.clases;
using System.Windows.Controls;

namespace El_Camello.Vistas.Empleador.controles
{
    /// <summary>
    /// Lógica de interacción para ConversacionControl.xaml
    /// </summary>
    public partial class ConversacionControl : UserControl
    {
        public Conversacion conversacion;

        public Conversacion Conversacion
        {
            get
            {
                return conversacion;
            }
            set
            {
                conversacion = value;
                if (conversacion != null)
                {
                    lblNombre.Content = "Título: " + conversacion.Titulo;
                    lblCategoria.Content = "Categoria: " + conversacion.Categoria;
                }
            }
        }

        public ConversacionControl()
        {
            InitializeComponent();
            conversacion = new Conversacion();
        }
    }
}

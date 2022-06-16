using El_Camello.Modelo.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace El_Camello.Vistas.Aspirante.controles
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
                    lblFechaContratacion.Content = "Fecha contratación: " + conversacion.FechaContratacion.ToShortDateString();
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

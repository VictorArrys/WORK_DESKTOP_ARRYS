using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using El_Camello.Vistas.Aspirante.controles;
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
using System.Windows.Shapes;

namespace El_Camello.Vistas.Aspirante
{
    /// <summary>
    /// Lógica de interacción para BuscarOfertaEmpleo.xaml
    /// </summary>
    public partial class BuscarOfertaEmpleo : Window
    {
        Modelo.clases.Aspirante aspirante;
        public BuscarOfertaEmpleo(Modelo.clases.Aspirante aspirante)
        {
            InitializeComponent();
            this.aspirante = aspirante;
            CargarVentana();

        }

        private void CargarVentana()
        {
            CargarCbxCategorias();
            CargartblOfertas();
        }

        private async void CargartblOfertas()
        {
            int[] listaCategorias = { 1};
            //listaCategorias = aspirante.Oficios.Select(oficio => oficio.IdCategoria).ToArray<int>();
            List<OfertaEmpleo> listaOfertas = await OfertaEmpleoDAO.GetBuscarOfertasEmpleo(listaCategorias, aspirante.Token);
            foreach (OfertaEmpleo item in listaOfertas)
            {
                OfertaEmpleoControl ofertaEmpleoControl = new OfertaEmpleoControl();
                ofertaEmpleoControl.OfertaEmpleo = item;
                pnlOfertasEmpleo.Children.Add(ofertaEmpleoControl);
            }
        }

        private async void CargarCbxCategorias()
        {
            this.cbxCategorias.ItemsSource = await CategoriaDAO.GetCategorias();
        }

        private void btnBuscarOfertas_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

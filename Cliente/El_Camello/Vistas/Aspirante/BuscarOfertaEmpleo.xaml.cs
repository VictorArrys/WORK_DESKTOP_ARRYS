using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using El_Camello.Vistas.Aspirante.controles;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
            int[] listaCategorias = aspirante.Oficios.Select(oficio => oficio.IdCategoria).ToArray<int>();
            List<OfertaEmpleo> listaOfertas = await OfertaEmpleoDAO.GetBuscarOfertasEmpleo(listaCategorias, aspirante.Token);
            BuscarOfertasEmpleo(listaCategorias);
        }

        private async void CargarCbxCategorias()
        {
            this.cbxCategorias.ItemsSource = await CategoriaDAO.GetCategorias();
        }

        private void btnBuscarOfertas_Click(object sender, RoutedEventArgs e)
        {
            if (cbxCategorias.SelectedIndex > -1)
            {
                int[] categoriaSeleccionada = { ((Categoria)cbxCategorias.SelectedItem).IdCategoria };
                BuscarOfertasEmpleo(categoriaSeleccionada);
            }
        }

        private async void BuscarOfertasEmpleo(int[] listaCategorias)
        {
            List<OfertaEmpleo> listaOfertas = await OfertaEmpleoDAO.GetBuscarOfertasEmpleo(listaCategorias, aspirante.Token);
            pnlOfertasEmpleo.Children.Clear();
            foreach (OfertaEmpleo item in listaOfertas)
            {
                OfertaEmpleoControl ofertaEmpleoControl = new OfertaEmpleoControl();
                ofertaEmpleoControl.OfertaEmpleo = item;
                ofertaEmpleoControl.Aspirante = aspirante;
                pnlOfertasEmpleo.Children.Add(ofertaEmpleoControl);
            }
        }
        
    }
}

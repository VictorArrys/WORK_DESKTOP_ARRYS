using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using El_Camello.Vistas.Demandante.controles;
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

namespace El_Camello.Vistas.Demandante
{
    /// <summary>
    /// Lógica de interacción para BuscarAspiranteServicio.xaml
    /// </summary>
    public partial class BuscarAspiranteServicio : Window
    {
        Modelo.clases.Demandante demandante;

        public BuscarAspiranteServicio(Modelo.clases.Demandante demandante)
        {
            InitializeComponent();
            this.demandante = demandante;
            CargarVentana();
        }

        private async void CargarVentana()
        {
            List<Categoria> listaCategorias = await CategoriaDAO.GetCategorias();
            cbCategorias.ItemsSource = listaCategorias;
        }

        private void BuscarAspirantes(object sender, SelectionChangedEventArgs e)
        {
            if (cbCategorias.SelectedIndex >= 0)
            {
                ConsultarYMostrarAspirantes();
            }
        }

        private async void ConsultarYMostrarAspirantes()
        {
            int idCategoria = ((Modelo.clases.Categoria)cbCategorias.SelectedItem).IdCategoria;
            List<Modelo.clases.Aspirante> listaAspirantes = await AspiranteDAO.GetAspirantes(idCategoria, demandante.Token);
            pnlAspirante.Children.Clear();
            foreach(Modelo.clases.Aspirante aspirante in listaAspirantes)
            {
                AspiranteControl controlAspirante = new AspiranteControl(demandante,aspirante);
                pnlAspirante.Children.Add(controlAspirante);

            }

        }

        
    }
}

using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace El_Camello.Vistas.Administrador
{
    /// <summary>
    /// Lógica de interacción para categoriasEmpleo.xaml
    /// </summary>
    public partial class categoriasEmpleo : Page
    {
        List<Categoria> categoriasTabla = null;
        Categoria categoriaSeleccionada = null;
        string token;


        public categoriasEmpleo(string token)
        {
            InitializeComponent();
            categoriasTabla = new List<Categoria>();
            categoriaSeleccionada = new Categoria();
            this.token = token;
            CargarCategorias();

        }

        private async void CargarCategorias()
        {
            categoriasTabla = await CategoriaDAO.GetCategorias();
            dgCategorias.ItemsSource = categoriasTabla;
            btnModificarCategoria.IsEnabled = false;
            btnEliminarCategoria.IsEnabled = false;
            btnDeshacer.IsEnabled = false;
        }
        

        private async void btnRegistrarCategoria_Click(object sender, RoutedEventArgs e)
        {

            if (tbNombreCategoria.Text == "")
            {
                MessageBox.Show("Favor de llenar el campo requerido", "Campo Vacio");
            }
            else
            {
                string nombre = tbNombreCategoria.Text;
                int resultado = await CategoriaDAO.PostCategoria(nombre, token);
                if (resultado == 1)
                {
                    MessageBox.Show("Categoria registrada con éxito", "¡Operación!");
                    limpiarCampos();
                    CargarCategorias();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al registrar una nueva categoría", "¡Operación!");
                }
            }
        }



        private async void btnEliminarCategoria_Click(object sender, RoutedEventArgs e)
        {

            int id = categoriaSeleccionada.IdCategoria;
            int resultado = await CategoriaDAO.DeleteCategoria(id, token);
            if (resultado == 1)
            {
                MessageBox.Show("Categoria eliminada con éxito", "¡Operación!");
                limpiarCampos();
                CargarCategorias();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar la categoría seleccionada, verificar si la categoria esta en uso por otro usuario", "¡Operación!");
            }
            
        }

        private async void btnModificarCategoria_Click(object sender, RoutedEventArgs e)
        {

            if (categoriaSeleccionada != null)
            {

                if (categoriaSeleccionada.NombreCategoria == tbNombreCategoria.Text)
                {
                    MessageBox.Show("No se puede realizar un actualización ya que no has modificado la categoria", "!Operación¡");
                }
                else
                {
                    categoriaSeleccionada.NombreCategoria = tbNombreCategoria.Text;
                    int resultado = await CategoriaDAO.PatchCategoria(categoriaSeleccionada, token);
                    if (resultado == 1)
                    {
                        MessageBox.Show("Categoria actualizada con éxito", "¡Operación!");
                        limpiarCampos();
                        CargarCategorias();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al modificar la categoría seleccionada. verificar si no se modifico el nombre", "¡Operación!");
                    }
                }
                
            }
            
        }


        private void btnDeshacer_Click(object sender, RoutedEventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            dgCategorias.SelectedItem = null;
            btnDeshacer.IsEnabled = false;
            btnEliminarCategoria.IsEnabled = false;
            btnModificarCategoria.IsEnabled = false;
            btnRegistrarCategoria.IsEnabled = true;
            tbNombreCategoria.Text = "";
            categoriaSeleccionada = null;
            CargarCategorias();
        }

        private void dgSeleccionCategoria(object sender, SelectionChangedEventArgs e)
        {
            btnRegistrarCategoria.IsEnabled = false;
            btnModificarCategoria.IsEnabled = true;
            btnEliminarCategoria.IsEnabled = true;
            btnDeshacer.IsEnabled = true;
            categoriaSeleccionada = (Categoria)dgCategorias.SelectedItem;

            if (categoriaSeleccionada != null)
            {
                tbNombreCategoria.Text = categoriaSeleccionada.NombreCategoria;
            }
        }

        private void tbBuscarCambio(object sender, TextChangedEventArgs e)
        {
            if (categoriasTabla.Count > 0)
            {
                var categoriasFiltradas = categoriasTabla.Where(Categoria => Categoria.NombreCategoria.ToLower().Contains(tbBuscar.Text.ToLower()));
                dgCategorias.AutoGenerateColumns = false;
                dgCategorias.ItemsSource = categoriasFiltradas;
            }
        }
    }
}

using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
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
            CargarCategorias(token);

        }

        private async void CargarCategorias(string token)
        {
            categoriasTabla = await CategoriaDAO.GetCategorias(token);
            dgCategorias.ItemsSource = categoriasTabla;
            btnModificarCategoria.IsEnabled = false;
            btnEliminarCategoria.IsEnabled = false;
            btnDeshacer.IsEnabled = false;
        }
        
        private void CargarCategoriasLocal()  // por validar si se queda o no
        {
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
                string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZFVzdWFyaW8iOjE3MiwiY2xhdmUiOiIxMjM0NTYiLCJ0aXBvIjoiQWRtaW5pc3RyYWRvciIsImlhdCI6MTY1NTM0NDIzNCwiZXhwIjoxNjU1NDMwNjM0fQ.iqE7FYK_8KVJqFFFtQUxwCpQIzek6gSNB6srxtCtlMU";
                int resultado = await CategoriaDAO.PostCategoria(nombre, token);
                if (resultado == 1)
                {
                    MessageBox.Show("Categoria registrada con éxito", "¡Operación!");
                    limpiarCampos();
                    CargarCategorias(token);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al registrar una nueva categoría", "¡Operación!");
                }
            }
        }



        private async void btnEliminarCategoria_Click(object sender, RoutedEventArgs e)// probar de nuevo
        {

            int id = categoriaSeleccionada.IdCategoria;

            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZFVzdWFyaW8iOjE3MiwiY2xhdmUiOiIxMjM0NTYiLCJ0aXBvIjoiQWRtaW5pc3RyYWRvciIsImlhdCI6MTY1NTM0NDIzNCwiZXhwIjoxNjU1NDMwNjM0fQ.iqE7FYK_8KVJqFFFtQUxwCpQIzek6gSNB6srxtCtlMU";
            int resultado = await CategoriaDAO.DeleteCategoria(id, token);
            if (resultado == 1)
            {
                MessageBox.Show("Categoria eliminada con éxito", "¡Operación!");
                limpiarCampos();
                CargarCategorias(token);
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
                categoriaSeleccionada.NombreCategoria = tbNombreCategoria.Text;
                string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZFVzdWFyaW8iOjE3MiwiY2xhdmUiOiIxMjM0NTYiLCJ0aXBvIjoiQWRtaW5pc3RyYWRvciIsImlhdCI6MTY1NTM4NzQyOCwiZXhwIjoxNjU1NDczODI4fQ.lBtLMa3IokAij2uqqvQ-3OUJA3COXbkGtAYLSIVGdbc";
                int resultado = await CategoriaDAO.PatchCategoria(categoriaSeleccionada, token);
                if (resultado == 1)
                {
                    MessageBox.Show("Categoria actualizada con éxito", "¡Operación!");
                    limpiarCampos();
                    CargarCategorias(token);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al modificar la categoría seleccionada. verificar si no se modifico el nombre", "¡Operación!");
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
            CargarCategoriasLocal();
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
    }
}

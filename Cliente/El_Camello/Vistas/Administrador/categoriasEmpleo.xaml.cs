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
        //List<Categoria> categoriasTabla = null;
        Categoria categoriaSeleccionada = null; 


        public categoriasEmpleo()
        {
            InitializeComponent();
            CargarCategoriasTabla();
        }

        private async void CargarCategoriasTabla()
        {
            List<Categoria> categoriasTabla = new List<Categoria>();
            //aqui pasar el token que viene desde el inicio de seción
            //categoriasTabla = await CategoriaDAO.GetCategorias();

            //gCategorias.ItemsSource = categoriasTabla;
        }

        private async void btnRegistrarCategoria_Click(object sender, RoutedEventArgs e)
        {
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZFVzdWFyaW8iOjEsImNsYXZlIjoiMTExMDk4IiwidGlwbyI6IkFkbWluaXN0cmFkb3IiLCJpYXQiOjE2NTQzNTQ3NDAsImV4cCI6MTY1NDQ0MTE0MH0.1Nm4C3vVs-jH3_zpcYBmJTqH9DQA_LH6b3VPRJSucaw";

            string nombre = tbNombreCategoria.Text;
            if (nombre.Length > 0)
            {
                int idCategoria = await CategoriaDAO.PostCategoria(nombre, token);
                if (idCategoria > 0)
                {
                    MessageBox.Show("registro de categoria exitoso");
                    CargarCategoriasTabla();
                    tbNombreCategoria.Text = "";
                }
            }
        }



        private async void btnEliminarCategoria_Click(object sender, RoutedEventArgs e)
        {
            bool resultadoEliminar;
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZFVzdWFyaW8iOjEsImNsYXZlIjoiMTExMDk4IiwidGlwbyI6IkFkbWluaXN0cmFkb3IiLCJpYXQiOjE2NTQzNTQ3NDAsImV4cCI6MTY1NDQ0MTE0MH0.1Nm4C3vVs-jH3_zpcYBmJTqH9DQA_LH6b3VPRJSucaw";
            if (dgCategorias.SelectedIndex > -1)
            {
                categoriaSeleccionada = (Categoria)dgCategorias.SelectedItem;
                resultadoEliminar =  await CategoriaDAO.DeleteCategoria(categoriaSeleccionada.IdCategoria, token);

                if (resultadoEliminar)
                {
                    MessageBox.Show("Categoria eliminada con éxito...", "OPERACIÓN!");
                    CargarCategoriasTabla();
                }

            }
        }

        private async void btnModificarCategoria_Click(object sender, RoutedEventArgs e)
        {
            bool resultadoActualización; 
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZFVzdWFyaW8iOjEsImNsYXZlIjoiMTExMDk4IiwidGlwbyI6IkFkbWluaXN0cmFkb3IiLCJpYXQiOjE2NTQzNTQ3NDAsImV4cCI6MTY1NDQ0MTE0MH0.1Nm4C3vVs-jH3_zpcYBmJTqH9DQA_LH6b3VPRJSucaw";
            if (dgCategorias.SelectedIndex > -1)
            {
                categoriaSeleccionada = (Categoria)dgCategorias.SelectedItem;
                categoriaSeleccionada.NombreCategoria = tbNombreCategoria.Text;
                resultadoActualización = await CategoriaDAO.PatchCategoria(categoriaSeleccionada, token);

                if (resultadoActualización)
                {
                    MessageBox.Show("Categoria actualizada exitosamente...", "OPERACIÓN!");
                    CargarCategoriasTabla();
                }
            }
        }
    }
}

using El_Camello.Assets.utilerias;
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

namespace El_Camello.Empleador
{
    /// <summary>
    /// Interaction logic for EvaluarApirante.xaml
    /// </summary>
    public partial class EvaluarApirante : Window
    {
        private ContratacionEmpleoAspirante aspiranteEvaluar;
        private string token;
        private int idOfertaEmpleo;
        List<string> valoraciones;
        MensajesSistema mensajes;

        public EvaluarApirante()
        {
            InitializeComponent();
        }

        public EvaluarApirante(ContratacionEmpleoAspirante aspiranteEvaluar, int idOfertaEmpleo, string token)
        {
            this.aspiranteEvaluar = aspiranteEvaluar;
            this.token = token;
            this.idOfertaEmpleo = idOfertaEmpleo;

            InitializeComponent();
            cargarValoraciones();
            cargarAspiranteEvaluar();
        }

        private void cargarValoraciones()
        {
            valoraciones = new List<string>();
            cbValoraciones.Items.Clear();
            valoraciones.Add("1: Es incumplido e irresponsable en el laboral");
            valoraciones.Add("2: Es incumplido pero se hace responsable");
            valoraciones.Add("3: Cuenta con las actitudes positivas en el ambiente laboral");
            valoraciones.Add("4: Cuenta con algunas aptitudes y las actitudes en el ambiente laboral");
            valoraciones.Add("5: Cuenta con todas las aptitudes y actitudes en el ambiente laboral");

            cbValoraciones.ItemsSource = valoraciones;

        }

        private void cargarAspiranteEvaluar() {

            lbNombre.Content = aspiranteEvaluar.NombreAspiranteContratado;
        }

        private int obtenerValoracion()
        {
            int valoracion = 0;

            int valoracionSeleccionada = (int)cbValoraciones.SelectedIndex;
            switch (valoracionSeleccionada)
            {
                case 0:
                    valoracion = 1;
                    break;
                case 1:
                    valoracion = 2;
                    break;
                case 2:
                    valoracion = 3;
                    break;
                case 3:
                    valoracion = 4;
                    break;
                case 4:
                    valoracion = 5;
                    break;
                case -1:
                    mensajes = new MensajesSistema("AccionInvalida", "Ha intentado evaluar al aspirante", "Evaluar aspirante", "Se ha intentado evaluar al aspirante sin seleccionar una valoación antes");
                    mensajes.ShowDialog();
                    break;

            }


            return valoracion;
        }

        private void evaluar(object sender, RoutedEventArgs e)
        {
            int valorEvaluacion = obtenerValoracion();
            aspiranteEvaluar.ValoracionAspirante = valorEvaluacion;
            evaluarAspirante();

        }

        private async void evaluarAspirante()
        {
            int evaluado = 0;

            evaluado = await ContratacionEmpleoAspiranteDAO.PatchEvaluarAspirante(aspiranteEvaluar, idOfertaEmpleo, token);

            if(evaluado > 0)
            {

                mensajes = new MensajesSistema("AccionExistosa", "Se ha evaluado exitosamente al aspirante", "Evaluar aspirante", "Se ha asignado una valoración de: " + evaluado + " al aspirante: " + aspiranteEvaluar.NombreAspiranteContratado);
                mensajes.ShowDialog();
                this.Close();
            }
            else
            {
                mensajes = new MensajesSistema("Error", "No se ha evaluado al aspirante, intente más tarde", "Evaluar aspirante", "No se ha asignado una valoración al aspirante: " + aspiranteEvaluar.NombreAspiranteContratado + " debido a un error");
                mensajes.ShowDialog();
            }

        }


    }
}

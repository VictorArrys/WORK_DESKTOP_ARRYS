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

namespace El_Camello.Vistas.Usuario
{
    /// <summary> ¿Has oido hablar del manco de día y cojo de noche?
    /// Lógica de interacción para RegistroPerfil.xaml
    /// </summary>
    public partial class RegistroPerfil : Window
    {
        public RegistroPerfil()
        {
            InitializeComponent();
            CargarPantalla();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tipoUsuario = cbTipoUsuario.SelectedValue.ToString();
            switch (tipoUsuario)
            {
                case "Empleador":
                    RegistrarEmpleador ventanaRegistroEmp = new RegistrarEmpleador();
                    ventanaRegistroEmp.Show();
                    this.Close();
                    break;
                case "Aspirante":
                    RegistrarAspirante ventanaRegistroAsp = new RegistrarAspirante();
                    ventanaRegistroAsp.Show();
                    this.Close();
                    break;
                case "Demandante":
                    RegistrarDemandante ventanaRegistroDem = new RegistrarDemandante();
                    ventanaRegistroDem.Show();
                    this.Close();
                    break;
            }
            
        }

        private void CargarPantalla()
        {
            cbTipoUsuario.Items.Clear();
            cbTipoUsuario.Items.Add("Empleador");
            cbTipoUsuario.Items.Add("Demandante");
            cbTipoUsuario.Items.Add("Aspirante");
            cbTipoUsuario.SelectedIndex = 0;
        }

        private void seleccionTipoUsuario(object sender, SelectionChangedEventArgs e)
        {
            int indiceSeleccion = cbTipoUsuario.SelectedIndex;
            tbDescripcion.Text = "";
            if (indiceSeleccion == 0)
            {
                tbDescripcion.Text = "Persona u organización encargada de emplear y mantener el vínculo contractual " +
                    "laboral, poseen la capacidad de contratar a individuos que necesiten acorde a las necesidades operativas " +
                    "o productivas puestos de trabajo de acuerdo con un oficio en particular";
            }else if (indiceSeleccion == 1)
            {
                tbDescripcion.Text = "Aquella persona candidata a un puesto de trabajo formal o informal, de acuerdo " +
                    "a sus necesidades especifica cuál es su experiencia laboral, asi como en una breve descripción de " +
                    "sus habilidades duras y blandas, solicita vacantes de trabajo o acepta algún servicio a convenir con " +
                    "los los usuarios postulantes de servicios.";
            }else if (indiceSeleccion == 2)
            {
                tbDescripcion.Text = "Persona demandante de un servicio en un mercado determinado o ofertante de servicios" +
                    " sin un contrato fijo, los demandantes de servicio pueden publicar algún servicio en particular en " +
                    "la plataforma y los aspirantes de servicios pueden atender estas publicaciones";
            }
        }
    }
}

using El_Camello.Modelo.clases;
using System.Windows.Controls;

namespace El_Camello.Vistas.Aspirante.controles
{
    public partial class ContratacionControl : UserControl
    {
        private ContratacionServicio contratacionServicio;
        private ContratacionEmpleo contratacionEmpleo;

        public ContratacionControl()
        {
            InitializeComponent();
        }

        public ContratacionEmpleo ContratacionEmpleo { 
            get => contratacionEmpleo; 
            set
            {
                contratacionEmpleo = value;
                lblEmpledor.Content = contratacionEmpleo.NombreEmpleador;
                lblEmpleo.Content = contratacionEmpleo.NombteOfertaEmpleo;
                lblFechaContratacion.Content = contratacionEmpleo.FechaContratacion;
            } 
        }
        internal ContratacionServicio ContratacionServicio { 
            get => contratacionServicio; 
            set
            {
                contratacionServicio = value;
                lblFechaContratacion.Content = contratacionServicio.FechaContratacion;
                lblEmpledor.Content = contratacionServicio.Demandante.NombreDemandante;
                lblEmpleo.Content = contratacionServicio.TituloEmpleo;
            }
        }
    }
}

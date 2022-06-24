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
                //contratacionEmpleo = value;
                //lblEmpledor.Content 
            } 
        }
        internal ContratacionServicio ContratacionServicio { 
            get => contratacionServicio; 
            set
            {
                //contratacionServicio = value;
                //lblFechaContratacion.Content = 
            }
        }
    }
}

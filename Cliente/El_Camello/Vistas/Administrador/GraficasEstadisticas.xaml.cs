using El_Camello.Modelo.clases;
using El_Camello.Modelo.dao;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace El_Camello.Vistas.Administrador
{
    /// <summary>
    /// Interaction logic for ReportesEstadisticos.xaml
    /// </summary>
    public partial class GraficasEstadisticas : Page
    {
        private string tokenAdministrador;
        private List<EstadisticasOfertasEmpleo> estadisticasPlataforma;
        private List<EstadisticasEmpleoDemanda> estadisticasEmpleoDemandas;
        private List<ValoracionEmpleador> valoracionesEmpleadores;

        private string[] fechasEstadisticas;
        private Array ofertasPublicadas;

        public ISeries[] Series { get; set; } = new ISeries[]
        {
            new ColumnSeries<int>
            {
                DataLabelsSize = 14,
                DataLabelsPaint = new SolidColorPaint(SKColors.Blue),
                Values = new []{ 2, 5, 4, 2, 6 },
                Name = "Income",
                Stroke = null
            }
        };
        public List<Axis> XAxes1 { get => XAxes; set => XAxes = value; }

        List<Axis> XAxes = new List<Axis>
        {
            new Axis
            {
                

                // Use the labels property to define named labels.
                Labels = new string[] { "" },
                LabelsRotation = 45
            }
        };

    public GraficasEstadisticas(string token)
        {
            this.tokenAdministrador = token;
            InitializeComponent();

            //cargarEstadisticas();
            this.crPlataforma.Series = Series;
            this.crPlataforma.XAxes = XAxes1;



        }
        
        private void cargarEstadisticas()
        {
            cargarEstadisticasPlataforma();
        }

        private async void cargarEstadisticasPlataforma()
        {
            estadisticasPlataforma = await EstadisticasDAO.GetEstadisticasOfertas(tokenAdministrador);
            estadisticasEmpleoDemandas = await EstadisticasDAO.GetEstadisticasDemanda(tokenAdministrador);
            valoracionesEmpleadores = await EstadisticasDAO.GetValoracionesEmpleadores(tokenAdministrador);


        }
 


    }
}

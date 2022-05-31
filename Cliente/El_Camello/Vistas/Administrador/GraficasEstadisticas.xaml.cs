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
using System.Windows.Forms.DataVisualization.Charting;

namespace El_Camello.Vistas.Administrador
{
    /// <summary>
    /// Interaction logic for ReportesEstadisticos.xaml
    /// </summary>
    public partial class GraficasEstadisticas : Window
    {
        public GraficasEstadisticas()
        {
            InitializeComponent();

            chart1.Series["Series1"].LegendText = "Visitas 2017";

            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("19-FEB-2017", 576);
            dic.Add("20-FEB-2017", 1087);
            dic.Add("21-FEB-2017", 1061);
            dic.Add("22-FEB-2017", 660);
            dic.Add("23-FEB-2017", 774);

            foreach (KeyValuePair<string, int> d in dic)
            {
                chart1.Series["Series1"].Points.AddXY(d.Key, d.Value);
            }

        }
    }
}

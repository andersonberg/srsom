using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Visifire.Charts;
using Visifire.Commons;

namespace FirstTryVisifire
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            CreateChart();
        }

        public void CreateChart()
        {
            Chart chart = new Chart();

            chart.Theme = "Theme1";
            
            Title title = new Title();
            title.Text = "Filmes Cliente 1";
            chart.Titles.Add(title);

            DataSeries dataSeries = new DataSeries();
            dataSeries.RenderAs = RenderAs.Point;

            DataPoint dataPoint = new DataPoint();
            dataPoint.XValue = 5;
            dataPoint.YValue = 16;
            dataPoint.ToolTipText = "Filme1";

            DataPoint dataPoint2 = new DataPoint();
            dataPoint2.XValue = 8;
            dataPoint2.YValue = 11;
            dataPoint2.ToolTipText = "Filme2";

            dataSeries.DataPoints.Add(dataPoint);
            dataSeries.DataPoints.Add(dataPoint2);

            chart.Series.Add(dataSeries);

            gridPrincipal.Children.Add(chart);
        }
    }
}

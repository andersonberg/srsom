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

namespace FirstChart
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();

            // Create a Visifire Chart
            CreateChart();
        }

        /// <summary>
        /// Function to create a chart
        /// </summary>
        public void CreateChart()
        {
            // Create a new instance of Chart
            Chart chart = new Chart();

            // Set the chart width and height
            chart.Width = 500;
            chart.Height = 300;

            // Set chart property
            chart.Theme = "Theme2";

            // Create a new instance of Title
            Title title = new Title();

            // Set title property
            title.Text = "Visifire Sample Chart";

            // Add title to Titles collection
            chart.Titles.Add(title);

            // Create a new instance of DataSeries
            DataSeries dataSeries = new DataSeries();

            // Set DataSeries property
            dataSeries.RenderAs = RenderAs.Column;

            // Create a random class variable
            Random rand = new Random(DateTime.Now.Millisecond);
            
            // Create a DataPoint
            DataPoint dataPoint;

            for (int i = 0; i < 5; i++)
            {   
                // Create a new instance of DataPoint
                dataPoint = new DataPoint(); 

                // Set YValue for a DataPoint
                dataPoint.YValue = rand.Next(10, 100); 

                // Add dataPoint to DataPoints collection
                dataSeries.DataPoints.Add(dataPoint); 
            }

            // Add dataSeries to Series collection.
            chart.Series.Add(dataSeries);

            // Add chart to LayoutRoot
            LayoutRoot.Children.Add(chart);
        }
    }
}

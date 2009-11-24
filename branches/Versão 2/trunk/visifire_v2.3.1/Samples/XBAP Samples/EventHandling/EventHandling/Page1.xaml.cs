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

namespace EventHandling
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
            chart = new Chart();

            // Create a new instance of Title
            Title title = new Title();

            // Set title property
            title.Text = "Visifire Sample with Events";

            // Attach event to Title
            title.MouseLeftButtonDown += new MouseButtonEventHandler(title_MouseLeftButtonDown);

            // Add title to Titles collection
            chart.Titles.Add(title);

            // Create a new instance of DataSeries
            DataSeries dataSeries = new DataSeries();

            // Set DataSeries property
            dataSeries.RenderAs = RenderAs.Column;

            // Attach event to DataSeries
            dataSeries.MouseLeftButtonUp += new MouseButtonEventHandler(dataSeries_MouseLeftButtonUp);

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

            // Add dataSeries to Series collection
            chart.Series.Add(dataSeries);

            // Add chart to LayoutRoot
            LayoutRoot.Children.Add(chart);
        }

        /// <summary>
        /// Event handler for MouseLeftButtonUp event of DataSeries
        /// </summary>
        /// <param name="sender">DataPoint</param>
        /// <param name="e">MouseButtonEventArgs</param>
        void dataSeries_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Update YValue property of the DataPoint
            (sender as DataPoint).YValue = rand.Next(10, 100);
        }

        /// <summary>
        /// Event handler for MouseLeftButtonDown event of Title
        /// </summary>
        /// <param name="sender">Title</param>
        /// <param name="e">MouseButtonEventArgs</param>
        void title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {   
            (sender as Title).FontColor = new SolidColorBrush(Color.FromArgb((Byte)rand.Next(0,255), (Byte)rand.Next(0,255), (Byte)rand.Next(0,255), (Byte)rand.Next(0,255)));
            (sender as Title).FontSize = rand.Next(8, 20);    
        }

        Chart chart;                                            // Chart object
        Random rand = new Random(DateTime.Now.Millisecond);     // Create a random class variable
    }
}

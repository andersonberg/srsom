using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Visifire.Charts;
using Visifire.Commons;

namespace EventHandling
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            // Create a Chart
            CreateChart();
        }

        /// <summary>
        /// Function to create a Chart
        /// </summary>
        public void CreateChart()
        {
            // Create a new instance of Chart.
            Chart chart = new Chart();

            // Set the chart width and height
            chart.Width = 500;
            chart.Height = 300;

            // Create a new instance of Title
            Title title = new Title();

            // Set title property
            title.Text = "Visifire Sample with Events";

            // Attach event to Title
            title.MouseLeftButtonDown += new MouseButtonEventHandler(title_MouseLeftButtonDown);

            // Add title to Titles collection of the Chart
            chart.Titles.Add(title);

            // Create a new instance of DataSeries
            DataSeries dataSeries = new DataSeries();

            // Set DataSeries property
            dataSeries.RenderAs = RenderAs.Column;

            // Create a DataPoint
            DataPoint dataPoint;

            for (int i = 0; i < 5; i++)
            {
                // Create a new instance of DataPoint
                dataPoint = new DataPoint(); 

                // Set YValue for a DataPoint
                dataPoint.YValue = rand.Next(10, 100); 

                // Attach event to DataPoint
                dataPoint.MouseLeftButtonUp += new MouseButtonEventHandler(dataPoint_MouseLeftButtonUp); 

                // Add dataPoint to DataPoints collection of the DataSeries.
                dataSeries.DataPoints.Add(dataPoint); 
            }

            // Add dataSeries to Series collection.
            chart.Series.Add(dataSeries);

            // Add chart to LayoutRoot
            LayoutRoot.Children.Add(chart);
        }

        /// <summary>
        /// Event handler for MouseLeftButtonDown event
        /// </summary>
        /// <param name="sender">Title</param>
        /// <param name="e">MouseButtonEventArgs</param>
        void title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Title).FontColor = new SolidColorBrush(Colors.Red);
        }

        /// <summary>
        /// Event handler for MouseLeftButtonUp event
        /// </summary>
        /// <param name="sender">DataPoint</param>
        /// <param name="e">MouseButtonEventArgs</param>
        void dataPoint_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            (sender as DataPoint).YValue = rand.Next(10, 100);
        }

        Random rand = new Random(DateTime.Now.Millisecond);     //  Create a random class variable
        
    }
}

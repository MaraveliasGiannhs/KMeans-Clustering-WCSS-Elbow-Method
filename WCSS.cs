using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;


namespace Kmeans_Clustering_With_Random_Data
{
    public class WCSS
    {
        public static double CalculateWCSS(List<Point> data, int k, int maxIterations)
        {
            KMeans kmeans = new KMeans(k, maxIterations);
            List<Point> centroids = kmeans.Cluster(data);

            double wcssValue = 0;

            // Calculate cluster assignments
            Dictionary<Point, List<Point>> clusters = new Dictionary<Point, List<Point>>();
            foreach (Point point in data)
            {
                Point nearestCentroid = GetNearestCentroid(point, centroids);
                if (!clusters.ContainsKey(nearestCentroid))
                {
                    clusters[nearestCentroid] = new List<Point>();
                }
                clusters[nearestCentroid].Add(point);
            }

            // Calculate WCSS
            foreach (Point centroid in centroids)
            {
                List<Point> clusterPoints = clusters[centroid];
                foreach (Point point in clusterPoints)
                {
                    wcssValue += Math.Pow(point.DistanceTo(centroid), 2);
                }
            }

            return wcssValue;
        }

        private static Point GetNearestCentroid(Point point, List<Point> centroids)
        {
            double minDistance = double.MaxValue;
            Point nearestCentroid = null;
            foreach (Point centroid in centroids)
            {
                double distance = point.DistanceTo(centroid);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestCentroid = centroid;
                }
            }
            return nearestCentroid;
        }

        public static void PlotWCSSResults(List<Point> data, int maxIterations)
        {
            List<double> wcssValues = new List<double>();

            for (int k = 1; k <= 10; k++)
            {
                double wcss = CalculateWCSS(data, k, maxIterations);
                wcssValues.Add(wcss);
            }

            PlotLineChart(wcssValues);
        }

        private static void PlotLineChart(List<double> wcssValues)
        {
            // Create a new Chart control
            Chart chart = new Chart();
            chart.Size = new System.Drawing.Size(800, 600);

            // Create a new chart area
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Create a series for the WCSS values
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;
            series.Color = System.Drawing.Color.Blue;

            // Add data points to the series
            for (int i = 0; i < wcssValues.Count; i++)
            {
                series.Points.AddXY(i + 1, wcssValues[i]);
            }

            // Add the series to the chart
            chart.Series.Add(series);

            // Set chart title and axis labels
            chart.Titles.Add("WCSS vs. Number of Clusters");
            chart.ChartAreas[0].AxisX.Title = "Number of Clusters (k)";
            chart.ChartAreas[0].AxisY.Title = "Within-Cluster Sum of Squares (WCSS)";

            // Display the chart
            Form chartForm = new Form();
            chartForm.Text = "WCSS vs. Number of Clusters";
            chartForm.Controls.Add(chart);
            chartForm.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kmeans_Clustering_With_Random_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate random data
            Random random = new Random();
            List<Point> data = new List<Point>();
            for (int i = 0; i < 100; i++)  //datapoints
            {
                //edw kane add apo excel
                data.Add(new Point(random.NextDouble() * 100, random.NextDouble() * 100));  //up to
            }

            // Perform KMeans clustering
            KMeans kmeans = new KMeans(k: 10, maxIterations: 100);
            List<Point> centroids = kmeans.Cluster(data);

            // Print data points and their cluster labels
            Console.WriteLine("Data Points and their Cluster Labels:");
            for (int i = 0; i < data.Count; i++)
            {
                Point point = data[i];
                Point centroid = kmeans.GetNearestCentroid(point);
                int clusterIndex = centroids.IndexOf(centroid);
                Console.WriteLine($"Data Point {i + 1}: ({point.X}, {point.Y}) - Cluster: {clusterIndex}");
            }

            // Print the locations of the clusters
            Console.WriteLine("\nLocations of Clusters:");
            for (int i = 0; i < centroids.Count; i++)
            {
                Console.WriteLine($"Cluster {i}: ({centroids[i].X}, {centroids[i].Y})");
            }

            // Draw chart
            KMeansChart kMeansChart = new KMeansChart();
            kMeansChart.Plot(data, centroids, kmeans);

            
            double wcss = WCSS.CalculateWCSS(data, 10, 100);
            Console.WriteLine("WCSS: " + wcss);

            WCSS.PlotWCSSResults(data, 100); // Assuming 100 max iterations for KMeans

        }
    }
}

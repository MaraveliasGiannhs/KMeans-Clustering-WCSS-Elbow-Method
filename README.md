## KMeans Clustering and WCSS Elbow Method
The purpose of this project is to simulate data collection via randomly generating numbers, then use that data as a dataset for KMeans algorithm and then use that data again for WCSS algorithm. 
After running the program, three things will show up:

1. A windows console showing the values (location) of each data, the cluster they belong to, the cluster's location and the WCSS score.
2. A plot graph showing the data (non-red dots) and clusters (red dots).
3. A graph showing the "elbow" point that WCSS made.

Note: The WCSS graph and the WCSS score in the console will show up after closing the KMeans plot graph.

## Prerequisites
Visual Studio 2019+

## Installation
git clone https://github.com/MaraveliasGiannhs/KMeans-Clustering-WCSS-Elbow-Method.git

## Known Issues:

Unhandled Exception: System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary.
   at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
   at Kmeans_Clustering_With_Random_Data.KMeans.Cluster(List`1 data) in C:\Users\giann\OneDrive\Desktop\Kmeans Clustering With Random Data\Kmeans Clustering With Random Data\KMeans.cs:line 50
   at Kmeans_Clustering_With_Random_Data.WCSS.CalculateWCSS(List`1 data, Int32 k, Int32 maxIterations) in C:\Users\giann\OneDrive\Desktop\Kmeans Clustering With Random Data\Kmeans Clustering With Random Data\WCSS.cs:line 15
   at Kmeans_Clustering_With_Random_Data.WCSS.PlotWCSSResults(List`1 data, Int32 maxIterations) in C:\Users\giann\OneDrive\Desktop\Kmeans Clustering With Random Data\Kmeans Clustering With Random Data\WCSS.cs:line 66
   at Kmeans_Clustering_With_Random_Data.Program.Main(String[] args) in C:\Users\giann\OneDrive\Desktop\Kmeans Clustering With Random Data\Kmeans Clustering With Random Data\Program.cs:line 51

These exceptions sometimes show up , other times they dont and the program runs fine. 



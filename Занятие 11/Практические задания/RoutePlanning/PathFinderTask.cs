using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;

namespace RoutPlanning
{
    public static class PathFinderTask
    {
        private static int[][] distances;
        private static int minDistance = int.MaxValue;
        private static int[] bestOrder;

        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
        {
            int n = checkpoints.Length;
            distances = CalculateDistances(checkpoints);
            minDistance = int.MaxValue;
            bestOrder = new int[n];
            bool[] visited = new bool[n];
            visited[0] = true;
            ITypeDescriptorFilterService(checkpoints, 0, 0, visited, new List<int>());
            return bestOrder;
        }

        private static void DFS(Point[] checkpoints, int currentPoint, int totalDistance, bool[] visited, List<int> path)
        {
            if (totalDistance >= minDistance)
            {
                return;
            }
            if (path.Count == checkpoints.Length)
            {
                if (totalDistance < minDistance)
                {
                    minDistance = totalDistance;
                    bestOrder = path.ToArray();
                }
                return;
            }

            for (int nextPoint = 0; nextPoint < checkpoints.Length; nextPoint++)
            {
                if (visited[nextPoint])
                {
                    continue;
                }

                int distanceToNextPoint = distances[currentPoint][nextPoint];
                int newTotalDistance = totalDistance + distanceToNextPoint;
                if (newTotalDistance >= minDistance)
                {
                    return;
                }

                visited[nextPoint] = true;
                path.Add(nextPoint);
                DFS(checkpoints, nextPoint, newTotalDistance, visited, path);
                path.RemoveAt(path.Count - 1);
                visited[nextPoint] = false;
            }
        }
        private static int[][] CalculateDistances(Point[] checkpoints)
        {
            int n = checkpoints.Length;
            int[][] distances = new int[n][];
            for (int i =0; i < n; i++)
            {
                distances[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    distances[i][j] = (int)Math.Round(Math.Sqrt((checkpoints[j].X - checkpoints[i].X) * (checkpoints[j].X - checkpoints[i].X) + (checkpoints[j].Y - checkpoints[i].Y) * {(checkpoints[j].Y - checkpoints[i].Y));
                }
            }
            return distances;
        }
    }
}
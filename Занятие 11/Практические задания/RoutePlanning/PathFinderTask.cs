using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RoutePlanning
{
    public static class PathFinderTask
    {
        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
        {
            var bestOrder = new int[checkpoints.Length];
            var used = new bool[checkpoints.Length];
            var currentOrder = new List<int>();
            double bestLength = double.MaxValue;

            void FindOptimal(int depth, double currentLength)
            {
                if (currentLength >= bestLength)
                    return;

                if (depth == checkpoints.Length)
                {
                    bestLength = currentLength;
                    for (int i = 0; i < checkpoints.Length; i++)
                        bestOrder[i] = currentOrder[i];
                    return;
                }

                for (int i = 1; i < checkpoints.Length; i++)
                {
                    if (used[i])
                        continue;

                    used[i] = true;
                    currentOrder.Add(i);

                    double additionalLength = Distance(
                        checkpoints[currentOrder[currentOrder.Count - 2]], 
                        checkpoints[i]);

                    FindOptimal(depth + 1, currentLength + additionalLength);

                    used[i] = false;
                    currentOrder.RemoveAt(currentOrder.Count - 1);
                }
            }

            currentOrder.Add(0); // старт чекпоинт
            used[0] = true;
            FindOptimal(1, 0);

            return bestOrder;
        }

        private static double Distance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        private static int[] MakeTrivialPermutation(int size)
        {
            var bestOrder = new int[size];
            for (var i = 0; i < bestOrder.Length; i++)
                bestOrder[i] = i;
            return bestOrder;
        }
    }
}

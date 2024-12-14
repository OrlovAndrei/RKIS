using System.Collections.Generic;
using System;
using System.Drawing;
using System.Linq;

namespace RoutePlanning;

public static class PathFinderTask
{
    public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
    {
        if (checkpoints == null || checkpoints.Length == 0) return new int[0];
        if (checkpoints.Length == 1) return new[] { 0 };

        int[] bestOrder = Enumerable.Range(0, checkpoints.Length).ToArray();
        double minDistance = double.PositiveInfinity;

        FindBestOrderRecursive(checkpoints, new List<int>(), 0, 0, ref bestOrder, ref minDistance);

        return bestOrder;
    }

    static void FindBestOrderRecursive(Point[] checkpoints, List<int> currentOrder, int currentIndex, double currentDistance,
                                       ref int[] bestOrder, ref double minDistance)
    {
        if (currentOrder.Count == checkpoints.Length)
        {
            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
                bestOrder = currentOrder.ToArray();
            }
            return;
        }

        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (!currentOrder.Contains(i))
            {
                double distanceToNext = currentOrder.Count == 0
                    ? 0 
                    : Distance(checkpoints[currentOrder.Last()], checkpoints[i]);

                if (currentDistance + distanceToNext >= minDistance) continue; 


                List<int> newOrder = new List<int>(currentOrder);
                newOrder.Add(i);
                FindBestOrderRecursive(checkpoints, newOrder, i, currentDistance + distanceToNext, ref bestOrder, ref minDistance);
            }
        }
    }

    static double Distance(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }

    private static int[] MakeTrivialPermutation(int size)
    {
        var bestOrder = new int[size];
        for (var i = 0; i < bestOrder.Length; i++)
            bestOrder[i] = i;
        return bestOrder;
    }
}

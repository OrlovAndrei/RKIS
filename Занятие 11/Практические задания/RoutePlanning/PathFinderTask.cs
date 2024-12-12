using System;
using System.Collections.Generic;
using System.Drawing;

namespace RoutePlanning
{
    public static class PathFinderTask
    {
        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
        {
            var permutations = new List<int[]>();
            MakePermutations(new int[checkpoints.Length], 1, permutations);
            return GetMinLength(checkpoints, permutations);
        }

        static int[] GetMinLength(Point[] checkpoints, List<int[]> permutations)
        {
            var result = new int[checkpoints.Length];
            double minLength = double.MaxValue;
            foreach (var item in permutations)
            {
                double length = 0;
                for (int i = 0; i < item.Length - 1; i++)
                {
                    length += checkpoints[item[i]].DistanceTo(checkpoints[item[i + 1]]);
                    if (length > minLength)
                    {
                        break;
                    }

                }
                if (length < minLength)
                {
                    result = item;
                    minLength = length;
                }
            }
            return result;
        }

        static void MakePermutations(int[] permutation, int position, List<int[]> permutations)
        {
            if (position == permutation.Length)
            {
                permutations.Add((int[])permutation.Clone());
                return;
            }

            for (int i = 0; i < permutation.Length; i++)
            {
                var index = Array.IndexOf(permutation, i, 0, position);
                if (index != -1)
                    continue;
                permutation[position] = i;
                MakePermutations(permutation, position + 1, permutations);
            }
        }
    }
}
using System.Drawing;

namespace RoutePlanning;
{
    public static class PathFinderTask
    {
        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
        {
            var bestOrder = new int[checkpoints.Length];
            var currentOrder = new int[checkpoints.Length];
            for (int i = 0; i < currentOrder.Length; i++)
                currentOrder[i] = i;

            double bestDistance = double.MaxValue;

            // Запускаем рекурсивный перебор
            FindBestOrder(checkpoints, currentOrder, 1, 0, ref bestDistance, ref bestOrder);
            return bestOrder;
        }

        private static void FindBestOrder(
            Point[] checkpoints,
            int[] currentOrder,
            int position,
            double currentDistance,
            ref double bestDistance,
            ref int[] bestOrder)
        {
            // Если посетили все точки, проверяем путь
            if (position == currentOrder.Length)
            {
                currentDistance += GetDistance(checkpoints[currentOrder[position - 1]], checkpoints[currentOrder[0]]);
                if (currentDistance < bestDistance)
                {
                    bestDistance = currentDistance;
                    Array.Copy(currentOrder, bestOrder, currentOrder.Length);
                }
                return;
            }

            for (int i = position; i < currentOrder.Length; i++)
            {
                // Меняем текущую точку местами с выбранной
                Swap(currentOrder, position, i);

                // Считаем расстояние до следующей точки
                double nextDistance = currentDistance +
                    GetDistance(checkpoints[currentOrder[position - 1]], checkpoints[currentOrder[position]]);

                // Отсечение: прекращаем, если путь уже хуже текущего лучшего
                if (nextDistance < bestDistance)
                {
                    FindBestOrder(checkpoints, currentOrder, position + 1, nextDistance, ref bestDistance, ref bestOrder);
                }

                // Возвращаем прежний порядок
                Swap(currentOrder, position, i);
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static double GetDistance(Point p1, Point p2)
        {
            double dx = p1.X - p2.X;
            double dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
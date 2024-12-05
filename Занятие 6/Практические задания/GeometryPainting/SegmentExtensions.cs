using System.Collections.Generic;
using Avalonia.Media;
using GeometryTasks;

namespace GeometryPainting;
{
public static class SegmentExtensions
    {
        // Словарь для хранения цвета для каждого сегмента
        private static readonly Dictionary<Segment, Color> segmentColors = new Dictionary<Segment, Color>();

        // Метод для установки цвета сегмента
        public static void SetColor(this Segment segment, Color color)
        {
            segmentColors[segment] = color;
        }

        // Метод для получения цвета сегмента
        public static Color GetColor(this Segment segment)
        {
            // Если цвет не задан, возвращаем Color.Black
            return segmentColors.TryGetValue(segment, out var color) ? color : Color.Black;
        }
    }
}

using System.Collections.Generic;
using Avalonia.Media;
using GeometryTasks;

namespace GeometryPainting
{
    public static class SegmentExtensions
    {
        // Хранилище цветов для сегментов
        private static readonly Dictionary<Segment, Color> colors = new Dictionary<Segment, Color>();

        // Метод для установки цвета сегмента
        public static void SetColor(this Segment segment, Color colorValue)
        {
            if (colorValue == null)
            {
                return; // Возвращаемся, если передан null
            }

            // Если сегмент уже есть в словаре, обновляем его цвет
            if (colors.ContainsKey(segment))
            {
                colors[segment] = colorValue;
            }
            else
            {
                // Если нет, добавляем новый сегмент с цветом
                colors.Add(segment, colorValue);
            }
        }

        // Метод для получения цвета сегмента
        public static Color GetColor(this Segment segment)
        {
            if (segment != null && colors.TryGetValue(segment, out Color color))
            {
                return color; // Возвращаем цвет, если он существует
            }
            return Color.FromRgb(0, 0, 0); // Возвращаем черный цвет по умолчанию
        }

        // Метод для проверки, содержит ли данный цвет сегмент
        public static bool Contains(Segment segment, Color colorValue)
        {
            if (segment == null)
            {
                return false; // Возвращаем false, если сегмент null
            }

            return colors.TryGetValue(segment, out Color existingColor) && existingColor != colorValue;
        }

        // Метод для сравнения сегментов
        public static bool Equal(Segment segment1, Segment segment2)
        {
            if (segment1 == null || segment2 == null)
            {
                return false; // Возвращаем false, если один из сегментов null
            }

            return segment1.Begin.X == segment2.Begin.X &&
                   segment1.Begin.Y == segment2.Begin.Y &&
                   segment1.End.X == segment2.End.X &&
                   segment1.End.Y == segment2.End.Y;
        }
    }
}

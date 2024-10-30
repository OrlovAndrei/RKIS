using System.Collections.Generic;
using Avalonia.Media;
using GeometryTasks;

namespace GeometryPainting;


    public static class SegmentExtensions
    {
        private static readonly Dictionary<Segment, Color> SegmentColors = new();
        public static Color GetColor(this Segment segment)
        {
            return SegmentColors.TryGetValue(segment, out var color) ? color : Colors.Black;
        }
        public static void SetColor(this Segment segment, Color color)
        {
            SegmentColors[segment] = color;
        }
    }
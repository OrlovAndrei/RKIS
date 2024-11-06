using System.Collections.Generic;
using Avalonia.Media;
using GeometryTasks;

namespace GeometryPainting
{
    public static class SegmentExtensions
    {
        private static readonly Dictionary<Segment, Color> segmentColors = new Dictionary<Segment, Color>();

        public static void SetColor(this Segment segment, Color newColor)
        {
            if (newColor == null)
            {
                return;
            }

            if (segmentColors.ContainsKey(segment))
            {
                segmentColors[segment] = newColor;
            }
            else
            {
                segmentColors.Add(segment, newColor);
            }
        }
        
        public static bool Contains(Segment segment, Color newColor)
        {
            if (segment == null)
            {
                return false;
            }

            return segmentColors.TryGetValue(segment, out Color currentColor) && currentColor != newColor;
        }

        public static Color GetColor(this Segment segment)
        {
            if (segment != null && segmentColors.TryGetValue(segment, out Color retrievedColor))
            {
                return retrievedColor;
            }
            return Color.FromRgb(0, 0, 0);
        }

        public static bool Equal(Segment firstSegment, Segment secondSegment)
        {
            if (firstSegment == null || secondSegment == null)
            {
                return false;
            }

            return firstSegment.Begin.X == secondSegment.Begin.X && firstSegment.Begin.Y == secondSegment.Begin.Y && firstSegment.End.X == secondSegment.End.X && firstSegment.End.Y == secondSegment.End.Y;
        }
    }
}
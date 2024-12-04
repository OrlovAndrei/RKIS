using System.Collections.Generic;
using Avalonia.Media;
using GeometryTasks;

namespace GeometryPainting
{
    public static class SegmentColorManager
    {
        private static readonly Dictionary<Segment, Color> _segmentToColor = new Dictionary<Segment, Color>();

        public static Color RetrieveColor(this Segment segment)
        {
            return _segmentToColor.TryGetValue(segment, out var color) ? color : Colors.Black;
        }

        public static void AssignColor(this Segment segment, Color color)
        {
            if (_segmentToColor.ContainsKey(segment))
            {
                _segmentToColor[segment] = color;
            }
            else
            {
                _segmentToColor.Add(segment, color);
            }
        }
    }
}

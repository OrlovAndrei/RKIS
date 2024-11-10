using System.Collections.Generic;
using Avalonia.Media;
using GeometryTasks;

namespace GeometryPainting;

public static class SegmentExtensions
{
    private static readonly Dictionary<Segment, Color> segmentColorMap = new Dictionary<Segment, Color>();

    public static Color GetColor(this Segment segment)
    {
        if (segmentColorMap.ContainsKey(segment)) return segmentColorMap[segment];
        else return Colors.Black;
    }

    public static void SetColor(this Segment segment, Color color)
    {
        if (segmentColorMap.ContainsKey(segment))
        {
            segmentColorMap[segment] = color;
        }
        else
        {
            segmentColorMap.Add(segment, color);
        }
    }
}
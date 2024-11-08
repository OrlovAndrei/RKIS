using System.Collections.Generic;
using Avalonia.Media;
using GeometryTasks;



namespace GeometryPainting;
public static class SegmentExtensions
{

    private static readonly Dictionary<Segment, Color> SegmentColors = new Dictionary<Segment, Color>();

    public static void SetColor(this Segment segment, Color color) => SegmentColors[segment] = color;

    public static Color GetColor(this Segment segment)
    {

        if (SegmentColors.TryGetValue(segment, out var color))
        {

            return color;
        }

        return Color.Black;
    }

}

using System.Collections.Generic;
using Avalonia.Media;
using GeometryTasks;

namespace GeometryPainting;

public class Data
    {
        public Color Col;
    }
    public static class SegmentExtensions
    {
        public static ConditionalWeakTable<Segment, Data> Table = new ConditionalWeakTable<Segment, Data>();
        public static void SetColor(this Segment segment, Color color)
        {
            Table.Add(segment, new Data { Col = color });
        }
        public static Color GetColor(this Segment segment)
        {
            Data color;
            if (Table.TryGetValue(segment, out color))
                return color.Col;
            return Color.Black;
        }
    }
}

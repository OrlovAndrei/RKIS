using System.Collections.Generic;
using Avalonia.Media;
using GeometryTasks;

namespace GeometryPainting;
{
    public class Segment
    {
        private Color _color;

        public Segment(Color color)
        {
            _color = color;
        }

        public Color GetColor()
        {
            return _color;
        }

        public void SetColor(Color color)
        {
            _color = color;
        }
    }
}

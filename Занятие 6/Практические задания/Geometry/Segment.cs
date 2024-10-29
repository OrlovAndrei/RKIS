using System;
using System.Drawing;

namespace GeometryTasks
{
    public class Segment
    {
        public Vector Begin { get; set; }
        public Vector End { get; set; }
        private Color? _color;
        public Segment(Vector begin, Vector end)
        {
            Begin = begin;
            End = end;
            _color = null;
        }
        public Color GetColor()
        {
            return _color ?? Color.Black;
        }
        public void SetColor(Color color)
        {
            _color = color;
        }
        public double Length()
        {
            return Math.Sqrt(Math.Pow(End.X - Begin.X, 2) + Math.Pow(End.Y - Begin.Y, 2));
        }
        public Vector Midpoint()
        {
            return new Vector((Begin.X + End.X) / 2, (Begin.Y + End.Y) / 2);
        }
        public void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(GetColor()))
            {
                graphics.DrawLine(pen, (float)Begin.X, (float)Begin.Y, (float)End.X, (float)End.Y);
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is Segment other)
            {
                return Begin.Equals(other.Begin) && End.Equals(other.End);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Begin, End);
        }
    }
}
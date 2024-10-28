using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return (Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y)));
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            return (new Vector { X = vector1.X + vector2.X, Y = vector1.Y + vector2.Y });
        }
    }
}
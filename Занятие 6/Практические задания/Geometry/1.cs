using System;

namespace Geometry
{
	public class Vector
	{
		public double X { get; set; }
		public double Y { get; set; }

		public Vector(double x, double y)
		{
			X = x;
			Y = y;
		}
	}

	public static class Geometry
	{
		public static double GetLength(Vector vec)
		{
			if (vec == null) throw new ArgumentNullException(nameof(vec));
			return Math.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
		}

		public static Vector Add(Vector vec1, Vector vec2)
		{
			if (vec1 == null) throw new ArgumentNullException(nameof(vec1));
			if (vec2 == null) throw new ArgumentNullException(nameof(vec2));

			return new Vector(vec1.X + vec2.X, vec1.Y + vec2.Y);
		}
	}
}

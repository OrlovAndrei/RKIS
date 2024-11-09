using System;

namespace Geometry
{
	public class Vector
	{
		public double X;
		public double Y;
	}

	public static class Geometry
	{
		public static double GetLength(Vector vector)
		{
			return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
		}

		public static Vector Add(Vector v1, Vector v2)
		{
			return new Vector { X = v1.X + v2.X, Y = v1.Y + v2.Y };
		}
	}
}
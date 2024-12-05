using System;
using System.Drawing;
using System.Linq;

namespace RoutePlanning;

public static class PointExtensions
{
	public static double GetPathLength(this Point[] checkpoints, int[] order)
	{
		var prevPoint = checkpoints[order[0]];
		var len = 0.0;
		foreach (var checkpointIndex in order.Skip(1))
		{
			len += prevPoint.DistanceTo(checkpoints[checkpointIndex]);
			prevPoint = checkpoints[checkpointIndex];
		}

		return len;
	}


	public static double DistanceTo(this Point a, Point b)
	{
		var dx = a.X - b.X;
		var dy = a.Y - b.Y;
		return Math.Sqrt(dx * dx + dy * dy);
	}
}
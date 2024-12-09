using System.Drawing;

namespace RoutePlanning;

public static class PathFinderTask
{
	public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
	{
		var bestOrder = MakeTrivialPermutation(checkpoints.Length);
		return bestOrder;
	}

	private static int[] MakeTrivialPermutation(int size)
	{
		var bestOrder = new int[size];
		for (var i = 0; i < bestOrder.Length; i++)
			bestOrder[i] = i;
		return bestOrder;
	}
}
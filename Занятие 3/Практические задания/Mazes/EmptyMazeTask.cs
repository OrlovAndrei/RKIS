using Avalonia.FreeDesktop.DBusIme;

namespace Mazes;

public static class EmptyMazeTask
{
	public static void MoveOut(Robot robot, int width, int height)
	{
		MoveOne(robot, height);
		MoveTwo(robot, width);
	}
	public static void MoveOne(Robot robot, int coords)
	{
		while (robot.Y != (coords - 2))
			robot.MoveTo(Direction.Down);
	}
    public static void MoveTwo(Robot robot, int coords)
    {
        while (robot.X != (coords - 2))
			robot.MoveTo(Direction.Right);
    }
}
namespace Mazes;

public static class EmptyMazeTask
{
	public static void MoveOut(Robot robot, int width, int height)
	{
            GoX(robot, width);
            GoY(robot, height);
    }
    private static void GoX(Robot robot, int coords)
    {
        while (robot.X != (coords - 2))
            robot.MoveTo(Direction.Right);
    }
    private static void GoY(Robot robot, int coords)
    {
        while (robot.Y != (coords - 2))
            robot.MoveTo(Direction.Down);
    }
}
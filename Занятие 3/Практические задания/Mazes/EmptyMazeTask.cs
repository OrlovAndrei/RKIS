namespace Mazes;

public static class EmptyMazeTask
{
	public static void MoveOut(Robot robot, int width, int height)
	{
        MoveX(robot, width);
        MoveY(robot, height);
    }

    private static void MoveX(Robot robot, int coordinate)
    {
        while (robot.X != (coordinate - 2))
            robot.MoveTo(Direction.Right);
    }

    private static void MoveY(Robot robot, int coordinate)
    {
        while (robot.Y != (coordinate - 2))
            robot.MoveTo(Direction.Down);
    }
}

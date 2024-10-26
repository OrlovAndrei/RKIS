namespace Mazes;

public static class EmptyMazeTask
{
{
public static void MoveOut(Robot robot, int width, int height)
	{
        for (int i = 0; robot.Finished != true; i++)
        {
            RobotMoveRight(robot, width, height, i);
            RobotMoveDown(robot, width, height, i);
        }
    }
    public static void RobotMoveRight(Robot robot, int width, int height, int i)
    {
        if (i < width - 3) robot.MoveTo(Direction.Right);
    }
    public static void RobotMoveDown(Robot robot, int width, int height, int i)
    {
        if (i < height - 3) robot.MoveTo(Direction.Down);
    }
}
	
}

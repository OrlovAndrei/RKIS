namespace Mazes;

public static class EmptyMazeTask
{
	public static void MoveOut(Robot robot, int width, int height)
	{
        for (int i = width - 3; i < width - 1; i++)
        {
            for (int j = 0; j < height - 1; j++)
            {
                if ((i % 2 == 0 && j % 2 == 0) || (i % 2 == 1 && j % 2 == 1))
                {
                    robot.MoveTo(Direction.Right);
                }
                else
                {
                    robot.MoveTo(Direction.Down);
                }
            }
        }

        for (int j = height - 3; j < height - 1; j++)
            robot.MoveTo(Direction.Down);
        }
    }
}
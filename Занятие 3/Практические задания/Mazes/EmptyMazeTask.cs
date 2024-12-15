namespace Mazes

public static class EmptyMazeTask
{
	public static class EmptyMazeTask
	{
						public static void MoveOut(Robot robot, int width, int height)
        {
            Move(robot, width - 3, Direction.Right);
            Move(robot, height - 3, Direction.Down);

        }

        private static void Move(Robot robot, int stepCount, Direction direction)
        {
            for (int y = 0; y < stepCount; y++)
            {
                robot.MoveTo(direction);
            }
        }
    }
		
	}
}

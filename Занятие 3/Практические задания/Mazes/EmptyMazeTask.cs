namespace Mazes

public static class EmptyMazeTask
{
	public static class EmptyMazeTask
	{
<<<<<<< HEAD
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
=======
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
>>>>>>> 52d5f4957f1733d3e520c1b8ee447bdfec5cd061
}
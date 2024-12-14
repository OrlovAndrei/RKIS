using System;
namespace Mazes

public static class SnakeMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
<<<<<<< HEAD
        while (!robot.Finished)
        {
            MoveRight(robot, width, height);
            MoveDown(robot, width, height);
            MoveLeft(robot, width, height);

            if (!robot.Finished) MoveDown(robot, width, height);
        }
    }

    public static void MoveRight(Robot robot, int width, int height)
    {
        while (robot.X != width - 2)
        {
            robot.MoveTo(Direction.Right);
        }
    }

    public static void MoveDown(Robot robot, int width, int height)
    {
        for (int i = 0; i < 2; i++)
        {
            robot.MoveTo(Direction.Down);
        }
    }

    public static void MoveLeft(Robot robot, int width, int height)
    {
        while (robot.X != 1)
        {
            robot.MoveTo(Direction.Left);
=======
        int count = height - 2;
        while (count != 0)
        {
            count -= 2;
            Move(robot, width - 3, Direction.Right);
            Move(robot, 2, Direction.Down);
            Move(robot, width - 3, Direction.Left);
            if (count != 0) Move(robot, 2, Direction.Down);
                        }
        }
        private static void Move(Robot robot, int stepCount, Direction direction)
        {
            for (int y = 0; y < stepCount; y++)
            {
                robot.MoveTo(direction);
            }
>>>>>>> 52d5f4957f1733d3e520c1b8ee447bdfec5cd061
        }
    }
}   
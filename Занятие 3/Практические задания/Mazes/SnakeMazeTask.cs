using System;
namespace Mazes

public static class SnakeMazeTask
{
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
        }
    public static void MoveOut(Robot robot, int width, int height)
    {

    }
}

}

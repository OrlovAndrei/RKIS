using System;
namespace Mazes
{

    public static class SnakeMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            while (true)
            {
                Move(robot, width - 3, Direction.Right);
                Move(robot, 2, Direction.Down);
                Move(robot, width - 3, Direction.Left);
                if (robot.Finished) break;
                Move(robot, 2, Direction.Down);
            }

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

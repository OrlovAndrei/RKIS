namespace Mazes
{
    public static class DiagonalMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            if (width > height) MoveRightDown(robot, width, height);
            else MoveDownRight(robot, width, height);
        }
        public static void RobotMoveHorizontal(Robot robot, int width, Direction dir)
        {
            for (int i = 0; i < width; ++i)
                robot.MoveTo(dir);
        }
        public static void RobotMoveVertical(Robot robot, int height, Direction dir)
        {
            for (int i = 0; i < height; ++i)
                robot.MoveTo(dir);
        }
        public static void MoveRightDown(Robot robot, int width, int height)
        {
            for (int i = 0; i < height - 2; ++i)
            {
                RobotMoveVertical(robot, width / (height - 1), Direction.Right);
                if (i != (height - 3)) RobotMoveHorizontal(robot, 1, Direction.Down);
            }
        }
        public static void MoveDownRight(Robot robot, int width, int height)
        {
            for (int i = 0; i < width - 2; ++i)
            {
                RobotMoveVertical(robot, (height - 3) / (width - 2), Direction.Down);
                if (i != (width - 3)) RobotMoveHorizontal(robot, 1, Direction.Right);
            }
        }
    }
}

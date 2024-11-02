namespace Mazes
{
    public static class SnakeMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            var len = DefineHeight(height);
            for (int i = 0; i < len;)
            {
                RobotMakeCurve(robot, width);
                if (++i != len)
                {
                    robot.MoveTo(Direction.Down);
                    robot.MoveTo(Direction.Down);
                }
            }
        }
        public static void RobotMoveHorizontal(Robot robot, int width, Direction dir)
        {
            for (int i = 0; i < width - 3; ++i)
                robot.MoveTo(dir);
        }
        public static void RobotMakeCurve(Robot robot, int width)
        {
            RobotMoveHorizontal(robot, width, Direction.Right);
            robot.MoveTo(Direction.Down);
            robot.MoveTo(Direction.Down);
            RobotMoveHorizontal(robot, width, Direction.Left);
        }
        public static int DefineHeight(int height)
        {
            if (height > 5) height /= 4;
            else height = 1;
            return height;
        }
    }
}

namespace Mazes
{
    public static class SnakeMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            var horizontal = width - 3;
            var vertical = 2;
            while (!robot.Finished)
            {
                if (!robot.Finished)
                {
                    for (var robotStep = 0; robotStep < horizontal; robotStep++)
                    {
                        robot.MoveTo(Direction.Right);
                    }
                    for (var robotStep = 0; robotStep < vertical; robotStep++)
                    {
                        robot.MoveTo(Direction.Down);
                    }
                    for (var robotStep = 0; robotStep < horizontal; robotStep++)
                    {
                        robot.MoveTo(Direction.Left);
                    }
                    if (!robot.Finished)
                    {
                        for (var i = 0; i < vertical; i++)
                        {
                            robot.MoveTo(Direction.Down);
                        }
                    }
                }
            }
        }
    }
}

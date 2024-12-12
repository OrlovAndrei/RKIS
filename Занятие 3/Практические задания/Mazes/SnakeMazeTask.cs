namespace Mazes;

public static class SnakeMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            int schet = 0;
            while (!robot.Finished && schet < 1000)
            {
                try
                {
                    schet++; robot.MoveTo(Direction.Down);
                }
                catch { }
                try
                {
                    schet++; robot.MoveTo(Direction.Right);
                }
                catch { }
            }
    }
}

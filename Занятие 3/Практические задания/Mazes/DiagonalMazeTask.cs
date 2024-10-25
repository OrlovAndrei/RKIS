namespace Mazes;

public static class DiagonalMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        if (!robot.Finished)
                for (var robotStep = 0; robotStep < attitudeParties; robotStep++)
                {
                    robot.MoveTo(direction);
                }
            if (!robot.Finished)
                robot.MoveTo(direction1);
    }
 
        public static void MoveOut(Robot robot, int width, int height)
        {
            while (!robot.Finished) 
            {
                if (width > height) 
                {
                    var attitudeParties = (width - 2) / (height - 2);
                    Move(robot, attitudeParties, Direction.Right, Direction.Down);
                }
                else
                {
                    var attitudeParties = (height - 2) / (width - 2);
                    Move(robot, attitudeParties, Direction.Down, Direction.Right);
                }
        }
    }
}

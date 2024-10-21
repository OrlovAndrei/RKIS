namespace Mazes
{
    public static class DiagonalMazeTask
    {
        public static void Move(Robot robot, int attitudeParties, Direction direction, Direction direction1)
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
            while (!robot.Finished) //Этот цикл стоит вынести во вспомогательный метод и там делать нужные шаги. А метод движения в любом направлении на любое число шагов взять из первой задачи
            {
                if (width > height) //Зачем данное условие многократно проверять в цикле, если значения не меняются
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
}

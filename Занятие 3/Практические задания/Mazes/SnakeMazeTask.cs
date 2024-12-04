namespace Mazes;

public static class SnakeMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        int X = width - 3;
        int Y = 2;

        while (robot.Finished == false)  //пока не достиг финиша
        {
            if (robot.Finished == false)  //если не достиг финиша, то в циклах проверяем до каких пор движется
            {
                for (int i = 0; i < X; i++)  // -->
                { robot.MoveTo(Direction.Right); }
                for (int i = 0; i < Y; i++)         //|
                { robot.MoveTo(Direction.Down); }  // v
                for (int i = 0; i < X; i++)
                { robot.MoveTo(Direction.Left); }  // -->
            }
            if (robot.Finished == false)
            {
                for (int i = 0; i < Y; i++)
                { robot.MoveTo(Direction.Down); } // какой-то робот дурачок не выходит из лабиринта до конца
            }
        }
    }
}
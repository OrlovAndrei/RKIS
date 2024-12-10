namespace H
{
    internal class Program
    {
        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }
        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }
        public static void Main()
        {
            Run("XXX OO. ...");
            Run("OXO XO. .XO");
            Run("OXO XOX OX.");
            Run("XOX OXO OXO");
            Run("... ... ...");
            Run("XXX OOO ...");
            Run("XOO XOO XX.");
            Run(".O. XO. XOX");
        }

        public static GameResult GetGameResult(Mark[,] field)
        {
            bool crossWin = CheckWinner(field, Mark.Cross);
            bool circleWin = CheckWinner(field, Mark.Circle);

            if (crossWin && circleWin)
            {
                return GameResult.Draw;  
            }
            else if (crossWin)
            {
                return GameResult.CrossWin;
            }
            else if (circleWin)
            {
                return GameResult.CircleWin;
            }
            else
            {
                return GameResult.Draw;
            }
        }

        private static bool CheckWinner(Mark[,] field, Mark marker)
        {
            for (int i = 0; i < 3; i++)
            {
                if (field[i, 0] == marker && field[i, 1] == marker && field[i, 2] == marker)
                {
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (field[0, i] == marker && field[1, i] == marker && field[2, i] == marker)
                {
                    return true;
                }
            }

            if ((field[0, 0] == marker && field[1, 1] == marker && field[2, 2] == marker) ||
                (field[0, 2] == marker && field[1, 1] == marker && field[2, 0] == marker))
            {
                return true;
            }

            return false;
        }

        private static void Run(string description)

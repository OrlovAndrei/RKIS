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
            bool crossWins = CheckWinner(field, Mark.Cross);
            bool circleWins = CheckWinner(field, Mark.Circle);

            if (crossWins && circleWins)
                return GameResult.Draw;

            if (crossWins)
                return GameResult.CrossWin;

            if (circleWins)
                return GameResult.CircleWin;

            return GameResult.Draw;
        }

        private static bool CheckWinner(Mark[,] field, Mark mark)
        {
            for (int row = 0; row < 3; row++)
                if (field[row, 0] == mark && field[row, 1] == mark && field[row, 2] == mark)
                    return true;

            for (int col = 0; col < 3; col++)
                if (field[0, col] == mark && field[1, col] == mark && field[2, col] == mark)
                    return true;

            if (field[0, 0] == mark && field[1, 1] == mark && field[2, 2] == mark)
                return true;

            if (field[0, 2] == mark && field[1, 1] == mark && field[2, 0] == mark)
                return true;

            return false;
        }

        private static void Run(string description)
        {
            Console.WriteLine(description.Replace(" ", Environment.NewLine));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
        }

        private static Mark[,] CreateFromString(string str)
        {
            var field = str.Split(' ');
            var ans = new Mark[3, 3];
            for (int x = 0; x < field.Length; x++)
                for (var y = 0; y < field[x].Length; y++)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }
    }
}

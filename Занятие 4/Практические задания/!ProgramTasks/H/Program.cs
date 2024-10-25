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
            bool crossWin = IsThreeInARow(field, Mark.Cross), circleWin = IsThreeInARow(field, Mark.Circle);
            return crossWin == circleWin ? GameResult.Draw : crossWin ? GameResult.CrossWin : GameResult.CircleWin;
        }
        public static bool IsThreeInARow(Mark[,] field, Mark mark)
        {
            if (field[0, 0] == mark && field[0, 0] == field[1, 1] && field[0, 0] == field[2, 2]) return true;
            if (field[2, 0] == mark && field[2, 0] == field[1, 1] && field[2, 0] == field[0, 2]) return true;
            for (int i = 0; i < 3; i++)
            {
                if (field[i, 0] == mark && field[i, 0] == field[i, 1] && field[i, 0] == field[i, 2]) return true;
                if (field[0, i] == mark && field[0, i] == field[1, i] && field[0, i] == field[2, i]) return true;
            }
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
                for (var y = 0; y < field.Length; y++)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }
    }
}
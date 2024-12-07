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
            if (HasWinSequence(field, Mark.Circle) == HasWinSequence(field, Mark.Cross)) return GameResult.Draw;
            if (HasWinSequence(field, Mark.Circle)) return GameResult.CircleWin;
            if (HasWinSequence(field, Mark.Cross)) return GameResult.CrossWin;
            else return GameResult.Draw;
        }

        static bool HasWinSequence(Mark[,] field, Mark mark)
        {
            if (((field[2, 0] & field[1, 1] & field[0, 2]) | (field[2, 2] & field[1, 1] & field[0, 0])) == mark)
                return true;
            for (int x = 0; x < 3; x++)
            {
                if ((field[x, 0] & field[x, 1] & field[x, 2]) == mark) return true;
                if ((field[0, x] & field[1, x] & field[2, x]) == mark) return true;
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
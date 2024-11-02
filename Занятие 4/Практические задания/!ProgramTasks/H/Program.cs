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
            for (int i = 0; i < 3; i++)
            {
                if (field[i, 0] == field[i, 1] && field[i, 1] == field[i, 2]) {
                    if (field[i, 0] == Mark.Cross) return GameResult.CrossWin;
                    if (field[i, 0] == Mark.Circle) return GameResult.CircleWin;
                }

                if (field[0, i] == field[1, i] && field[1, i] == field[2, i]) {
                    if (field[0, i] == Mark.Cross) return GameResult.CrossWin;
                    if (field[0, i] == Mark.Circle) return GameResult.CircleWin;
                }
            }

            if (field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2]) {
                if (field[0, 0] == Mark.Cross) return GameResult.CrossWin;
                if (field[0, 0] == Mark.Circle) return GameResult.CircleWin;
            }

            if (field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0]) {
                if (field[0, 2] == Mark.Cross) return GameResult.CrossWin;
                if (field[0, 2] == Mark.Circle) return GameResult.CircleWin;
            }

            foreach (var mark in field) {
                if (mark == Mark.Empty) return GameResult.Draw;
            }

            return GameResult.Draw;
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

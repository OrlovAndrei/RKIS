namespace B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestMove("a1", "d4");
            TestMove("f4", "e7");
            TestMove("a1", "a4");
            TestMove("a1", "a1");
            TestMove("a1", "b2");
            TestMove("a1", "h8");
            TestMove("e1", "h8");
            TestMove("g1", "a7");
            TestMove("b1", "a3");
            TestMove("f1", "a4");
        }

        public static void TestMove(string from, string to) 
        {
            Console.WriteLine("{0}-{1} => {2}", from, to, IsCorrectMove(from, to)); 
        }                            
    

        public static bool IsCorrectMove(string from, string to)
        {
            var dx = Math.Abs(to[0] - from[0]);
            var dy = Math.Abs(to[1] - from[1]); 
            return ((dx == 0) || (dy == 0)) ^ (dx == dy); 
    }
}
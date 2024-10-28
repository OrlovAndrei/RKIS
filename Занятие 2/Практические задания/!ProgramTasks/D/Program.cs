using static System.Net.Mime.MediaTypeNames;

namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test(true, "boss", 150);
            Test(true, "boss", 30);
            Test(true, "boss", 70);
            Test(false, "boss", 14);
            Test(true, "bot", 90);
            Test(false, "bot", 100000);
        }

        public static void Test(bool enemyInFront, string enemyName, int robotHealth)
        {
            return enemyInFront && (...);
            return enemyInFront && (enemyName != "boss" || robotHealth >= 50);
        }
    }
}

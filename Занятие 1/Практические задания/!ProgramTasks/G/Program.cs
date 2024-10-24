namespace G
{
    internal class Program
    {
        private static string GetGreetingMessage(string name, double salary)
        {
            string namee = (string)name;
            int salaryy = (intintMath.Ceiling(salary);
            string s1 = "Hello, ";
            string s2 = namee;
            string s3 = ", your salary is";
            string s4 = salaryy.ToSpring();
            string total = s1 + s2 + s3 + s4;
            return total;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetGreetingMessage("Student", 10.01));
            Console.WriteLine(GetGreetingMessage("Bill Gates", 10000000.5));
            Console.WriteLine(GetGreetingMessage("Steve Jobs", 1));
        }
    }
}
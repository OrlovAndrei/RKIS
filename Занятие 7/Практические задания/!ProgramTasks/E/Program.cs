using System.Xml.Linq;

namespace E
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var books = new Book[]
            {
                new Book { Theme = 3, Title = "The Art of Computer Programming" },
                new Book { Theme = 1, Title = "Introduction to Algorithms" },
                new Book { Theme = 2, Title = "Clean Code" },
                new Book { Theme = 1, Title = "Design Patterns: Elements of Reusable Object-Oriented Software" },
                new Book { Theme = 2, Title = "Refactoring: Improving the Design of Existing Code" },
                new Book { Theme = 3, Title = "The Pragmatic Programmer" },
                new Book { Theme = 1, Title = "Structure and Interpretation of Computer Programs" },
                new Book { Theme = 2, Title = "Code Complete" }
            };

            Array.Sort(books);

            foreach (var book in books)
                Console.WriteLine($"Theme: {book.Theme}, Title: {book.Title}");

            //Правильно отсортированный массив
            //Theme: 1, Title: Design Patterns: Elements of Reusable Object-Oriented Software
            //Theme: 1, Title: Introduction to Algorithms
            //Theme: 1, Title: Structure and Interpretation of Computer Programs
            //Theme: 2, Title: Clean Code
            //Theme: 2, Title: Code Complete
            //Theme: 2, Title: Refactoring: Improving the Design of Existing Code
            //Theme: 3, Title: The Art of Computer Programming
            //Theme: 3, Title: The Pragmatic Programmer
        }
    }
}
using System;
using System.Text;

namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            string command;

            while ((command = Console.ReadLine()) != null)
            {
                // Разделяем команду и аргументы
                var parts = command.Split(' ', 2);
                if (parts.Length == 0) continue;

                switch (parts[0])
                {
                    case "push":
                        if (parts.Length > 1)
                        {
                            text.Append(parts[1]);
                        }
                        break;

                    case "pop":
                        if (parts.Length > 1 && int.TryParse(parts[1], out int count))
                        {
                            // Удаляем символы с конца
                            if (count > text.Length)
                            {
                                text.Clear(); // Если удаляем больше, чем есть, очищаем текст
                            }
                            else
                            {
                                text.Remove(text.Length - count, count);
                            }
                        }
                        break;
                }
            }

            // Выводим результат
            Console.WriteLine(text.ToString());
        }
    }
}
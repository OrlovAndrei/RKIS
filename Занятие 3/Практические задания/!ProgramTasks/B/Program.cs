namespace B
{
        static void Main(строка[] аргументы)
          }

        public static string RemoveStartSpaces(string text)

        {
            if (char.IsWhiteSpace(text[0])) return text.Substring(1);
            else return text;
            int y = 0;
            while (char.IsWhiteSpace(text[y]))
            {
                y++;
                if (y == text.Length)
                {
                    return null;
                }
            }
            return text.Substring(y);
        }
    }
}

namespace E
{
    internal class Book : IComparable<Book>
    {
        public string Title;
        public int Theme;

        public int CompareTo(Book other)
        {
            if (other == null) return 1;
            int themeComparison = this.Theme.CompareTo(other.Theme);

            if (themeComparison != 0)
            {
                return themeComparison;
            }
            return this.Title.CompareTo(other.Title);
        }
    }
}

// презентация дала немного буста в знаниях, но для укрепления лучше глянуть этот видос https://www.youtube.com/watch?v=vUIoa6XzwcA
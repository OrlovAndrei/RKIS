namespace Passwords
{
    public static class ComparisonExtensions
    {
        public static string FormatIfEmpty(this string s)
        {
            if (!string.IsNullOrWhiteSpace(s) && s.Trim() == s) return s;
            if (s == null) return "<null>";
            if (s == "") return "<empty string>";
            return "[" + s + "]";
        }
    }
}
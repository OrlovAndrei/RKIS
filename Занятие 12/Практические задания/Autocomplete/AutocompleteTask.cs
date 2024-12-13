internal class AutocompleteTask
{
    
    public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
    {
        var leftIndex = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;

        if (leftIndex >= phrases.Count || !phrases[leftIndex].StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
        {
            return Array.Empty<string>();
        }

        var result = new List<string>();
        var currentIndex = leftIndex;

        while (currentIndex < phrases.Count && result.Count < count && phrases[currentIndex].StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
        {
            result.Add(phrases[currentIndex]);
            currentIndex++;
        }

        return result.ToArray();
    }

   
    public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
    {
        var leftIndex = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
        var rightIndex = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count);

        if (leftIndex >= phrases.Count || !phrases[leftIndex].StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
        {
            return 0;
        }

        return rightIndex - leftIndex;
    }
}

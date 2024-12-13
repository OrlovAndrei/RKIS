using System;
using System.Collections.Generic;

namespace Autocomplete
{
    public class LeftBorderTask
    {
        public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                bool isPrefixMatch = phrases[mid].StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase);

                if (!isPrefixMatch && string.Compare(prefix, phrases[mid], StringComparison.InvariantCultureIgnoreCase) > 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left == phrases.Count ? -1 : left - 1;
        }
    }
}
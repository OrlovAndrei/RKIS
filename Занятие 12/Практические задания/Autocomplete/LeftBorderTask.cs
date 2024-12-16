﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Autocomplete
{
    public class LeftBorderTask
    {
        public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix,
                                             int left, int right)
        {
            left = Math.Max(left, -1);
            right = Math.Min(right, phrases.Count - 1);
            if (right <= left) return left;
            var middle = left + (right - left + 1) / 2;
            if (string.Compare(phrases[middle], prefix, StringComparison.OrdinalIgnoreCase) < 0)
            {
                return GetLeftBorderIndex(phrases, prefix, middle, right);
            }
            else
            {
                return GetLeftBorderIndex(phrases, prefix, left, middle - 1);
            }
        }
    }
}
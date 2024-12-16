﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class RightBorderTask
    {
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases,
                                              string prefix, int left, int right)
        {
            left = Math.Max(left, 0);
            right = Math.Min(right, phrases.Count);

            while (left < right)
            {
                var middle = left + (right - left) / 2;
                if (0 <= string.Compare(phrases[middle], prefix,
                                        StringComparison.OrdinalIgnoreCase) &&
                    !phrases[middle].StartsWith(prefix,
                                                StringComparison.OrdinalIgnoreCase))
                {
                    right = middle;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return right;
        }
    }
}
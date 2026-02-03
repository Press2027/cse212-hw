using System.Collections.Generic;
using System.Linq;

// DO NOT MODIFY THIS FILE
public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable<int> array)
    {
        return "<IEnumerable>{" + string.Join(", ", array) + "}";
    }
}

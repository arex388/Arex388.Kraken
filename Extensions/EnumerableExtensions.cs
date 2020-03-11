using System.Linq;

namespace System.Collections.Generic {
    internal static class EnumerableExtensions {
        public static bool HasItems<T>(
            this IEnumerable<T> enumerable) => enumerable != null
                                               && enumerable.Any();
    }
}
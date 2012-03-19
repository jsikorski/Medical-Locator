using System.Collections.Generic;
using System.Linq;

namespace Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static string ToUrlFormat(this IEnumerable<string> enumerable)
        {
            var list = enumerable.ToList();

            if (list.Count == 0)
            {
                return string.Empty;
            }

            if (list.Count == 1)
            {
                return list.First().ToLowerInvariant();
            }

            return list.Aggregate(
                (current, next) => current.ToLowerInvariant() + "|" + next.ToLowerInvariant());
        }
    }
}
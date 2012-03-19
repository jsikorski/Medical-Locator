using System.Collections.Generic;
using System.Linq;
using GoogleMapsInterfaceService.GooglePlacesApi;

namespace GoogleMapsInterfaceService.Extensions
{
    public static class IEnumerableExtensions
    {
        public static string ToUrlFormat(this IEnumerable<string> enumerable)
        {
            if (!enumerable.Any())
            {
                return string.Empty;
            }

            if (enumerable.Count() == 1)
            {
                return enumerable.First().ToLowerInvariant();
            }

            return enumerable.Aggregate(
                (current, next) => current.ToLowerInvariant() + "|" + next.ToLowerInvariant());
        }
    }
}
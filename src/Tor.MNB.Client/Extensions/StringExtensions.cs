using System.Globalization;
using System.Text;

namespace Tor.MNB.Client.Extensions
{
    internal static class StringExtensions
    {
        internal static string RemoveAllWhiteSpaces(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            var chars = value
                .Where(x => !char.IsWhiteSpace(x))
                .ToList();

            var builder = new StringBuilder(chars.Count);

            chars.ForEach(x => builder.Append(x));

            return value.Length == builder.Length ? value : builder.ToString();
        }

        internal static decimal ToDecimal(this string value)
        {
            return decimal.TryParse(value.RemoveAllWhiteSpaces().Replace(",", "."), CultureInfo.InvariantCulture, out var result)
                ? result
                : 0;
        }
    }
}

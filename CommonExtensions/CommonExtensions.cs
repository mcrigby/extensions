using System.Linq;
using System.Text.RegularExpressions;

namespace System
{
    public static class CommonExtensions
    {
        public static string ToTitleCase(this string source)
        {
            var parts = source.Split(' ')
                .Select(part =>
                {
                    if (string.IsNullOrWhiteSpace(part))
                        return part;
                    if (part.Length == 1)
                        return part.ToUpper();

                    return part.Substring(0, 1).ToUpper() + part.Substring(1).ToLower();
                });

            return string.Join(" ", parts);
        }

        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}

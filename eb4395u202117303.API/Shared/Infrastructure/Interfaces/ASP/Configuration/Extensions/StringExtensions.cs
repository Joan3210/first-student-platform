using System.Text.RegularExpressions;

namespace eb4395u202117303.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/// <summary>
///     Provides extension methods for string manipulation.
/// </summary>
public static partial class StringExtensions
{
    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();

    /// <summary>
    ///     Converts the string to kebab-case.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The string in kebab-case.</returns>
    public static string ToKebabCase(this string text)
    {
        return string.IsNullOrEmpty(text)
            ? text
            : KebabCaseRegex().Replace(text, "-$1").Trim().ToLower();
    }
}
using System.Text.RegularExpressions;

namespace Application.Shared.RegexPatterns;

public static partial class Regexes
{
    [GeneratedRegex(@"^\d+$")]
    public static partial Regex DigitsOnly();
    
    [GeneratedRegex(@"^[A-Za-z0-9\s\-]{3,10}$")]
    public static partial Regex ZipCode();
}
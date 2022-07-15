using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct MonthParser : IAttributeParser<DateOnly>
{
    public bool IsValid(DateOnly input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out DateOnly output)
    {
        return DateOnly.TryParseExact(input + "-01", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out output);
    }

    public bool TryToString(DateOnly input, [MaybeNullWhen(false)] out string output)
    {
        output = input.ToString("yyyy-MM", CultureInfo.InvariantCulture);
        return true;
    }
}

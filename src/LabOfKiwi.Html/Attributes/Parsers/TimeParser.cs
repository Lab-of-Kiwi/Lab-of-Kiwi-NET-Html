using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct TimeParser : IAttributeParser<TimeOnly>
{
    public bool IsValid(TimeOnly input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out TimeOnly output)
    {
        return TimeOnly.TryParseExact(input, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out output);
    }

    public bool TryToString(TimeOnly input, [MaybeNullWhen(false)] out string output)
    {
        output = input.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
        return true;
    }
}

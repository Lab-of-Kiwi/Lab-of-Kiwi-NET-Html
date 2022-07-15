using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct DateTimeParser : IAttributeParser<DateTime>
{
    public bool IsValid(DateTime input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out DateTime output)
    {
        return DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out output);
    }

    public bool TryToString(DateTime input, [MaybeNullWhen(false)] out string output)
    {
        output = input.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        return true;
    }
}

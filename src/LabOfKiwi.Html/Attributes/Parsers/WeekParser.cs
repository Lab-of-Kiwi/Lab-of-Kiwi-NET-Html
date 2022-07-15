using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct WeekParser : IAttributeParser<DateOnly>
{
    public bool IsValid(DateOnly input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out DateOnly output)
    {
        if (input.Length == 8 && input[4] == '-' && input[5] == 'W')
        {
            if (int.TryParse(input[0..4], out int year) && int.TryParse(input[6..], out int week))
            {
                try
                {
                    var dateTime = ISOWeek.ToDateTime(year, week, DayOfWeek.Monday);
                    output = DateOnly.FromDateTime(dateTime);
                    return true;
                }
                catch { }
            }
        }

        output = default;
        return false;
    }

    public bool TryToString(DateOnly input, [MaybeNullWhen(false)] out string output)
    {
        int year = input.Year;
        int weekOfYear = ISOWeek.GetWeekOfYear(input.ToDateTime(TimeOnly.MinValue));
        output = $"{year.ToString().PadLeft(4, '0')}-W{weekOfYear.ToString().PadLeft(2, '0')}";
        return true;
    }
}

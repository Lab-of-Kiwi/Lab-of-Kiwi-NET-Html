using System;
using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct EnumParser<T> : IAttributeParser<T> where T : struct, Enum
{
    public bool IsValid(T input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out T output)
    {
        return Enum.TryParse(input, true, out output);
    }

    public bool TryToString(T input, [MaybeNullWhen(false)] out string output)
    {
        string? enumValue = Enum.GetName<T>(input);

        if (enumValue != null)
        {
            output = enumValue.ToLowerInvariant();
            return true;
        }

        output = default;
        return false;
    }
}

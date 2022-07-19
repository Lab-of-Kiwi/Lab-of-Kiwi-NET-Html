using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal readonly struct LongParser : IAttributeParser<long>
{
    public bool IsValid(long input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out long output)
    {
        return long.TryParse(input, out output);
    }

    public bool TryToString(long input, [MaybeNullWhen(false)] out string output)
    {
        output = input.ToString();
        return true;
    }

    internal readonly struct NonNegative : IAttributeParser<long, LongParser>
    {
        public bool IsValid(long input)
        {
            return input >= 0;
        }
    }

    internal readonly struct Positive : IAttributeParser<long, LongParser>
    {
        public bool IsValid(long input)
        {
            return input > 0;
        }
    }
}

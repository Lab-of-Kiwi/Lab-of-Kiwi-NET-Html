using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct StringParser : IAttributeParser<string>
{
    public bool IsValid(string input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out string output)
    {
        output = input;
        return true;
    }

    public bool TryToString(string input, [MaybeNullWhen(false)] out string output)
    {
        output = input;
        return true;
    }
}

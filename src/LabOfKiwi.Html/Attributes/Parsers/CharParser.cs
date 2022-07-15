using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct CharParser : IAttributeParser<char>
{
    public bool IsValid(char input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out char output)
    {
        if (input.Length == 1)
        {
            output = input[0];
            return true;
        }

        output = default;
        return false;
    }

    public bool TryToString(char input, [MaybeNullWhen(false)] out string output)
    {
        output = input.ToString();
        return true;
    }
}

using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal readonly struct OnOffParser : IAttributeParser<bool>
{
    private const string True = "on";
    private const string False = "off";

    public bool IsValid(bool input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out bool output)
    {
        if (True.Equals(input))
        {
            output = true;
            return true;
        }

        if (False.Equals(input))
        {
            output = false;
            return true;
        }

        output = default;
        return false;
    }

    public bool TryToString(bool input, [MaybeNullWhen(false)] out string output)
    {
        output = input ? True : False;
        return true;
    }
}

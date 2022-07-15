using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct ULMarkerTypeParser : IAttributeParser<UnorderedListMarkerType>
{
    public bool IsValid(UnorderedListMarkerType input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out UnorderedListMarkerType output)
    {
        switch (input)
        {
            case "1":
                output = UnorderedListMarkerType.Decimal;
                return true;
            case "a":
                output = UnorderedListMarkerType.LowercaseAlphabet;
                return true;
            case "A":
                output = UnorderedListMarkerType.UppercaseAlphabet;
                return true;
            case "i":
                output = UnorderedListMarkerType.LowercaseRomanNumeral;
                return true;
            case "I":
                output = UnorderedListMarkerType.UppercaseRomanNumeral;
                return true;
        }

        output = default;
        return false;
    }

    public bool TryToString(UnorderedListMarkerType input, [MaybeNullWhen(false)] out string output)
    {
        switch (input)
        {
            case UnorderedListMarkerType.Decimal:
                output = "1";
                return true;
            case UnorderedListMarkerType.LowercaseAlphabet:
                output = "a";
                return true;
            case UnorderedListMarkerType.UppercaseAlphabet:
                output = "A";
                return true;
            case UnorderedListMarkerType.LowercaseRomanNumeral:
                output = "i";
                return true;
            case UnorderedListMarkerType.UppercaseRomanNumeral:
                output = "I";
                return true;
        }

        output = default;
        return false;
    }
}

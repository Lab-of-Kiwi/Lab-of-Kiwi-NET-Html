using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal readonly struct TextDirectionParser : IAttributeParser<TextDirection>
{
    public bool IsValid(TextDirection input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out TextDirection output)
    {
        switch (input)
        {
            case "ltr":
                output = TextDirection.LeftToRight;
                return true;
            case "rtl":
                output = TextDirection.RightToLeft;
                return true;
            case "auto":
                output = TextDirection.Auto;
                return true;
        }

        output = default;
        return false;
    }

    public bool TryToString(TextDirection input, [MaybeNullWhen(false)] out string output)
    {
        switch (input)
        {
            case TextDirection.LeftToRight:
                output = "ltr";
                return true;
            case TextDirection.RightToLeft:
                output = "rtl";
                return true;
            case TextDirection.Auto:
                output = "auto";
                return true;
        }

        output = default;
        return false;
    }

    internal readonly struct BDO : IAttributeParser<TextDirection, TextDirectionParser>
    {
        public bool IsValid(TextDirection input)
        {
            return input != TextDirection.Auto;
        }
    }
}

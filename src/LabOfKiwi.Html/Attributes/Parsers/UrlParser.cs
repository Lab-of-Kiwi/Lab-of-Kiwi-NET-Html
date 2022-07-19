using System;
using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal readonly struct UrlParser : IAttributeParser<Uri>
{
    public bool IsValid(Uri input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out Uri output)
    {
        return Uri.TryCreate(input, UriKind.RelativeOrAbsolute, out output);
    }

    public bool TryToString(Uri input, [MaybeNullWhen(false)] out string output)
    {
        output = input.ToString();
        return true;
    }
}

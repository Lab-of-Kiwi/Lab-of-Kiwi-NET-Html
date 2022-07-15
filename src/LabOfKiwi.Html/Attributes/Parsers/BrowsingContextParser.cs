using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct BrowsingContextParser : IAttributeParser<BrowsingContext>
{
    public bool IsValid(BrowsingContext input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out BrowsingContext output)
    {
        return BrowsingContext.TryParse(input, out output);
    }

    public bool TryToString(BrowsingContext input, [MaybeNullWhen(false)] out string output)
    {
        output = input.ToString();
        return true;
    }
}

namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct ElementIsParser : IAttributeParser<string, StringParser>
{
    public bool IsValid(string input)
    {
        return HtmlHelper.IsValidPotentialCustomElementName(input);
    }
}

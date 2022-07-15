namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct TokenParser : IAttributeParser<string, StringParser>
{
    public bool IsValid(string input)
    {
        return !HtmlHelper.HasASCIIWhitespace(input);
    }
}

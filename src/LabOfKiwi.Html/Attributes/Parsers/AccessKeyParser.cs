namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct AccessKeyParser : IAttributeParser<char, CharParser>
{
    public bool IsValid(char input)
    {
        return !HtmlHelper.IsASCIIWhitespace(input);
    }
}

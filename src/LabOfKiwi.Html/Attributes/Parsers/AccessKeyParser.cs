namespace LabOfKiwi.Html.Attributes.Parsers;

internal readonly struct AccessKeyParser : IAttributeParser<char, CharParser>
{
    public bool IsValid(char input)
    {
        return !HtmlHelper.IsASCIIWhitespace(input);
    }
}
